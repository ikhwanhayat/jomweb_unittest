using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Infra
{
    public interface IRepository
    {
        T Get<T>(object id) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void Create(object acc);
        void Update(object acc);
    }
}