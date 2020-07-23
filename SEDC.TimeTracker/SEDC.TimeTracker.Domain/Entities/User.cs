using SEDC.TimeTracker.Domain.Enums;
using SEDC.TimeTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Entities
{
    public class User : BaseEntity, IUser
    {
        public User()
        {
            Status = AccountStatus.Active;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountStatus Status { get; set; }
        public List<Reading> ReadingSessions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Working> WorkingSessions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Exercising> ExercisingSessions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Hobbies> AllHobbbies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        
    }
}
