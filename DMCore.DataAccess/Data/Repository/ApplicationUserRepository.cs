using DMCore.DataAccess.Data.Repository.IRepository;
using DMCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMCore.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
