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
        public DbContextApp() : base("name=LocalDb")
        {
            Database.SetInitializer<DbContextApp>(new CreateDatabaseIfNotExists<DbContextApp>());
        }
        public DbSet<ProductE> Products { get; set; }
    }
}
