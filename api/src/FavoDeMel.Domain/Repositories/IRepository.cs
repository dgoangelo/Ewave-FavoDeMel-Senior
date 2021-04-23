using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FavoDeMel.Domain.Core.Entities;

namespace FavoDeMel.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity entity);
        TEntity GetById(Guid id);
        TEntity Update(TEntity entity);
        void Remove(Guid id);
        IList<TEntity> GetAll();
        IList<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}