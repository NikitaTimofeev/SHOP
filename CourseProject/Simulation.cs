using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class Simulation
    {
        public static void RUN()
        {

            Buyer buyer1 = new Buyer();
            var payment = 0.0;
            Shop shop1 = new Shop();


            Greeting(buyer1,shop1);


            while (true)
            {

                Console.WriteLine("YOU SEE AT THE WINDOW NEXT PRODUCTS");
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                shop1.CallWindow();
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.WriteLine("CHOOSE WHAT YOU WANT TO BY.... write number of product and then count \n" +
                                  " If you want go to the cashier write 'go' \n" +
                                  " If you want watch what in your basket write 'basket' \n" +
                                  " If you want buy more push Enter \n" +
                                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                

                string answer = Convert.ToString(Console.ReadLine());
                
                if (answer == "basket")
                {
                    buyer1.ViewProdInBasket();
                    Console.WriteLine("");
                }
                else if (answer == "go")
                {
                    while (answer == "go")
                    {
                        try
                        {

                            buyer1.ViewProdInBasket();

                            Console.WriteLine("Want to buy it? (Print 'yes' if yes)");
                            string buy = Convert.ToString(Console.ReadLine());

                            if (buy == "yes")
                            {
                                buyer1.AddToBag();      
                                Console.WriteLine(buyer1.ToString(payment));
                            }
                            else
                            {
                                answer = "no";
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    }
                }
                else
                {
                    try
                    {
                        string[] productNameAndCount = answer.Split(" ");
                        int productId = Convert.ToInt32(productNameAndCount[0]) - 1;
                        int productCount = Convert.ToInt32(productNameAndCount[1]);
                        payment += shop1.CalculateSumm(productId, productCount);

                        if (payment > buyer1.ShowMoney())
                        {
                            ReturnProduct(buyer1);
                        }
                    }
                    catch(ShopException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (BagException e)
                    {
                        Console.WriteLine(e.Message);
                        ReturnProduct(buyer1);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message + "please, input integers");
                    }
                    catch(ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message );       
                    }
                } 
            }
        }


        public static void Greeting(Buyer buyer, Shop shop)
        {
            Console.WriteLine("WELCOME IN SHOP APP");
            Console.WriteLine("");
            Console.WriteLine("YOU ARE A BUYER WITH NEXT PARAMETERS");
            Console.WriteLine("");
            Console.WriteLine(buyer.ToString());
            Console.WriteLine("");
            Console.WriteLine("YOU ENTERED IN " + shop.ToString());
            Console.WriteLine("");
        }


        public static void ReturnProduct(Buyer buyer)
        {
            Console.WriteLine("You dont have enough money, please return some products");
            buyer.ViewProdInBasket();


            string answer = Convert.ToString(Console.ReadLine());
            string[] productNameAndCount = answer.Split(" ");
            int productId = Convert.ToInt32(productNameAndCount[0]) - 1;
            int productCount = Convert.ToInt32(productNameAndCount[1]);


            buyer.ReturnProduct(productId, productCount);
            buyer.ViewProdInBasket();
        }

        
    }
}
