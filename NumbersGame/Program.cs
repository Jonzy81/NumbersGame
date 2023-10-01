using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Jonny Touma .NET23

            //variables used in the loop 
            int guess;
            int counter = 5;    // Antal gissningar man får
            bool isRunning = true;
            string level;

            while (isRunning)   //While true makes it awaliable for user to enter meny again/ exit game.
            {
                //Meny indented with red colour 
                Console.WriteLine("\tVälkommen till mitt gissningsspel vänligen välj svårighetsgrad från menyn nedan ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t[1]: enkel gissa mellan 1-10 med 5 gissningar " +
                "\n\t[2]: medel gissa mellan 1-20 med 5 gissningar" +
                "\n\t[3]: svår gissa mellan 1-50 med 5 gissningar" +
                "\n\t[4]: Avsluta spelet");
                //Switch med svårigheter
                //låg 1-10 med 7 gissningar
                //medium 1-20 med 5 gissningar
                ////svårt 1-50 med 5 gissningar 
                Console.ResetColor();

                level = Console.ReadLine();

                switch (level)
                {
                    case "1":   //Game 1
                        int myNumber = RandomGenerator(1, 11);  //method 

                        while (counter > 0) //Condition for the game 
                        {
                            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-10. Kan du gissa vilket? Du får fem försök.");
                            string input = Console.ReadLine();
                            guess = int.Parse(input);

                            counter--;

                            if (myNumber == guess)      //right answer
                            {
                                RandomRightAnswer();        //method for random messages
                                Console.WriteLine("Vill du pröva igen?, i såna fall skriv ja eller nej");
                                string playAgain = Console.ReadLine();
                                if (playAgain == "ja" || playAgain == "j")
                                {
                                    counter = 5;        //Gives player 5 more guesses and goes back to meny 
                                    break;
                                }
                                else if (playAgain == "nej" || playAgain == "n")
                                {
                                    isRunning = false;      //Breaks loop and exits game
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Vänligen skriv med ett ja eller nej");
                                }
                            }
                            else if (myNumber < guess)      //to high 
                            {
                                if (Math.Abs(myNumber - guess) <= 2)
                                {
                                    Console.WriteLine($"Det bränns, ");
                                    RandomToHighAnswer();       //Method for random messages
                                    Console.Write($" Du har {counter} gissningar kvar.");
                                }
                                else
                                {
                                    RandomToHighAnswer();       //method for random messages
                                    Console.WriteLine($" Du har {counter} gissningar kvar.");
                                }
                            }
                            else if (myNumber > guess)      //To low 
                            {
                                if (Math.Abs(myNumber - guess) <= 2)
                                {
                                    Console.Write($"Det bränns, ");
                                    RandomToLowAnswer();        //method for random messages
                                    Console.Write($", Du har {counter} gissningar kvar.");
                                }
                                else
                                {
                                    RandomToLowAnswer();        //method for random messages
                                    Console.WriteLine($", Du har {counter} gissningar kvar.");
                                }
                            }
                            if (counter <= 0)
                            {
                                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök! Det rätta numret var: " + myNumber);
                                Console.WriteLine("Vill du pröva igen?, i såna fall skriv ja eller nej");
                                string playAgain = Console.ReadLine();
                                if (playAgain == "ja" || playAgain == "j")
                                {
                                    counter = 5;
                                    break;
                                }
                                else if (playAgain == "nej" || playAgain == "n")
                                {
                                    isRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("Vänligen skriv med ett ja eller nej");
                                }
                            }
                        }
                        break;

                    case "2":       //Same conditions as above just higher span of random numbers
                        int myNumber2 = RandomGenerator(1, 21);

                        while (counter > 0)
                        {
                            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-20. Kan du gissa vilket? Du får fem försök.");
                            guess = Convert.ToInt32(Console.ReadLine());
                            counter--;

                            if (myNumber2 == guess)
                            {
                                RandomRightAnswer();
                            }
                            else if (myNumber2 < guess)
                            {
                                if (Math.Abs(myNumber2 - guess) <= 2)
                                {
                                    Console.WriteLine($"Det bränns, ");
                                    RandomToHighAnswer();
                                    Console.Write($" Du har {counter} gissningar kvar.");
                                }
                                else
                                {
                                    RandomToHighAnswer();
                                    Console.WriteLine($" Du har {counter} gissningar kvar.");
                                }
                            }
                            else if (myNumber2 > guess)
                            {
                                if (Math.Abs(myNumber2 - guess) <= 2)
                                {
                                    Console.Write($"Det bränns, ");
                                    RandomToLowAnswer();
                                    Console.Write($", Du har {counter} gissningar kvar.");
                                }
                                else
                                {
                                    RandomToLowAnswer();
                                    Console.WriteLine($", Du har {counter} gissningar kvar.");
                                }
                            }
                            if (counter == 0)
                            {
                                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök! Det rätta numret var: " + myNumber2);
                                Console.WriteLine("Vill du pröva igen?, i såna fall skriv ja eller nej");
                                string playAgain = Console.ReadLine();
                                if (playAgain == "ja" || playAgain == "j")
                                {
                                    counter = 5;
                                    break;
                                }
                                else if (playAgain == "nej" || playAgain == "n")
                                {
                                    isRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("Vänligen skriv med ett ja eller nej");
                                }
                            }
                        }

                        break;
                    case "3":       //Same as above just higher numbers
                        int myNumber3 = RandomGenerator(1, 51);

                        while (counter > 0)
                        {
                            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-50. Kan du gissa vilket? Du får fem försök.");
                            guess = Convert.ToInt32(Console.ReadLine());
                            counter--;

                            if (myNumber3 == guess)
                            {
                                RandomRightAnswer();
                            }
                            else if (myNumber3 < guess)
                            {
                                if (Math.Abs(myNumber3 - guess) <= 2)
                                {
                                    Console.WriteLine($"Det bränns, ");
                                    RandomToHighAnswer();
                                    Console.Write($" Du har {counter} gissningar kvar.");
                                }
                                else
                                {
                                    RandomToHighAnswer();
                                    Console.WriteLine($" Du har {counter} gissningar kvar.");
                                }
                            }
                            else if (myNumber3 > guess)
                            {
                                if (Math.Abs(myNumber3 - guess) <= 2)
                                {
                                    Console.Write($"Det bränns, ");
                                    RandomToLowAnswer();
                                    Console.Write($", Du har {counter} gissningar kvar.");
                                }
                                else
                                {
                                    RandomToLowAnswer();
                                    Console.WriteLine($", Du har {counter} gissningar kvar.");
                                }
                            }
                            if (counter == 0)
                            {
                                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök! Det rätta numret var: " + myNumber3);
                                Console.WriteLine("Vill du pröva igen?, i såna fall skriv ja eller nej");
                                string playAgain = Console.ReadLine();
                                if (playAgain == "ja" || playAgain == "j")
                                {
                                    counter = 5;
                                    break;
                                }
                                else if (playAgain == "nej" || playAgain == "n")
                                {
                                    isRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("Vänligen skriv med ett ja eller nej");
                                }
                            }
                        }
                        break;

                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Vänligen välj ett tal mellan 1-4");
                        break;
                }
            }
            Console.WriteLine("Tack för att du spelade");
        }

        static void RandomRightAnswer()     //Method for genrate a random message to end user, one for right, high and low.
        {
            string[] rightAnswer = { "Wohoo! Du klarade det!", "Grattis, du gissade rätt", "Bästa! du valde rätt nummer!" };
            int RandomIndex = RandomGenerator(0, rightAnswer.Length);
            Console.Write(rightAnswer[RandomIndex]);
        }
        static void RandomToHighAnswer()
        {
            string[] toHigh = { "Tyvärr, du gissade för högt!", "För högt gissat!", "Fel, du har valt ett för högt nummer" };
            int RandomIndex = RandomGenerator(0, toHigh.Length);
            Console.Write(toHigh[RandomIndex]);
        }
        static void RandomToLowAnswer()
        {
            string[] toLow = { "Tyvärr, du gissade för lågt!", "För lågt!", "Fel, Du gissade för lågt" };
            int RandomIndex = RandomGenerator(0, toLow.Length);
            Console.Write(toLow[RandomIndex]);
        }
        static int RandomGenerator(int min, int max)   //Method that generates random numbers, 
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
