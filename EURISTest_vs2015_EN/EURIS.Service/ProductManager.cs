using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities;
using System.Data.Entity;
using EURIS.Entities.Model;

namespace EURIS.Service
{
    public class ProductManager
    {
       // LocalDbEntities context = new LocalDbEntities();
        DbContextApp DbContextApp = new DbContextApp();

        public List<Entities.Model.Product> GetProducts()
        {
            List<Entities.Model.Product> products = new List<Entities.Model.Product>();
            
            products = (from item in DbContextApp.products
                        select item).ToList();

            return products;
        }
    }
}
