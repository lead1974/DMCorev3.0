using DMCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMCore.DataAccess.Data.Repository.IRepository
{
    public interface IDealCategoryRepository : IRepository<DealCategory>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(DealCategory category);
    }
}
