using SEDC.TimeTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Entities
{
    public abstract class Activities : BaseEntity, IActivities
    {
        public int SessionTime { get; set; }
        public int TotalTime { get; set; }
        public List<int> PastSessions { get; set; }
    }
}
