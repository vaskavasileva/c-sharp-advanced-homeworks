using SEDC.TimeTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Domain.DB
{
    public interface IDb<T> where T : BaseEntity
    {
        List<T> GetAll();
        void Insert(T entity);
        
        
    }
}
