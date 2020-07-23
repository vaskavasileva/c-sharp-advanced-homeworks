using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Interfaces
{
    public interface IActivities
    {
        public int SessionTime { get; set; }
        public List<int> PastSessions { get; set; }
        public int TotalTime { get; set; }
    }
}
