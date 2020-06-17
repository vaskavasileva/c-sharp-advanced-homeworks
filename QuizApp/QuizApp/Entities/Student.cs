using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Entities
{
    public class Student : User
    {
        public Student()
        {
            AllStudents.Add(this);
        }
        public static List<Student> AllStudents { get; set; } = new List<Student>();
        public int Score { get; set; }
        public bool TookQuiz { get; set; } = false;
        
    }
}
