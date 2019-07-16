using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class NameGenerator
    {
        public static string genNameForBuyer()
        {
            string[] Names = new string[14] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "abby", "abigail", "adele", "adrian" };
            string[] lastNames = new string[5] { "abbott", "acosta", "adams", "adkins", "aguilar" };
            string currentName;
            Random rand = new Random(DateTime.Now.Second);
            
            currentName = Names[rand.Next(0, Names.Length - 1)] + " " + lastNames[rand.Next(0, lastNames.Length - 1)];
            
            return currentName;
        }
        public static string genNameForShop()
        {
            string currentShop;
            string[] Names = new string[5] { "ATB", "Metro", "ASHAN", "Silpo", "shop" };

            Random rand = new Random();

            currentShop = Names[rand.Next(0, Names.Length - 1)];
            return currentShop;

        }
        public static string genProduct()
        {
            string currentProduct;
            string[] Products = new string[25] { "tomato", "beetroot","brussel sprouts","peas","zucchini",
                                                "radish","sweet potato","artichoke","leek","cabbage",
                                                "celery","chili","garlic","basil","coriander",
                                                "parsley","dill","rosemary","oregano","cinnamon",
                                                "saffron","green bean","bean","chickpea","lentil"
                                                };

            Random rand = new Random();

            currentProduct = Products[rand.Next(0, Products.Length - 1)];

            return currentProduct;
        }

        public static int RandomInt(int from,int to)
        {
            Random rand = new Random();
            return rand.Next(from, to);
        }

    }
}
