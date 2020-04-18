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

        #region orginal code + extra features
        LocalDbEntities context = new LocalDbEntities(); 

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            
            products = (from item in context.Product
                        select item).ToList();

            return products;
        }

        /// <summary>
        /// rješavamo problem s autoincrement u DB pošto je bug u EF 5
        /// </summary>
        /// <returns></returns>
        public int GetLastProduct_ID()
        {
            List<Product> products = new List<Product>();
            products = (from item in context.Product
                        select item).ToList();
    
            if (products.Count > 0)
            {
                return products.LastOrDefault().Id;
            }
            else
                return 0;
        }

        /// <summary>
        /// create new product
        /// </summary>
        /// <param name="product"></param>
        public void CreateNew(Product product)
        {
            var primary_key = GetLastProduct_ID();
            product.Id = primary_key + 1;
            context.Product.Add(product);
            context.SaveChanges();
        }


        /// <summary>
        /// get one product
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product GetProduct(int Id)
        {
           // var pro = context.Product.Where(pr => pr.Id == Id).FirstOrDefault();
            var product = context.Product.Find(Id);
            return product;
        }


        #endregion
    }
}
