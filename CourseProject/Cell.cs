using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class Cell
    {
        

        private FoodStuff ProductInCell { get; set; }
        private int CountFoodInCell { get; set; }

        public Cell()
        {
            ProductInCell = new FoodStuff();
            CountFoodInCell = NameGenerator.RandomInt(1,10);
        }

        
        public Cell(FoodStuff food, int count)
        {
            ProductInCell = food;
            CountFoodInCell = count;
        }


        public double CalculateSumm(int id,int count)
        {
            FoodStuff food = ProductInCell;

            if (CountFoodInCell < count)
            {
                throw new ShopException($"Cell have {CountFoodInCell} products, not more");
            }


            CountFoodInCell -= count;


            if (CountFoodInCell == 0)
            {
                Window.DeleteFoodFromCell(id);
            }

            Buyer.AddToBusket(food, count);

            return food.CalculateSumm(food, count);
        }

        
        public override string ToString()
        {
            return ProductInCell.ToString() + $"Count: {CountFoodInCell}";
        }
    }
}