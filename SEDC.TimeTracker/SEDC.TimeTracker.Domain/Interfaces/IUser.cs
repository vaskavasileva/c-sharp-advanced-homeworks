using SEDC.TimeTracker.Domain.Entities;
using SEDC.TimeTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Interfaces
{
    public interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountStatus Status { get; set; }
        public List<Reading> ReadingSessions { get; set; }
        public List<Working> WorkingSessions { get; set; }
        public List<Exercising> ExercisingSessions { get; set; }
        public List<Hobbies> AllHobbbies { get; set; }
    }
}
