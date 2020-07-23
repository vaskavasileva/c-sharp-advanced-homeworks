using SEDC.TimeTracker.Domain.Entities;
using SEDC.TimeTracker.Domain.Enums;
using SEDC.TimeTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SEDC.TimeTracker.Services.Services
{
    public class TrackServices<T> : ITrackServices<T> where T : Activities
    {
        public int TrackActivity()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Please press Enter when you want to start tracking.");
            Console.ReadLine();
            stopwatch.Start();
            Console.WriteLine("Please press Enter when you want to finish tracking.");
            Console.ReadLine();
            stopwatch.Stop();
            var timeTracked = stopwatch.Elapsed;
            stopwatch.Reset();
            return timeTracked.Minutes;
        }

        public void TrackExercising(int time, User user)
        {
            while (true)
            {
                Console.WriteLine("Please select the type of exercise: ");
                string[] exercisingTypes = Enum.GetNames(typeof(ExercisingType));
                for (int i = 0; i < exercisingTypes.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {exercisingTypes[i]}");
                }
                var input = Console.ReadLine();
                int.TryParse(input, out int answer);
                if (answer == 1 || answer == 2 || answer == 3)
                {
                    var exercising = new Exercising()
                    {
                        Type = (ExercisingType)answer,
                        SessionTime = time
                    };
                    user.ExercisingSessions.Add(exercising);
                    break;
                }
                Console.WriteLine("Please choose a valid type.");
            }
            

        }

        public void TrackHobbies(int time, User user)
        {
            Console.WriteLine("Please enter a name of your hobby: ");
            var hobbyName = Console.ReadLine();
            var hobby = new Hobbies()
            {
                Name = hobbyName,
                SessionTime = time
            };
            user.AllHobbbies.Add(hobby);
        }

        public void TrackReading(int time, User user)
        {
            int pages = 0;
            while (true)
            {
                Console.WriteLine("Please enter how many pages you have read:");
                var input = Console.ReadLine();
                bool check = int.TryParse(input, out pages);
                if (check)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid number.");
            }
            
            while (true)
            {
                Console.WriteLine("Please select the type of book: ");
                string[] readingTypes = Enum.GetNames(typeof(ReadingType));
                for (int i = 0; i < readingTypes.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {readingTypes[i]}");
                }
                var input = Console.ReadLine();
                int.TryParse(input, out int answer);
                if (answer == 1 || answer == 2 || answer == 3)
                {
                    var reading = new Reading()
                    {
                        Type = (ReadingType)answer,
                        Pages = pages,
                        SessionTime = time
                    };
                    user.ReadingSessions.Add(reading);
                    break;
                }
                Console.WriteLine("Please choose a valid type.");
            }
        }

        public void TrackWorking(int time, User user)
        {
            while (true)
            {
                Console.WriteLine("Please select the place of working: ");
                string[] workingPlaces = Enum.GetNames(typeof(WorkingPlace));
                for (int i = 0; i < workingPlaces.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {workingPlaces[i]}");
                }
                var input = Console.ReadLine();
                int.TryParse(input, out int answer);
                if (answer == (int)WorkingPlace.Home)
                {
                    var working = new Working()
                    {
                        Place = WorkingPlace.Home,
                        SessionTime = time
                    };
                    user.WorkingSessions.Add(working);
                    break;
                }
                if (answer == (int)WorkingPlace.Office)
                {
                    var working = new Working()
                    {
                        Place = WorkingPlace.Office,
                        SessionTime = time
                    };
                    user.WorkingSessions.Add(working);
                    break;
                }
                Console.WriteLine("Please choose a valid type.");
            }
        }
    }
}
