using System;
using System.Collections.Generic;
using System.Text;

namespace DMCore.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IDealCategoryRepository DealCategory { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
