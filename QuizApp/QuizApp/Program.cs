using System;
using QuizApp.Entities;
using QuizApp.Helpers;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetStudentsHelper.GetAllStudents();
            GetTeachersHelper.GetAllTeachers();
            bool check = true;

            while (check)
            {
                Console.WriteLine("Please log in.");

                int teacherOrStudent = 0;
                int timesTried = 0;
                bool isLogged = false;
                Student loggedStudent = null;
                while (isLogged == false && timesTried<3)
                {
                    Console.Write("Username: ");
                    var userInput = Console.ReadLine();
                    Console.Write("Password: ");
                    var passInput = Console.ReadLine();
                    foreach (var student in Student.AllStudents)
                    {
                        if (userInput == student.Username)
                        {
                            if (passInput == student.Password)
                            {
                                Console.WriteLine($"You are logged in as student: {student.Username}");
                                teacherOrStudent = 2;
                                loggedStudent = student;
                                isLogged = true;
                            }
                        }
                        
                    }

                    foreach (var teacher in Teacher.AllTeachers)
                    {
                        if (userInput == teacher.Username)
                        {
                            if (passInput == teacher.Password)
                            {
                                Console.WriteLine($"You are logged in as teacher: {teacher.Username}");
                                teacherOrStudent = 1;
                                isLogged = true;
                            }
                        }
                    }
                    timesTried++;

                    if (isLogged == false)
                    {
                        Console.WriteLine("Please enter valid username and password.");
                    }
                    
                }

                switch (teacherOrStudent)
                {
                    case 1:
                        foreach (var student in Student.AllStudents)
                        {
                            if (student.TookQuiz == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(student.Username);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(student.Username);
                                Console.ResetColor();
                            }
                        }
                        break;

                    case 2:
                        {
                            if (loggedStudent.TookQuiz)
                            {
                                Console.WriteLine("You already took the quiz!");
                                break;
                            }
                            
                            int[] answers = new int[5];
                            Console.WriteLine("Please enter the number next to your answer after each question.");
                            Console.WriteLine("Q: What is the capital of Tasmania ?\r\n1 : Dodoma \r\n2 : Hobart\r\n3 : Launceston \r\n4 : Wellington");
                            var inputAnswer1 = Console.ReadLine();
                            int.TryParse(inputAnswer1, out answers[0]);
                            Console.WriteLine("Q: What is the tallest building in the Republic of the Congo? \r\n1 : Kinshasa Democratic Republic of the Congo Temple \r\n2 : Palais de la Nation\r\n3 : Kongo Trade Centre \r\n4 : Nabemba Tower");
                            var inputAnswer2 = Console.ReadLine();
                            int.TryParse(inputAnswer2, out answers[1]);
                            Console.WriteLine("Q: Which of these is not one of Pluto's moons?\r\n1 : Styx\r\n2 : Hydra\r\n3 : Nix\r\n4 : Lugia");
                            var inputAnswer3 = Console.ReadLine();
                            int.TryParse(inputAnswer3, out answers[2]);
                            Console.WriteLine("Q: What is the smallest lake in the world? \r\n1 : Onega Lake\r\n2 : Benxi Lake\r\n3 : Kivu Lake\r\n4 : Wakatipu Lake");
                            var inputAnswer4 = Console.ReadLine();
                            int.TryParse(inputAnswer4, out answers[3]);
                            Console.WriteLine("Q: What country has the largest population of alpacas?  \r\n1 : Chad\r\n2 : Peru\r\n3 : Australia\r\n4 : Niger");
                            var inputAnswer5 = Console.ReadLine();
                            int.TryParse(inputAnswer5, out answers[4]);

                            loggedStudent.Score = AnswerCheck.Grade(answers);
                            Console.WriteLine($"Your grade is: {loggedStudent.Score}");
                            loggedStudent.TookQuiz = true;
                        }
                        break;

                    default:
                        Console.WriteLine("You tried to log in with incorrect username and password more than 3 times.");
                        check = false;
                        break;
                }
            }
        }
    }
}