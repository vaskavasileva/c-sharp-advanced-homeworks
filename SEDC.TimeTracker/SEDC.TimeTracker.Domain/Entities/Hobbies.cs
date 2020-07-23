using SEDC.TimeTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.Entities
{
    public class Hobbies : Activities, IHobbies
    {
        public string Name { get; set; }
       
    }
}
