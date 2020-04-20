using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EURIS.Entities.Model
{
  public  class SeedDB : DropCreateDatabaseIfModelChanges<LocalDbEntities>
    {

        public void SeedData(LocalDbEntities context)
        {

            Product product1 = new Product()
            {
                Code = "code1",
                Description = "Opis prvog",
                Id = 0
            };

            Product product2 = new Product()
            {
                Code = "code2",
                Description = "Opis drugog ",
                Id = 1
            };

            Product product3 = new Product
            {
                Code = "code 3",
                Description = "",
                Id = 2
            };


            context.Product.Add(product1);
            context.Product.Add(product2);
            context.Product.Add(product3);

            context.SaveChanges();
        }

        protected override void Seed(LocalDbEntities context)
        {

            Product product1 = new Product()
            {
                Code = "code1",
                Description = "Opis prvog",
                Id = 0
            };

            Product product2 = new Product()
            {
                Code = "code2",
                Description = "Opis drugog ",
                Id = 1
            };

            Product product3 = new Product
            {
                Code = "code 3",
                Description = "",
                Id = 2
            };


            context.Product.Add(product1);
            context.Product.Add(product2);
            context.Product.Add(product3);

            context.SaveChanges();
        }
    }
}
