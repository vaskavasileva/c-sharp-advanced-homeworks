using SEDC.TimeTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Services.Helpers
{
    public static class RegistrationHelper
    {
        public static User GetData()
        {
            var user = new User();
            Console.WriteLine("Please enter a first name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter a last name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Please enter a username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("Please enter a password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("Please enter your age: ");
            int.TryParse(Console.ReadLine(), out int age);
            user.Age = age;

            return user;
        }

    }
}
