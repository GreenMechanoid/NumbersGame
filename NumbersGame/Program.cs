using System;
//Daniel Svensson .Net22
namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool NormalOrCustom = false;
            bool GameState = true;
            ConsoleKey YesOrNo;
            Random rand = new Random();
            Guesser engine = new Guesser();
            int guesses = 5;
            int Difficulty = 0;
            string QueryString = ""; // get's string input from user for the guesses

            do
                switch (GameState)
                {
                    default: // normal operation
                        int StandardRandNumber = rand.Next(1, 21);
                        Console.WriteLine("Välkommen! Jag tänker på ett nummer.Kan du gissa vilket ?");

                        do
                        {
                            Console.WriteLine("Vill du välja en svårighetsgrad eller vill du ha den normala? Y/N");
                            YesOrNo = Console.ReadKey(false).Key;
                        } while (YesOrNo != ConsoleKey.Y && YesOrNo != ConsoleKey.N); // takes input from user to check Yes or no

                        NormalOrCustom = true ? YesOrNo == ConsoleKey.Y : YesOrNo == ConsoleKey.N; // do they want custom difficulty?
                        Console.Clear();

                        if (NormalOrCustom == true) // yes they do, let's make it a custom game
                        {
                            Console.WriteLine("Vänligen välj en svårighetsgrad mellan 1 och 5");
                            QueryString = Console.ReadLine();
                            while (int.TryParse(QueryString, out Difficulty) is false) // checks that a number is entered
                            {
                                Console.WriteLine("Vänligen välj en svårighetsgrad mellan 1 och 5");
                                Console.WriteLine("1: 10 gissningar, 15 olika tal");
                                Console.WriteLine("2: 8 gissningar, 30 olika tal");
                                Console.WriteLine("3: 7 gissningar, 45 olika tal");
                                Console.WriteLine("4: 6 gissningar, 60 olika tal");
                                Console.WriteLine("5: 5 gissningar, 75 olika tal");
                                QueryString = Console.ReadLine();
                            }
                            Difficulty = Convert.ToInt32(QueryString);
                            engine.CustomGuessing(QueryString,rand,Difficulty, NormalOrCustom); // inputs the values into the custom game selector

                        }
                        else // normal guessing game with set difficulty, and no they dont want a custom difficulty
                        {
                            Console.WriteLine("Du kommer få 5 gissningar, med ett nummer mellan 1 och 20");
                            engine.Guessing(guesses, StandardRandNumber,QueryString, NormalOrCustom);
                        }

                        GameState = engine.RestartGame(YesOrNo); // calls function to check if player wants to play again
                        if (GameState == true)
                        {
                            Console.Clear(); // empty's the console for the new run
                            break;
                        }
                        else { goto case false; }
                    case false: // Exit message to the player
                        Console.Clear();
                        Console.WriteLine("\nTackar för att du spelade, Ha en trevlig dag!\n");
                        break;
                }
            while (GameState == true); // keeps going untill player says stop

        }
    }
}
