using SEDC.TimeTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Interfaces
{
    public interface IWorking
    {
        public WorkingPlace Place { get; set; }
        
    }
}
