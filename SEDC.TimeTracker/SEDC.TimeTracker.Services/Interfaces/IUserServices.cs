using SEDC.TimeTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Services.Interfaces
{
    public interface IUserServices
    {
        User LogIn(string username, string password);
        User Register(User user);
        void ChangePassword(int id, string oldPassword, string newPassword);
        void ChangeFirstName(User user, string newFirstName);
        void ChangeLastName(User user, string newLastName);
        void DeactivateAccount(User user);
    }
}
