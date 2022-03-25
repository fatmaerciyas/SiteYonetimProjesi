﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        void Update(T p);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetFilter(List<T> t, string p);
        void Delete(T p);
        List<T> List(Expression<Func<T, bool>> filter); //filtrelemeye gore liste dondurur
        T GetByID(int id);  
    }
}
