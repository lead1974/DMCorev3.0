using DMCore.DataAccess.Data.Repository.IRepository;
using DMCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMCore.DataAccess.Data.Repository
{
    public class DealCategoryRepository : Repository<DealCategory>, IDealCategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public DealCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.DealCategory.Select(i => new SelectListItem()
            {
                Text = i.ShortName,
                Value = i.Id.ToString()
            });
        }

        public void Update(DealCategory category)
        {
            var objFromDb = _db.DealCategory.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.ShortName = category.ShortName;
            objFromDb.SortSeq = category.SortSeq;
            objFromDb.FAIcon = category.FAIcon;
            objFromDb.PublicCategory = category.PublicCategory;
            objFromDb.Status = category.Status;
            objFromDb.UpdatedTS = category.UpdatedTS;
            objFromDb.UpdatedBy = category.UpdatedBy;

            _db.SaveChanges();

        }
    }
}
