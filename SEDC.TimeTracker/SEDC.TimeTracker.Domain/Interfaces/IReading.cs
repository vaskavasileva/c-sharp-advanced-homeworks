using SEDC.TimeTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Interfaces
{
    public interface IReading
    {
        public int Pages { get; set; }
        public ReadingType Type { get; set; }
        
    }
}
