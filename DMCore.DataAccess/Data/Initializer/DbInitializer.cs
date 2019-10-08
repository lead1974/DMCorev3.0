using DMCore.DataAccess.Data.Repository.IRepository;
using DMCore.Models;
using DMCore.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMCore.DataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(IUnitOfWork unitOfWork, ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public void Initialize()
        {
            SeedAdminUsers();
            SeedDealCategories();
            SeedStores();
            SeedDeals();
            SeedCoupons();
            SeedAffiliateSites();
        }

        //Seed Admin Users
        private void SeedAdminUsers()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
            }

            if (_db.Roles.Any(r => r.Name == SD.AdminRole)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.DealManagerRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.BlogManagerRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.UserL1Role)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.UserL2Role)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.UserL3Role)).GetAwaiter().GetResult();


            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "email2lead@gmail.com",
                Email = "email2lead@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserLevel = SD.UserL3Role,
                FirstName = "Andrey",
                LastName = "Parahnevich"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUser.Where
                (u => u.Email == "email2lead@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(user, SD.AdminRole).GetAwaiter().GetResult();
        }

        private void SeedDealCategories()
        {
            int dealCategoriesCount = _unitOfWork.DealCategory.GetCount();

            if (dealCategoriesCount == 0)
            {
                var dCategories = new DealCategory[] {
                new DealCategory
                {

                    Name = "Autos",
                    ShortName = "Autos",
                    Status = SD.StatusActive,
                    SortSeq = 1,
                    FAIcon="fas fa-car",
                    PublicCategory = true,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Entertainment",
                    ShortName = "Entertainment",
                    Status = SD.StatusActive,
                    SortSeq = 2,
                    FAIcon="fas fa-theater-masks",
                    PublicCategory = true,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Books & Magazines",
                    ShortName = "Books",
                    SortSeq = 2,
                    FAIcon="fas fa-book-reader",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Children",
                    ShortName = "Children",
                    SortSeq = 2,
                    FAIcon="fas fa-child",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Clothing & Accessories",
                    ShortName = "Apparel",
                    SortSeq = 2,
                    FAIcon="fas fa-luggage-cart",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Computers & Accessories",
                    ShortName = "Computers",
                    SortSeq = 2,
                    FAIcon ="fas fa-laptop-code",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Education",
                    ShortName = "Education",
                    SortSeq = 2,
                    FAIcon="fas fa-user-graduate",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Credit Cards",
                    ShortName = "Finance",
                    SortSeq = 2,
                    FAIcon="fas fa-piggy-bank",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Flowers & Gifts",
                    ShortName = "Flowers",
                    SortSeq = 2,
                    FAIcon="fas fa-gift",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Freebies",
                    ShortName = "Freebies",
                    SortSeq = 2,
                    FAIcon="fas fa-hand-holding-usd",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Grocery",
                    ShortName = "Grocery",
                    SortSeq = 2,
                    FAIcon="fas fa-shopping-cart",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },

                new DealCategory
                {

                    Name = "Health & Beauty",
                    ShortName = "Health",
                    SortSeq = 2,
                    FAIcon="fas fa-medkit",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Home & Home Improvement",
                    ShortName = "Home",
                    SortSeq = 2,
                    FAIcon="fas fa-home",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Jewerly & Watches",
                    ShortName = "Jewerly",
                    SortSeq = 2,
                    FAIcon="far fa-clock",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },

                new DealCategory
                {

                    Name = "Office & School Supplies",
                    ShortName = "Office",
                    SortSeq = 2,
                    FAIcon="far fa-clipboard",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Pets",
                    ShortName = "Pets",
                    SortSeq = 2,
                    FAIcon="fas fa-paw",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Phones & Accessories",
                    ShortName = "Phones",
                    SortSeq = 2,
                    FAIcon="fas fa-phone",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Restaurants",
                    ShortName = "Restaurants",
                    SortSeq = 2,
                    FAIcon="fas fa-wine-bottle",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Services",
                    ShortName = "Services",
                    SortSeq = 2,
                    FAIcon="fas fa-shipping-fast",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {
                    Name = "Shoes",
                    ShortName = "Shoes",
                    SortSeq = 2,
                    FAIcon="fas fa-shoe-prints",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Sports & Outdoors",
                    ShortName = "Sports",
                    SortSeq = 2,
                    FAIcon="fas fa-football-ball",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Tech & Electronics",
                    ShortName = "Electronics",
                    SortSeq = 2,
                    FAIcon="fab fa-android",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Toys",
                    ShortName = "Toys",
                    SortSeq = 2,
                    FAIcon="fas fa-dove",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Travel and Vacations",
                    ShortName = "Travel",
                    SortSeq = 2,
                    FAIcon="fas fa-umbrella-beach",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "Other",
                    ShortName = "Other",
                    SortSeq = 999,
                    FAIcon="fas fa-yin-yang",
                    PublicCategory = true,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
                new DealCategory
                {

                    Name = "General Store",
                    ShortName = "General",
                    SortSeq = 888,
                    FAIcon="fas fa-shopping-cart",
                    PublicCategory = false,
                    Status = SD.StatusActive,
                    UpdatedTS= DateTime.UtcNow,
                    UpdatedBy="System",
                    CreatedTS= DateTime.UtcNow,
                    CreatedBy="System"
                },
            };

                _unitOfWork.DealCategory.AddRange(dCategories);
                _unitOfWork.Save();
            }
        }
        private void SeedStores()
        {
        }
        private void SeedDeals()
        {
        }
        private void SeedCoupons()
        {
        }
        private void SeedAffiliateSites()
        {
        }
    }
}
