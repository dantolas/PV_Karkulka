using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Player
    {
        string name = "CervenaKarkulka";
        
        public pole field;
        public pole.fieldItem? position;
        public List<String> basket;

        public Player()
        {
            this.basket = new List<String>();
            fillBasket();

            this.field = new pole("lvl",4,4);
            position = field.home;
            
        }


        public void giveItem()
        {
            Console.WriteLine(printBasket());
            string input = "";
            Console.WriteLine("The Lumberjack will help you, but he requires something in return.");
            do
            {
                Console.WriteLine("What will you offer?");
                 input = Console.ReadLine();
                if (basket.Contains(input.ToLower()))
                {
                    basket.Remove(input.ToLower());
                    Console.WriteLine("The Lumberjack saved you and took your "+input);
                    break;
                }

                Console.WriteLine("That is not in your basket.");


            } while (true);
        }

        public void fillBasket()
        {
            basket.Add("apples");
            basket.Add("wine");
            basket.Add("nintendo switch");
            basket.Add("bread");
            basket.Add("wheel of cheese");
        }


        public void moveWest()
        {
            if(position.west == null)
            {
                Console.WriteLine("Going further West would be bad, big angry Badgers live there.");
                return;
            }
            
            position = position.west;

        }

        public void moveNorth()
        {
            if (position.north == null)
            {
                Console.WriteLine("If I go any further north I will freeze");
                return;
            }
            position = position.north;
        }

        public void moveEast()
        {
            if (position.east == null)
            {
                Console.WriteLine("One more step east and I'll get to china.");
                return;
            }
            position = position.east;
        }

        public void moveSouth()
        {
            if (position.south == null)
            {
                Console.WriteLine("South, I need to visit the cities that way someday, but not right now.");
                return;
            }
            position = position.south;
        }

        public string printBasket()
        {
            string returnString = "";
            foreach(string s in this.basket)
            {
                returnString +=s+", ";
            }
            returnString.Remove(returnString.Length);
            return returnString;
        }



    }
}
