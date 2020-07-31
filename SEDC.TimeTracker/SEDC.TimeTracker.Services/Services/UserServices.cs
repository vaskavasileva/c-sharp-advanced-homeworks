using SEDC.TimeTracker.Domain.DB;
using SEDC.TimeTracker.Domain.Entities;
using SEDC.TimeTracker.Domain.Enums;
using SEDC.TimeTracker.Services.Helpers;
using SEDC.TimeTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.TimeTracker.Services.Services
{
    public class UserServices : IUserServices
    {
        private IDb<User> _db;
        public UserServices()
        {
            _db = new LocalDb<User>();
        }
        public void ChangeFirstName(User user, string newFirstName)
        {
            if (ValidationHelpers.NameValidation(newFirstName) == null)
            {
                MessageHelpers.ErrorMessage("Not a valid first name.");
                return;
            }
            user.FirstName = newFirstName;
        }

        public void ChangeLastName(User user, string newLastName)
        {
            if (ValidationHelpers.NameValidation(newLastName) == null)
            {
                MessageHelpers.ErrorMessage("Not a valid last name.");
                return;
            }
            user.FirstName = newLastName;
        }

        public void ChangePassword(int id, string oldPassword, string newPassword)
        {
            var user = _db.GetAll().SingleOrDefault(user => user.Id == id);
            if (user.Password != oldPassword)
            {
                MessageHelpers.ErrorMessage("Please enter a correct old password.");
                return;
            }
            if (oldPassword == newPassword)
            {
                MessageHelpers.ErrorMessage("New password can not be old password.");
                return;
            }
            if (ValidationHelpers.PasswordValidation(newPassword) == null)
            {
                MessageHelpers.ErrorMessage("Not a valid new password.");
                return;
            }
            user.Password = newPassword;
            MessageHelpers.SuccessMessage("Password successfully changed.");
        }

        public void DeactivateAccount(User user)
        {
            user.Status = AccountStatus.Deactivated;
        }

        public User LogIn(string username, string password)
        {
            User user = _db.GetAll().SingleOrDefault(user => user.Username == username && user.Password == password);
            return user;
        }

        public User Register(User user)
        {
            

            if (ValidationHelpers.UsernameValidation(user.Username) == null || 
                ValidationHelpers.PasswordValidation(user.Password) == null ||
                ValidationHelpers.NameValidation(user.FirstName) == null ||
                ValidationHelpers.NameValidation(user.LastName) == null ||
                ValidationHelpers.AgeValidation(user.Age) == -1)
            {
                return null;
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _db.GetAll();
        }
        
    }
}
