using SEDC.TimeTracker.Domain.Entities;
using SEDC.TimeTracker.Services.Helpers;
using SEDC.TimeTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Services.Services
{
    public class UIServices : IUIServices
    {
        public List<string> AccountManagementMenuItems { get; set; }
        public List<string> LogInMenuItems { get; set; }
        public List<string> MainMenuItems { get; set; }
        public List<string> StatisticsMenuItems { get; set; }
        public List<string> TrackMenuItems { get; set; }

        public void Welcome(User user)
        {
            Console.WriteLine($"Welcome to the application {user.FirstName} {user.LastName}");
        }
        public int ChooseFromMenu<T>(List<T> items)
        {
            while (true)
            {
                Console.WriteLine("Enter a number to choose an option: ");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {items[i]}");
                }
                string userChoice = Console.ReadLine();
                int choice = ValidationHelpers.NumberValidation(userChoice, items.Count);
                if (choice == -1)
                {
                    MessageHelpers.ErrorMessage("Incorrect input");
                    continue;
                }
                return choice;
            }
        }

        public int AccountManagementMenu()
        {
            AccountManagementMenuItems = new List<string>() { "Change Password", "Change First Name", "Change Last Name", "Deactivate Account", "Back To Main Menu" };
            return ChooseFromMenu(AccountManagementMenuItems);
        }

        

        public int LogInMenu()
        {
            LogInMenuItems = new List<string>() { "Log in", "Register"};
            return ChooseFromMenu(LogInMenuItems);
        }

        public int MainMenu()
        {
            MainMenuItems = new List<string>() { "Track", "User Statistics", "Account Management", "Log out" };
            return ChooseFromMenu(MainMenuItems);
        }

        public int StatisticsMenu()
        {
            StatisticsMenuItems = new List<string>() { "Reading", "Exercising", "Working", "Hobbies", "Global", "Back To Main Menu" };
            return ChooseFromMenu(StatisticsMenuItems);
        }

        public int TrackMenu()
        {
            TrackMenuItems = new List<string>() { "Reading", "Exercising", "Working", "Hobbies", "Back To Main Menu" };
            return ChooseFromMenu(TrackMenuItems);
        }

        
    }
}
