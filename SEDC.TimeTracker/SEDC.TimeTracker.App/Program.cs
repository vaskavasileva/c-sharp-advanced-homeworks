using System;
using System.IO;
using System.Linq;
using SEDC.TimeTracker.Domain.Entities;
using SEDC.TimeTracker.Domain.Enums;
using SEDC.TimeTracker.Services.Helpers;
using SEDC.TimeTracker.Services.Services;
using Newtonsoft.Json;

namespace SEDC.TimeTracker.App
{
    class Program
    {
        public static UIServices _uiServices = new UIServices();
        public static UserServices _userServices = new UserServices();
        public static TrackServices<Activities> _trackServices = new TrackServices<Activities>();
        
        public static User _loggedUser;

        public static string _folderPath = Directory.GetCurrentDirectory();
        public static string _filePath = Path.Combine(_folderPath, "Users.json");

        public static void Seed()
        {
            _userServices.Register(new User()
            { FirstName = "John", LastName = "Doe", Age = 30, Username = "John123", Password = "John123" });
            _userServices.Register(new User()
            { FirstName = "Jane", LastName = "Doe", Age = 25, Username = "Jane456", Password = "Jane456" });
        }
        static void Main(string[] args)
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    while (true)
                    {
                        var lineToConvert = sr.ReadLine();
                        if (lineToConvert == "")
                        {
                            break;
                        }
                        User user = JsonConvert.DeserializeObject<User>(lineToConvert);
                        _userServices.Register(user);
                    }
                    
                };

                File.Delete(_filePath);
            }

            Seed();
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Welcome.");
                if (_loggedUser == null)
                {
                    var choice = _uiServices.LogInMenu();
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Please enter your username: ");
                            var username = Console.ReadLine();
                            Console.WriteLine("Please enter your password: ");
                            var password = Console.ReadLine();
                            _loggedUser = _userServices.LogIn(username, password);
                            if (_loggedUser.Status == AccountStatus.Deactivated)
                            {
                                Console.WriteLine("Your account is deactivated. Do you want to activate it?");
                                while (true)
                                {
                                    var answer = Console.ReadLine();
                                    if (answer == "Yes")
                                    {
                                        _loggedUser.Status = AccountStatus.Active;
                                        break;
                                    }
                                    if (answer == "No")
                                    {
                                        _loggedUser = null;
                                        break;
                                    }
                                    break;
                                }
                                

                            }

                            break;
                        case 2:
                            var user = RegistrationHelper.GetData();
                            _loggedUser = _userServices.Register(user);
                            break;
                    }
                    continue;
                }

                _uiServices.Welcome(_loggedUser);

                Console.Clear();
                int userMainMenuChoice = _uiServices.MainMenu();
                string mainMenuChoice = _uiServices.MainMenuItems[userMainMenuChoice - 1];
                switch (mainMenuChoice)
                {
                    case "Track":
                        Console.WriteLine("What activity do you want to track?");
                        int userTrackChoice = _uiServices.TrackMenu();
                        string trackMenuChoice = _uiServices.TrackMenuItems[userTrackChoice - 1];

                        switch (trackMenuChoice)
                        {
                            case "Reading":
                                int timeReading = _trackServices.TrackActivity();
                                _trackServices.TrackReading(timeReading, _loggedUser);
                                break;
                            case "Exercising":
                                int timeExercising = _trackServices.TrackActivity();
                                _trackServices.TrackExercising(timeExercising, _loggedUser);
                                break;
                            case "Working":
                                int timeWorking = _trackServices.TrackActivity();
                                _trackServices.TrackWorking(timeWorking, _loggedUser);
                                break;
                            case "Hobbies":
                                int timeHobbies = _trackServices.TrackActivity();
                                _trackServices.TrackHobbies(timeHobbies, _loggedUser);
                                break;
                            case "Exit Application":
                                mainMenu = false;
                                break;
                        }
                        break;
                    case "User Statistics":
                        Console.WriteLine("Which activity statistics do you want to see?");
                        int userStatisticsChoice = _uiServices.StatisticsMenu();
                        string statisticsMenuChoice = _uiServices.StatisticsMenuItems[userStatisticsChoice - 1];
                        switch (statisticsMenuChoice)
                        {
                            case "Reading":
                                var totalTimeReading = StatisticsHelper.TotalTime(_loggedUser.ReadingSessions);
                                if (totalTimeReading == 0)
                                {
                                    Console.WriteLine("You have not recorded any reading activity.");
                                    break;
                                }
                                Console.WriteLine($"The total time reading is {totalTimeReading} minutes.");
                                Console.WriteLine($"The average time reading for all sessions is {totalTimeReading / _loggedUser.ReadingSessions.Count} minutes.");
                                int totalPages = 0;
                                foreach (var session in _loggedUser.ReadingSessions)
                                {
                                    totalPages += session.Pages;
                                }
                                Console.WriteLine($"Your total number of pages read is {totalPages}");
                                Console.WriteLine($"Your favorite type is {StatisticsHelper.FavoriteReadingType(_loggedUser)}");
                                break;
                            case "Exercising":
                                var totalTimeExercising = StatisticsHelper.TotalTime(_loggedUser.ExercisingSessions);
                                if (totalTimeExercising == 0)
                                {
                                    Console.WriteLine("You have not recorded any exercising activity.");
                                    break;
                                }
                                Console.WriteLine($"The total time reading is {totalTimeExercising} minutes.");
                                Console.WriteLine($"The average time reading for all sessions is {totalTimeExercising / _loggedUser.ExercisingSessions.Count} minutes.");
                                Console.WriteLine($"Your favorite type is {StatisticsHelper.FavoriteExercisingType(_loggedUser)}");
                                break;
                            case "Working":
                                var totalTimeWorking = StatisticsHelper.TotalTime(_loggedUser.WorkingSessions);
                                if (totalTimeWorking == 0)
                                {
                                    Console.WriteLine("You have not recorded any working activity.");
                                    break;
                                }
                                Console.WriteLine($"The total time reading is {totalTimeWorking} minutes.");
                                Console.WriteLine($"You have spent {StatisticsHelper.TotalTime(_loggedUser.WorkingSessions.Where(x => x.Place == WorkingPlace.Home).ToList())} minutes working at home.");
                                Console.WriteLine($"You have spent {StatisticsHelper.TotalTime(_loggedUser.WorkingSessions.Where(x => x.Place == WorkingPlace.Office).ToList())} minutes working in the office.");
                                break;
                            case "Hobbies":
                                var totalTimeHobbies = StatisticsHelper.TotalTime(_loggedUser.AllHobbbies);
                                if (totalTimeHobbies == 0)
                                {
                                    Console.WriteLine("You have not recorded any hobbies.");
                                    break;
                                }
                                Console.WriteLine($"The total time reading is {totalTimeHobbies} minutes.");
                                Console.WriteLine("The names of all your hobbies are: ");
                                foreach (var name in StatisticsHelper.AllHobbiesNames(_loggedUser))
                                {
                                    Console.WriteLine(name);
                                }
                                break;
                            case "Global":
                                var totalReading = StatisticsHelper.TotalTime(_loggedUser.ReadingSessions);
                                var totalExercising = StatisticsHelper.TotalTime(_loggedUser.ExercisingSessions);
                                var totalWorking = StatisticsHelper.TotalTime(_loggedUser.WorkingSessions);
                                var totalHobbies = StatisticsHelper.TotalTime(_loggedUser.AllHobbbies);
                                var totalTime = totalReading + totalExercising + totalWorking + totalHobbies;
                                if (totalTime == 0)
                                {
                                    Console.WriteLine("You have not recorded any activity.");
                                    break;
                                }
                                var favorite = "Reading";
                                if (totalExercising > totalReading)
                                {
                                    favorite = "Exercising";
                                }
                                if (totalWorking > totalReading && totalWorking > totalExercising)
                                {
                                    favorite = "Working";
                                }
                                if (totalHobbies > totalReading && totalHobbies > totalExercising && totalHobbies > totalWorking)
                                {
                                    favorite = "Hobbies";
                                }
                                Console.WriteLine($"The total time of all activities recorded is {totalTime} minutes.");
                                Console.WriteLine($"According to time spent on each activity your favorite one is {favorite}");
                                break;
                            case "Back To Main Menu":
                                break;
                        }
                        break;
                    case "Account Management":
                        int userAccountManagementChoice = _uiServices.AccountManagementMenu();
                        string accountManagementMenuChoice = _uiServices.AccountManagementMenuItems[userAccountManagementChoice - 1];
                        switch (accountManagementMenuChoice)
                        {
                            case "Change Password":
                                Console.WriteLine("Please enter your current password for validation:");
                                var currentPassword = Console.ReadLine();
                                Console.WriteLine("Please enter your new password:");
                                var newPassword = Console.ReadLine();
                                _userServices.ChangePassword(_loggedUser.Id, currentPassword, newPassword);
                                break;
                            case "Change First Name":
                                Console.WriteLine("Please enter your new First Name:");
                                var newFirstName = Console.ReadLine();
                                _userServices.ChangeFirstName(_loggedUser, newFirstName);
                                break;
                            case "Change Last Name":
                                Console.WriteLine("Please enter your new Last Name:");
                                var newLastName = Console.ReadLine();
                                _userServices.ChangeLastName(_loggedUser, newLastName);
                                break;
                            case "Deactivate Account":
                                _userServices.DeactivateAccount(_loggedUser);
                                break;
                            case "Back To Main Menu":
                                break;
                        }
                        break;
                    case "Log out":
                        _loggedUser = null;
                        break;
                }
            }

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            foreach (var user in _userServices.GetAllUsers())
            {
                string jsonString = JsonConvert.SerializeObject(user);
                using (StreamWriter sw = new StreamWriter(_filePath, true))
                {
                    sw.Write(jsonString);
                }
            }
            
        }

        
            

        
    }
}
