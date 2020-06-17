using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Helpers
{
    public class GetStudentsHelper
    {
        public static List<Student> GetAllStudents()
        {
            var vaska = new Student()
            {
                Username = "Vaska123",
                Password = "123"

            };

            var maja = new Student()
            {
                Username = "Maja123",
                Password = "456"
            };

            var dime = new Student()
            {
                Username = "Dime123",
                Password = "789"
            };

            var ilija = new Student()
            {
                Username = "Ilija123",
                Password = "357"

            };

            var viktor = new Student()
            {
                Username = "Viktor123",
                Password = "697"
            };

            var darko = new Student()
            {
                Username = "Darko123",
                Password = "173"
            };

            return new List<Student>() { vaska, maja, dime, ilija, viktor, darko };
            
        }

        
    }
}
