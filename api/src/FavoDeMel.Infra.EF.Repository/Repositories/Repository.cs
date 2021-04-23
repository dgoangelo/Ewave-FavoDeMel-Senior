using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FavoDeMel.Domain.Core.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly FavoDeMelContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(FavoDeMelContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public virtual IList<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IList<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }
    }
}