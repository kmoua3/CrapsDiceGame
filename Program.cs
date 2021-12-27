// Ku Moua
using System;
using System.Runtime.CompilerServices;

namespace Craps
{
    class Program
    {
        static void Main(string[] args)
        {

            // Variables to keep track of chips, wager, point, round, and whether to roll or start a new game
            int chips = 100;
            String roll = "";
            int wager;
            int point = 0;
            int round = 1;
            String game = "";

            // Intro to the game
            Console.WriteLine("Welcome to Craps!");
            Console.WriteLine("You have {0} chips", chips);

            // Determines whether to roll or not
            while (roll != "Y" || roll != "N")
            {

                // Ends game if chips equal zero
                if (chips <= 0)
                {
                    Console.WriteLine("\nThanks for playing! Unfortunately, you have run out of chips :'(");
                    break;
                }

                // Ask the user if they want to roll
                Console.WriteLine("\nWould you like to roll? (Y/N)");
                roll = Console.ReadLine();

                // Switch case for whether the user chooses to roll or not
                switch (roll)
                {
                    case "Y":

                        wager = -1;

                        // Loops if user selects a value over or under the amount of chips available
                        while (wager > chips || wager < 0)
                        {
                            Console.WriteLine("\nTotal chips: {0}", chips);
                            Console.WriteLine("How many chips are you willing to wager?");
                            // Had to convert the user input to "int"
                            wager = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.WriteLine("\nChips Wagered: {0}", wager);

                        Console.WriteLine("\n--Dice Roll--\n");

                        // Creates random integer for dices and adds them together
                        Random rand = new Random();
                        int dieOne = rand.Next(1, 7);
                        int dieTwo = rand.Next(1, 7);
                        int sum = dieOne + dieTwo;

                        // Output dice information to user
                        Console.WriteLine("Die One: {0}", dieOne);
                        Console.WriteLine("Die Two: {0}", dieTwo);
                        Console.WriteLine("You rolled a total of: {0}", sum);

                        // All game possibilites

                        // Win if roll 7 or 11 on first roll
                        if((round == 1 && sum == 7) || (round == 1 && sum == 11))
                        {
                            Console.WriteLine("\nYou WIN!!");
                            chips = chips + (wager * 2);
                            Console.WriteLine("Total Chips: {0}", chips);
                            roll = "T";
                            break;
                        } 
                        // Win if roll equals point
                        else if (round != 1 && sum == point)
                        {
                            Console.WriteLine("\nYou WIN!!");
                            chips = chips + (wager * 2);
                            Console.WriteLine("Total Chips: {0}", chips);
                            roll = "T";
                            break;
                        }
                        // Lose if roll 2, 3, 12 on first roll
                        else if ((round == 1 && sum == 2) || (round == 1 && sum == 3) || (round == 1 && sum == 12))
                        {
                            Console.WriteLine("\nYou LOSE!!");
                            chips = chips - wager;
                            Console.WriteLine("Total Chips: {0}", chips);
                            roll = "T";
                            break;
                        }
                        // Lose if roll not equal to point not on first roll
                        else if (round != 1 && sum != point)
                        {
                            Console.WriteLine("\nYou LOSE!!");
                            chips = chips - wager;
                            Console.WriteLine("Total Chips: {0}", chips);
                        }
                        // Lose if roll equal 7 not on first roll
                        else if (round != 1 && sum == 7)
                        {
                            Console.WriteLine("\nYou LOSE!!");
                            chips = chips - wager;
                            Console.WriteLine("Total Chips: {0}", chips);
                            //round = 0;
                            roll = "T";
                            break;
                        }
                        // Initialize point depending on roll
                        else if ((round == 1 && sum == 4) || (round == 1 && sum == 5) || (round == 1 && sum == 6) || 
                            (round == 1 && sum == 8) || (round == 1 && sum == 9) || (round == 1 && sum == 10))
                        {
                            point = sum;
                        }

                        // Display point
                        Console.WriteLine("Point: {0}", point);
                        // Increase round
                        round++;
                        // Ensures that the loop continues (Ask if user wants to roll)
                        roll = "G";

                        break;

                    case "N":

                        // Display message and total chips
                        Console.WriteLine("\nThanks for playing!");
                        Console.WriteLine("Total Chips: {0}", chips);

                        roll = "T";

                        break;

                }

                // Triggers question if user wants to start a new game
                if (roll == "T")
                {
                    // Loop for user to answer if they want to start a new game or not
                    while (game != "Y" || game != "N")
                    {
                        Console.WriteLine("\nWould you like to start a new game? (Y/N)");
                        game = Console.ReadLine();

                        // Reset round and point if user wants to start a new game
                        if (game == "Y")
                        {
                            round = 1;
                            point = 0;
                            break;
                        }
                        // Exit loop if user does not want to start a new game
                        else if (game == "N")
                        {
                            break;
                        }
                    }
                        
                    // Exits the game
                    if (game == "N")
                    {
                        break;
                    }

                }


            }


        }



    }
}
