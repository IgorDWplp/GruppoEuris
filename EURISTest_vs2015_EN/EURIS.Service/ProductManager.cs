using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EURIS.Entities.Model;

namespace EURIS.Service
{
    public class ProductManager
    {

        #region orginal code + extra features CRUD
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

        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"></param>
        public bool UpdateProduct(Product product)
        {
            var FindProduct = context.Product.Find(product.Id);
            if(FindProduct != null)
            {
                FindProduct.Code = product.Code;
                FindProduct.Description = product.Description;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Product product)
        {
            var FindProduct = context.Product.Where(a => a.Id == product.Id).First();
            if (FindProduct != null)
            {
                context.Product.Remove(FindProduct);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion


        #region seed for orginal

       public void Seed(LocalDbEntities context)
        {

      
            Product product1 = new Product()
            {
                Code = "code1",
                Description = "Opis prvog",
                Id = 0
            };

            Product product2 = new Product()  {
                Code = "code2",
                Description = "Opis drugog ",
                Id = 1 
            };

            Product product3 = new Product  {
                Code = "code 3", Description = "", Id = 2
            };


            context.Product.Add(product1);
            context.Product.Add(product2);
            context.Product.Add(product3);

            context.SaveChanges();

          
        }

       
        #endregion
    }
}
