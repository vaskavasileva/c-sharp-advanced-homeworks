using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Helpers
{
    public class GetTeachersHelper
    {
        public static List<Teacher> GetAllTeachers()
        {
            var ivan = new Teacher()
            {
                Username = "Ivan456",
                Password = "987"
            };

            var ivo = new Teacher()
            {
                Username = "Ivo456",
                Password = "654"
            };

            var goce = new Teacher()
            {
                Username = "Goce456",
                Password = "321"
            };

            var miodrag = new Teacher()
            {
                Username = "Miodrag456",
                Password = "209"
            };

            return new List<Teacher>() { ivan, ivo, goce, miodrag };
        }
    }
}
