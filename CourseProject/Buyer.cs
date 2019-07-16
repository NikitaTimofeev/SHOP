using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CourseProject
{
    class Buyer
    {
        /*
        Делаю поле статик чтобы мог вызвать его в статик методе. Ошибка была на этапе проектирования, нужно было в большинство методов передавать покупателя
        По сути все поля у покупателя могут быть статик так как он единственный в нашем магазине
        */
        private static List<FoodStuff> Bag { get; set; }
        private static List<FoodStuff> Basket { get; set; }

        private string NameBuyer { get; set; }
        private double Money { get; set; }
  

        public Buyer()
        {
            NameBuyer = NameGenerator.NameForBuyer();
            Bag = new List<FoodStuff>(NameGenerator.RandomInt(1,50));
            Money = NameGenerator.RandomInt(100,1000);
            Basket = new List<FoodStuff>();
        }

        
        public double CalculateDept(double payment)
        {
            if(Money < payment)
            {
                throw new ShopException("You don`t have enough money");
            }
            return Money - payment;
        }

        public void ReturnProduct(int id,int count)
        {
            FoodStuff food = Basket[id];

            for (int i = 0; i < count; i++)
            {
                Basket.Remove(food);
            }
            
        }


        public static List<FoodStuff> AddToBusket(FoodStuff food, int count)
        {
            for(int i  = 0; i< count; i++)
            {
                Basket.Add(food);
            }
            if (Basket.Count > Bag.Capacity)
            {
                throw new BagException("Products will not fit in the bag");
            }
            return Basket;
        }

        

        public double ShowMoney()
        {
            return Money;

        }
        public void AddToBag()
        {
            for (int i = 0; i < Basket.Count; i++)
            {
                Bag.Add(Basket[i]);
            }           
        }

        public  void ViewProdInBasket()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("|        You bought next items:      |");

            var query = from x in Basket
                    group x by x.NameProduct into g
                    let count = g.Count()
                    orderby count descending
                    select new { Name = g.Key, Count = count, PriceForOneProd = g.First().Price, Price = count*g.First().Price };

            var totalCost = query.Select(e => e.Price).Sum();
            var iter = 1;
            foreach (var x in query)
            {
                Console.WriteLine( $"| {iter} Name: " + x.Name + " Price: " + x.PriceForOneProd + 
                                    " Count: " + x.Count  + 
                                    " Cost for product: " + x.Price +" |");
                iter++;
            }

            Console.WriteLine($"|        Total price {totalCost} money       |"  );
            Console.WriteLine( "**************************************");
            Console.WriteLine("");

        }

        public override string ToString()
        {
            return $"Name: {NameBuyer}  in bag may be {Bag.Capacity} products but now it have {Bag.Count} products and you have {Money}  money";
        }

        public  string ToString(double youmustpay)
        {
            return $"Name: {NameBuyer}  in bag may be {Bag.Capacity} products but now it have {Bag.Count} products and you have {Money - youmustpay}  money";
        }


    }
}
