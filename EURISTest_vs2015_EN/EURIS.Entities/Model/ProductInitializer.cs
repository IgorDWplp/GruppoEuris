using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.Entities.Model
{
   public class ProductInitializer : DropCreateDatabaseAlways<DbContextApp>
    {
        protected override void Seed(DbContextApp context)
        {

            IList<CatalogProductsE> catalogProductsEs = new List<CatalogProductsE>();

            catalogProductsEs.Add(new CatalogProductsE() { Code = "FR-1", Description = "First product" });
            catalogProductsEs.Add(new CatalogProductsE() { Code = "FR-2", Description = "Second product" });
            context.catalogProductEs.AddRange(catalogProductsEs);

            IList<ProductE> productEs = new List<ProductE>();
            productEs.Add(new ProductE() { Code = "F-TT1", fk_catalogID = 1, Description = "Kikiriki" });
            productEs.Add(new ProductE() { Code = "F-TT2", fk_catalogID = 2, Description = "Mlijeko" });
            productEs.Add(new ProductE() { Code = "F-TT1b", fk_catalogID = 1, Description = "Mlijeko" });
            productEs.Add(new ProductE() { Code = "F-TT1c", fk_catalogID = 1, Description = "Mlijeko" });
            context.ProductsE.AddRange(productEs);
        }
    }
}
