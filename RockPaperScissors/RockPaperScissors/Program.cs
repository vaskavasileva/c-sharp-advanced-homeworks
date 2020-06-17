using System;

namespace RockPaperScissors
{
    class Program
    {
        enum Game
        {
            Rock = 1,
            Paper,
            Scissors
        }
        static void Main(string[] args)
        {
            int userScore = 0;
            int applicationScore = 0;
            bool check = true;
            while (check)
            {
                Console.WriteLine("Do you want to play(1), show stats(2) or exit the application(3)?");
                int answer;

                while (true)
                {
                    var input = Console.ReadLine();
                    var output = int.TryParse(input, out answer);
                    if (answer == 1 || answer == 2 || answer == 3)
                        break;

                    Console.WriteLine("Please enter 1(play), 2(show stats) or 3(exit application).");
                }

                switch (answer)
                {
                    case 1:
                        {
                            Console.WriteLine("Please select rock(1), paper(2) or scissors(3).");
                            int userPick;
                            while (true)
                            {
                                var input = Console.ReadLine();
                                var output = int.TryParse(input, out userPick);
                                if (userPick == 1 || userPick == 2 || userPick == 3)
                                    break;

                                Console.WriteLine("Please enter 1(rock), 2(paper) or 3(scissors).");
                            }

                            var picked = new Random().Next(1, 3);

                            Console.WriteLine($"The user picked {Enum.GetName(typeof(Game), userPick)}");
                            Console.WriteLine($"The application picked {Enum.GetName(typeof(Game), picked)}");

                            if ((userPick == 1 && picked == 2) || (userPick == 2 && picked == 3) || (userPick == 3 && picked == 1))
                            {
                                Console.WriteLine("The application wins.");
                                applicationScore++;

                            }
                            else if ((picked == 1 && userPick == 2) || (picked == 2 && userPick == 3) || (picked == 3 && userPick == 1))
                            {
                                Console.WriteLine("The user wins.");
                                userScore++;
                            }
                            Console.ReadLine();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine($"The user has {userScore} wins and the computer has {applicationScore} wins.");
                            var percentWon = userScore / (userScore + applicationScore);
                            var percentLost = 100 - percentWon;
                            Console.WriteLine($"The user has won {percentWon} percent of the game and lost {percentLost} percent.");
                            Console.ReadLine();
                            break;
                        }

                    case 3:
                        {
                            check = false;
                            break;
                        }
                }
            }
        }
    }
}
