using SEDC.TimeTracker.Domain.Enums;
using SEDC.TimeTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Entities
{
    public class Working : Activities, IWorking
    {
        
        public WorkingPlace Place { get; set; }
        
    }
}
