﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace rcDbSqlServerEF
{
    public abstract class DataEF
    {
        protected readonly ManagerDbContext _context;

        public DataEF(ManagerDbContext context)
        {
            this._context = context;
        }

        public void Save()
        {
            this._context.SaveChanges();

            foreach (EntityEntry entry in this._context.ChangeTracker.Entries()) {
                entry.State = EntityState.Detached;
            }
        }

        public void Cancel()
        {
            foreach (EntityEntry entry in this._context.ChangeTracker.Entries()) {
                entry.State = EntityState.Detached;
            }
        }
    }
}
