using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities;
using System.Data.Entity;

namespace EURIS.Service
{
    public class ProductManager
    {
        LocalDbEntities context = new LocalDbEntities(); 

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            
            products = (from item in context.Product
                        select item).ToList();

            return products;
        }
    }
}
