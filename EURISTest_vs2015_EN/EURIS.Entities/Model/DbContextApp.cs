using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EURIS.Entities.Model
{
   public class DbContextApp : DbContext
    {
<<<<<<< HEAD
        public DbContextApp() : base("name=cc")
        {
        }

        public DbSet<Product> products { get; set; }
        public object Product { get; set; }
    }
}
=======
        public DbContextApp() : base("name=LocalDb")
        {
            Database.SetInitializer<DbContextApp>(new DropCreateDatabaseAlways<DbContextApp>());
            Database.SetInitializer(new ProductInitializer());
        }
        public DbSet<ProductE> ProductsE { get; set; }
        public DbSet<CatalogProductsE> catalogProductEs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductE>().HasKey<int>(x => x.Id);
        //    modelBuilder.Entity<CatalogProductsE>().HasKey<int>(x => x.Id);

        //    //modelBuilder.Entity<CatalogProductsE>().HasOptional(j => j.ProductEs).WithMany().WillCascadeOnDelete(true);
        //    //base.OnModelCreating(modelBuilder);
        //}
    }
}

>>>>>>> 4f8ea5ee0fbd413be3d7a34ca858837f69d04581
