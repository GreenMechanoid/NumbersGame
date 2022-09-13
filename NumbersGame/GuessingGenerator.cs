using System;
using System.Collections.Generic;
using System.Text;
//Daniel Svensson .Net22
namespace NumbersGame
{

    class Guesser
    {
        public void StandardGuessing(int numberOfGuesses, int randNumber, string Query)
        {
            Console.WriteLine("We got to Standard Guessing!");
            int GuessCounter = 0;
            int GuessedNumber;
            bool CorrectGuess = false;
            do
            {
                do
                {
                    Query = Console.ReadLine();
                } while (int.TryParse(Query, out GuessedNumber)is false);

                if (GuessedNumber == randNumber)
                {
                    Console.WriteLine("Grattis du gissade rätt!");
                    CorrectGuess = true;
                }
                else
                {
                    Console.WriteLine("Tyvär du gissade fel!, försök igen");
                }

                GuessCounter++;
            } while ((GuessCounter != numberOfGuesses) && CorrectGuess == false);
            if (GuessCounter == numberOfGuesses)
            {
                Console.Clear();
                Console.WriteLine("Tyvär så var det sista gissningen!, Det rätta nummret var "+ randNumber);
            }
        }

        public void CustomGuessing(int numberOfGuesses)
        {
            Console.WriteLine("We got to Custom Guessing!");
        }

        public bool RestartGame(ConsoleKey inputVariable)
        {
            bool Restart = false;
            Console.WriteLine("Vill du spela igen? Y/N");
            do
            {
                Console.WriteLine("\nVänligen tryck antigen Y eller N..");
                inputVariable = Console.ReadKey(false).Key;
            } while (inputVariable != ConsoleKey.Y && inputVariable != ConsoleKey.N); // takes input from user to check Yes or no
            Restart = true ? inputVariable == ConsoleKey.Y : inputVariable == ConsoleKey.N;
            return Restart;
        }

    }





}
