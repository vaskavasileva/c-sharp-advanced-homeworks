using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Entities
{
    public class Teacher : User
    {
        public Teacher()
        {
            AllTeachers.Add(this);
        }
        public static List<Teacher> AllTeachers { get; set; } = new List<Teacher>();
        
    }


}
