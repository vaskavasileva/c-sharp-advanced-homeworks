using SEDC.TimeTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Services.Interfaces
{
    public interface IUIServices
    {
        void Welcome(User user);
        int LogInMenu();
        int ChooseFromMenu<T>(List<T> items);
        int MainMenu();
        int StatisticsMenu();
        int AccountManagementMenu();
        int TrackMenu();
    }
}
