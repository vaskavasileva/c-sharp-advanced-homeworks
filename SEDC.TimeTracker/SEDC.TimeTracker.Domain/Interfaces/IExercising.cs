using SEDC.TimeTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Interfaces
{
    public interface IExercising
    {
        public ExercisingType Type { get; set; }

    }
}
