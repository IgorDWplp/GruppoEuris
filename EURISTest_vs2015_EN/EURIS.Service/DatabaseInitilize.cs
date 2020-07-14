using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities.Model;
using System.Data.Entity;

namespace EURIS.Service
{
   public class DatabaseInitilize : DropCreateDatabaseAlways<DbContextApp>
    {
        protected override void Seed(DbContextApp context)
        {
            IList<ProductE> incjetData = new List<ProductE>();


          //incjetData.Add(new ProductE() {  catalog = , Description="opis", Code});


            context.ProductsE.AddRange(incjetData);

            base.Seed(context);
        }

    }
}
