using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace FavoDeMel.Infra.EF.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FavoDeMelContext _context;

        public UnitOfWork(FavoDeMelContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.StackTrace);
            }
            catch (ValidationException ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}