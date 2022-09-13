using System;
using System.Collections.Generic;
using System.Text;
//Daniel Svensson .Net22

// made a class and methods to handle game running and logic
namespace NumbersGame
{

    class Guesser
    {
        public void Guessing(int numberOfGuesses, int randNumber, string Query,bool NormalOrCustom) // the games logic
        {
            int GuessCounter = 0;
            int GuessedNumber;
            bool CorrectGuess = false;
            Console.WriteLine("Dags för din första gissning");
            do // keeps running until user either guesses wrong to meny times or get's the correct awnser
            {
                do
                {
                    Query = Console.ReadLine();
                } while (int.TryParse(Query, out GuessedNumber)is false); // makes certain the input is actually a number

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

                if (GuessCounter == numberOfGuesses && NormalOrCustom == false) // below handles the custom game and noraml game Lost logic
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

        public void CustomGuessing(string query,Random rand, int difficulty, bool NormalOrCustom) // takes the custom difficulty settings and inputs them to the games logic
        {
            int RandomNumber; // rand number holder
            while (difficulty >= 6 || difficulty <= 0) // makes certain the "difficulty" selector is within given cases
            {
                Console.Clear();
                Console.WriteLine("Vänligen välj en svårighetsgrad mellan 1 och 5");
                query = Console.ReadLine();
                if (int.TryParse(query, out difficulty) is false)
                {
                difficulty = Convert.ToInt32(query);
                }
            }


            switch (difficulty) // takes the "custom" parts of the game and inserts into the normal logic
            {
                // cases generates numbers that can actually land at say 15 for difficulty 1 according to the previous print to console
                case 1:
                    RandomNumber = rand.Next(1,16); // <- is easier than "normal" mode
                    Guessing(10, RandomNumber, query, NormalOrCustom);
                    break;
                case 2:
                    RandomNumber = rand.Next(1,31);
                    Guessing(8, RandomNumber, query, NormalOrCustom);
                    break;
                case 3:
                    RandomNumber = rand.Next(1,46);
                    Guessing(7, RandomNumber, query, NormalOrCustom);
                    break;
                case 4:
                    RandomNumber = rand.Next(1,61);
                    Guessing(6, RandomNumber, query, NormalOrCustom);
                    break;
                case 5:
                    RandomNumber = rand.Next(1,76);
                    Guessing(5, RandomNumber, query, NormalOrCustom);
                    break;

            }


        }

        public bool RestartGame(ConsoleKey inputVariable) // simple question statement that returns true or false,
            //true they want to play again, false they dont want to play again
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
