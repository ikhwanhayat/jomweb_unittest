using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Infra
{
    public class EFRepository : IRepository, IDisposable
    {
        BankDataContext db = null;

        public EFRepository(string connectionString)
        {
            db = new BankDataContext(connectionString);
        }

        public T Get<T>(object id) where T: class
        {
            return db.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return db.Set<T>();
        }

        public void Create(object entity)
        {
            db.Set(entity.GetType()).Add(entity);
            db.SaveChanges();
        }

        public void Update(object entity)
        {
            db.Entry(entity).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}