using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EURIS.Entities.Model
{
   public class ProductE
    {
       public int Id { get; set; }
       public string Code { get; set; }
       public string Description { get; set; }

       public int fk_catalogID { get; set; }
       //public CatalogProductsE Catalog { get; set; }
    }
}
