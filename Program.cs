using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Lab_5._2_Rock_Paper_Scissors
{
    class Program
    {
        enum Roshambo
        {
            Rock,
            Paper,
            Scissors
        }
        abstract class Player
        {
            public Roshambo choice { get; set; }
            public virtual Roshambo GenerateRoshambo() 
            {
                return Roshambo.Rock;             
            }                      
        }
        class Leonard : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                choice = Roshambo.Rock;
                return Roshambo.Rock;
            }
        }
        class Sheldon : Player
        {
            private static Random rand = new Random();
            public override Roshambo GenerateRoshambo()
            {
                int roshambo_num = rand.Next(0, 3);
                Roshambo randRoshambo = (Roshambo)roshambo_num;

                choice = randRoshambo;
                return randRoshambo;
            }
        }
        class User : Player
        {
            public string Name { get; set; }
            public User(string userName)
            {
                Name = userName;
            }
            public override Roshambo GenerateRoshambo()
            {
                Console.WriteLine();
                Console.Write($"Choose your Weapon!\nRock, Paper, Scissors? (R/P/S): ");
                string entry = Console.ReadLine().ToLower();
                if (entry != "r" && entry != "p" && entry != "s")
                {
                    Console.WriteLine();
                    Console.WriteLine($"That is not a valid option, please try again!");
                }
                if (entry == "r")
                {
                    choice = Roshambo.Rock;
                    return Roshambo.Rock;
                }
                else if (entry == "p")
                {
                    choice = Roshambo.Paper;
                    return Roshambo.Paper;
                }
                else
                {
                    choice = Roshambo.Scissors;
                    return Roshambo.Scissors;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to Rock, Paper, Scissors!");

            Console.WriteLine();
            Console.Write($"Enter your name: ");
            string userName = Console.ReadLine();

            User user = new User(userName);
            Player computerPlayer;

            Console.WriteLine();
            Console.Write($"Would you like to play against Leonard or Sheldon? (L/S): ");
            string userOpponent = Console.ReadLine().ToLower();
            if (userOpponent != "l" && userOpponent != "s")
            {
                Console.WriteLine();
                Console.WriteLine($"That is not a valid option, please try again!");
            }
            if (userOpponent == "l")
            {
                computerPlayer = new Leonard();
                computerPlayer.GenerateRoshambo();
            }
            else
            {
                computerPlayer = new Sheldon();
                computerPlayer.GenerateRoshambo();
            }

            bool running = true;
            while (running)
            {
                user.GenerateRoshambo();

                if (user.choice == Roshambo.Rock && computerPlayer.choice == Roshambo.Rock)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nIt's a draw!");
                }
                else if (user.choice == Roshambo.Rock && computerPlayer.choice == Roshambo.Paper)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nYou lose! Paper beats Rock!");
                }
                else if (user.choice == Roshambo.Rock && computerPlayer.choice == Roshambo.Scissors)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nWinner winner, chicken dinner! Rock beats scissors!");
                }
                else if (user.choice == Roshambo.Paper && computerPlayer.choice == Roshambo.Rock)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nAwww yeah! Paper covers rock. You Win!");
                }
                else if (user.choice == Roshambo.Paper && computerPlayer.choice == Roshambo.Paper)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nIt's a tie!");
                }
                else if (user.choice == Roshambo.Paper && computerPlayer.choice == Roshambo.Scissors)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nBummer man! You lost! Scissors cut through paper");
                }
                else if (user.choice == Roshambo.Scissors && computerPlayer.choice == Roshambo.Rock)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nLoser! Rock crushs scissors!");
                }
                else if (user.choice == Roshambo.Scissors && computerPlayer.choice == Roshambo.Paper)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nNoice! You win! Scissors slice and dice paper");
                }
                else if (user.choice == Roshambo.Scissors && computerPlayer.choice == Roshambo.Scissors)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You chose: {user.choice}\nYour opponent chose: {computerPlayer.choice}\nDraw! Try again!");
                }

                Console.WriteLine();
                Console.Write($"Play Again? (y/n): ");
                string cont = Console.ReadLine().ToLower();

                if (cont == "yes" || cont == "y")
                {
                    running = true;
                    {

                    }
                }
                else if (cont == "no" || cont == "n")
                {
                    running = false;
                    {
                        Console.WriteLine($"Thanks for Playing!!");
                    }

                }
            }
        }
    }
}

