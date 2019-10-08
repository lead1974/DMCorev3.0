using DMCore.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMCore.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            DealCategory = new DealCategoryRepository(_db);
            //ApplicationUser = new ApplicationUserRepository(_db);
        }

        public IDealCategoryRepository DealCategory { get; private set; }

        //ublic IApplicationUserRepository ApplicationUser { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
