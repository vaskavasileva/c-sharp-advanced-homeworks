using SEDC.TimeTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.TimeTracker.Domain.DB
{
    public class LocalDb<T> : IDb<T> where T : BaseEntity
    {
        public int IdCount { get; set; }
        private List<T> db { get; set; } = new List<T>();
        public LocalDb()
        {
            IdCount = 1;
        }
        
        
        public List<T> GetAll()
        {
            return db;
        }

        public void Insert(T entity)
        {
            entity.Id = IdCount;
            db.Add(entity);
            IdCount++;
        }

        

        
    }
}
