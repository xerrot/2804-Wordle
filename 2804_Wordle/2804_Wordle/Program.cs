using System.ComponentModel;
using System.Linq;

namespace _2804_Wordle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            bool running = true;
            char[] wordToGuess = { 'a', 'p', 'p', 'l', 'e' };
            char[] wordGuessed = new char[6];
            int attemptsAllowed = 6;

            //TODO: fix bug (for example if the word to be guessed is apple, and the guess is pappl - this method will mark all 3 p's as yellow)
            char[] guess()
            {
                Console.WriteLine("\nPlease enter a 5-letter word:");
                string userInput = Console.ReadLine();
                if (userInput == null || userInput.Length != 5)
                {
                    Console.WriteLine("\nPlease enter a valid 5-letter word.");
                    return null;
                }
                char[] userGuess = userInput.ToCharArray();

                for (int i = 0; i < 5; i++)
                {
                    if (userGuess[i] == wordToGuess[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(userGuess[i]);
                    }
                    else if (wordToGuess.Contains(userGuess[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(userGuess[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(userGuess[i]);
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
                return userGuess;
            }

            void playGame()
            {
                Console.WriteLine($"You have {attemptsAllowed} attempts to guess a 5-letter word.\n");

                for (int i = 0; i < attemptsAllowed; i++)
                {
                    char[] attempt = guess();
                    if (attempt == null)
                    {
                        i--;
                        continue;
                    }

                    if (attempt.SequenceEqual(wordToGuess))
                    {
                        Console.WriteLine("\nCongratulations! You guessed the word correctly!");
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        return;
                    }
                }
                Console.WriteLine("\nYou have used all of your attempts.");
                Console.WriteLine("The word was: " + new string(wordToGuess));
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                }
            while (true)
            {
                Console.WriteLine("\nWelcome to Wordle, a word guessing game!\n1. Start the game\n2. Exit");
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.Clear();
                        playGame();
                        break;

                    case "2":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

