using System;
using System.Collections.Generic;
using System.Text;
//Daniel Svensson .Net22
namespace NumbersGame
{

    class Guesser
    {
        public void Guessing(int numberOfGuesses, int randNumber, string Query,bool NormalOrCustom)
        {
            int GuessCounter = 0;
            int GuessedNumber;
            bool CorrectGuess = false;
            Console.WriteLine("Dags för din första gissning");
            do
            {
                do
                {
                    Query = Console.ReadLine();
                } while (int.TryParse(Query, out GuessedNumber)is false);

                if (GuessedNumber == randNumber)
                {
                    Console.WriteLine("Woho! Du gjorde det!");
                    CorrectGuess = true;
                }
                else if (GuessedNumber < randNumber){
                    Console.WriteLine("Tyvärr du gissade för lågt! Försök kvar:" + ((numberOfGuesses -1) - GuessCounter));
                }
                else
                {
                    Console.WriteLine("Tyvärr du gissade för högt! Försök kvar:" + ((numberOfGuesses - 1) - GuessCounter));
                }

                GuessCounter++;

                if (GuessCounter == numberOfGuesses && NormalOrCustom == false)
            {
                Console.Clear();
                Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök! Nummret var:" + randNumber);
            }
            else if (GuessCounter == numberOfGuesses && NormalOrCustom == true && CorrectGuess == false)
            {
                Console.Clear();
                Console.WriteLine("Tyvärr du lyckades inte gissa talet på " + numberOfGuesses + " försök! Nummret var:" + randNumber);
            }
            } while ((GuessCounter != numberOfGuesses) && CorrectGuess == false );
            
        }

        public void CustomGuessing(string query,Random rand, int difficulty, bool NormalOrCustom)
        {
            int RandomNumber;
            switch (difficulty)
            {
                case 1:
                    RandomNumber = rand.Next(1,15);
                    Guessing(10, RandomNumber, query, NormalOrCustom);
                    break;
                case 2:
                    RandomNumber = rand.Next(1,30);
                    Guessing(8, RandomNumber, query, NormalOrCustom);
                    break;
                case 3:
                    RandomNumber = rand.Next(1,45);
                    Guessing(7, RandomNumber, query, NormalOrCustom);
                    break;
                case 4:
                    RandomNumber = rand.Next(1,60);
                    Guessing(6, RandomNumber, query, NormalOrCustom);
                    break;
                case 5:
                    RandomNumber = rand.Next(1,75);
                    Guessing(5, RandomNumber, query, NormalOrCustom);
                    break;

            }


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
