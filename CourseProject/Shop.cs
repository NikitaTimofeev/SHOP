using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class Shop
    {
        private string Name { get; set; }
        private Window Window{ get; set; }
        private Storage Storage { get; set; }

        public Shop()
        {
            Name = NameGenerator.NameForShop();
            Window = new Window();
            Storage = new Storage();
        }

 
        public void CallWindow()
        {
            Console.WriteLine(Window.ToString());
        }

        public double CalculateSumm(int id, int count)
        {
            return Window.СalculateSumm(id, count);
        }

        
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
