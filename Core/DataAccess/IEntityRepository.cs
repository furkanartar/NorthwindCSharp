﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess  // namespace : isim uzayı.
{
    // Generic constraint
    // class : referans tip
    // IEntity : T artık ya IEntity olabilir yada IEntity'den implemente edilen bir sınıf olabilir.
    // new() : new'lenebilir olmalı. IEntity' tek başına kullanmak istediğimden (çünkü bir anlamı olmaz) bir kısıt daha ekledim
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity); 
        void Delete(T entity);
    }
}
