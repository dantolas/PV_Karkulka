using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Game
    {
        int round = 0;
        public Game() {

            


            Console.WriteLine("Hello and welcome to Red Riding Hood-quiz game");

            Player player= new Player();
            Console.WriteLine("Game starts!!!");
            do
            {
                Console.WriteLine("****************");
                Console.WriteLine(player.position+"\n"+player.position.description);
                if(player.position == player.field.granny)
                {
                    Console.WriteLine("YOU HAVE WON THE GAME!!!\nYou brought Granny "+player.printBasket()+". \nShe is so happy her tail starts wagging. Wait...her tail...starts wagging..?\nAnd her nose, it's twitching?");
                    break;
                }
                if (this.round > 0) askQuestion(player);
                Console.WriteLine("  ↑\n<- ->\n  ↓");
                bool arrowPressed;
                do
                {
                     arrowPressed = true;
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    string input = keyPressed.Key.ToString();
                    
                    switch (input)
                    {
                        case "LeftArrow":
                            player.moveWest();
                            break;
                        case "RightArrow":
                            player.moveEast();
                            break;
                        case "UpArrow":
                            player.moveNorth();
                            break;
                        case "DownArrow":
                            player.moveSouth();
                            break;
                        default:
                            Console.WriteLine("Try pressing you arrow keys ;)");
                            arrowPressed = false;
                            break;


                    }
                } while (!arrowPressed);
                this.round++;
            } while (true);

        }


        public void failedQuestion(Player player)
        {
            Console.WriteLine("Wrong!!!");
            if(player.basket.Count() == 0)
            {
                gameOver();
            }

            player.giveItem();

        }

        public void askQuestion(Player player)
        {
            if(player.position.question == null)
            {
                Console.WriteLine("No Question here!");
                return;
            }
            Console.WriteLine(player.position.question);
            string? input = Console.ReadLine();
            if (!player.position.question.checkAnswer(input))
            {
                Console.WriteLine("Wrong!!!");
                player.giveItem();
            }

        }
        public void gameOver()
        {
            throw new Exception("Game over!!!!!\nYour basket is empty and so are your hopes, dreams and determination.\nThe game lasted "+this.round+" rounds.");
        }
    }
}
