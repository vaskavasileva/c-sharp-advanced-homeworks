using SEDC.TimeTracker.Domain.Enums;
using SEDC.TimeTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Entities
{
    public class Exercising : Activities, IExercising
    {
        public Exercising()
        {
            TypesExercised.Add(Type);
        }
        public ExercisingType Type { get; set; }
        public List<ExercisingType> TypesExercised { get; set; }

        
    }
}
