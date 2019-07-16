using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class FoodStuff
    {
        //Сделал это поле паблик чтобы можно было написать запрос LINQ для показа количества
        public string NameProduct { get; set; }
        private int Callories { get; set; }
        public double Price { get; set; }
        

        public FoodStuff()
        {
            NameProduct = NameGenerator.Product();
            Callories = NameGenerator.RandomInt(1,100);
            Price = NameGenerator.RandomInt(1,100);
        }
        

        public  double CalculateSumm(FoodStuff food, int count)
        {
            return food.Price * count;
        }
        

        public override string ToString()
        {
            return $"Name: {NameProduct} Callories: {Callories} Price: {Price} ";
        }
    }
}
