using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class Storage
    {
        private static Queue<Cell> Cell { get; set; }
        

        public Storage()
        {
            Cell = FillStorage();   
        }

        private Queue<Cell> FillStorage()
        {
            Queue<Cell> cell = new Queue<Cell>();
            
            for (int cells = 0; cells < 10; cells++)
            {
               cell.Enqueue(new Cell());
            }

            return cell;
        }
        
    
        public static Cell GiveProductToCell()
        {
            return Cell.Dequeue();
        }

        public override string ToString()
        {
            foreach(var product in Cell)
            {
                Console.WriteLine(product.ToString());
            }
            return "";
        }
    }
}
