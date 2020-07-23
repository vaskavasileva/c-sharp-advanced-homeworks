using SEDC.TimeTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Services.Interfaces
{
    public interface ITrackServices<T> where T : Activities
    {
        int TrackActivity();
        void TrackReading(int time, User user);
        void TrackWorking(int time, User user);
        void TrackExercising(int time, User user);
        void TrackHobbies(int time, User user);
    }
}
