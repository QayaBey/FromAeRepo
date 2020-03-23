using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectFromAeWebsite.Models;

namespace FinalProjectFromAeWebsite.Models
{
    public class FromAeDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public FromAeDbContext(DbContextOptions options) : base(options)
        {

        }
       public  DbSet<Category> Categories { get; set; }
       public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public  DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public  DbSet<Property> Properties { get; set; }
        public  DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Istifadeciler> Istifadecilers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
            builder.Entity<ProductProperty>().HasKey(x => new { x.PropertyId, x.ProductId });
            builder.Entity<ProductCategory>().HasOne(x => x.Product).WithMany(x => x.ProductCategories);
            builder.Entity<ProductCategory>().HasOne(x => x.Category).WithMany(x => x.ProductCategories);
            builder.Entity<ProductProperty>().HasOne(x => x.Product).WithMany(x => x.ProductProperties);
            builder.Entity<ProductProperty>().HasOne(x => x.Property).WithMany(x => x.ProductProperties);

            builder.Entity<Menu>().HasData(
                new Menu {Id=1,Name="ELEKTRONİKA",Link="#"},
                new Menu {Id=2,Name="KOMPÜTERLƏR",Link="#"},
                new Menu {Id=3,Name="OYUNLAR",Link="#"},
                new Menu {Id=4,Name= "FOTO VƏ VİDEO", Link="#"},
                new Menu {Id=5,Name= "MƏİŞƏT AVADANLIQLARI", Link="#"},
                new Menu {Id=6,Name= "PARFÜM VƏ KOSMETİKA", Link="#"},
                new Menu {Id=7,Name= "EV ƏŞYALARI", Link="#"}
            );
            builder.Entity<SubMenu>().HasData(
                new SubMenu { Id =1,Name="Telefonlar",Link="#",MenuId=1},
                new SubMenu { Id =2,Name="Mobil aksessuarlar",Link="#",MenuId=1},
                new SubMenu { Id =3,Name="TV və audio",Link="#",MenuId=1},

                new SubMenu { Id =4,Name="Kompüter",Link="#",MenuId=2},
                new SubMenu { Id =5,Name="Periferiya qurğuları",Link="#",MenuId=2},
                new SubMenu { Id =6,Name="Kompüter ehtiyyat hissələri",Link="#",MenuId=2},
                new SubMenu { Id =7,Name="Tabletlər üçün üzlüklər və qapaqlar",Link="#",MenuId=2},
                new SubMenu { Id =8,Name="Şəbəkə Avadanlığı",Link="#",MenuId=2},


                new SubMenu { Id =9,Name="Oyun",Link="#",MenuId=3},

                new SubMenu { Id =10,Name="Foto",Link="#",MenuId=4},

                new SubMenu { Id =11,Name="Mətbəx Avadanlıqları",Link="#",MenuId=5},
                new SubMenu { Id =12,Name="Məişət Avadanlıqları",Link="#",MenuId=5},
                new SubMenu { Id =13,Name="Gözəllik Məhsulları",Link="#",MenuId=5},

                new SubMenu { Id =14,Name= "Ətriyyat", Link="#",MenuId=6},
                new SubMenu { Id =15,Name= "Beauty & Health", Link="#",MenuId=6},

                new SubMenu { Id =16,Name= "BTekstil", Link="#",MenuId=7},
                new SubMenu { Id =17,Name= "Koridor", Link="#",MenuId=7},
                new SubMenu { Id =18,Name= "Hamam otağı", Link="#",MenuId=7},
                new SubMenu { Id =19,Name= "Qab-qacaq", Link="#",MenuId=7},
                new SubMenu { Id =20,Name= "Camaşırxana", Link="#",MenuId=7}
                );
            base.OnModelCreating(builder);

        }
        public DbSet<FinalProjectFromAeWebsite.Models.Picture> Pictures { get; set; }
    }
}
