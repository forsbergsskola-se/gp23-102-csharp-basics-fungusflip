using System;

namespace NimGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int matchesNumber = 24;
            int aiChoice = 3;
            Console.WriteLine("Welcome to Nim!");

            while (matchesNumber > 0)
            {
                Console.WriteLine("\nCurrent matches: " + matchesNumber);
                Console.WriteLine("How many matches do you want to draw?");
                string matchesText = Console.ReadLine();

                if (int.TryParse(matchesText, out int playerChoice) && playerChoice > 0 && playerChoice <= 3)
                {
                    if (matchesNumber - playerChoice >= 0)
                    {
                        matchesNumber -= playerChoice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. You can't take more matches than are available.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number between 1 and 3.");
                    continue;
                }

                if (matchesNumber <= 0)
                {
                    Console.WriteLine("You win!");
                    break;
                }

                Console.WriteLine("\nCurrent matches: " + matchesNumber);
                Console.WriteLine("AI's turn...");

                // Ai logic om jag blir bättre på det
                aiChoice = Math.Min(matchesNumber, aiChoice); // number till aichoice
                matchesNumber -= aiChoice;
                Console.WriteLine("AI drew " + aiChoice + " matches.");

                if (matchesNumber <= 0)
                {
                    Console.WriteLine("AI wins!");
                    break;
                }
            }

            Console.WriteLine("\nGame Over!");
        }
    }
}
