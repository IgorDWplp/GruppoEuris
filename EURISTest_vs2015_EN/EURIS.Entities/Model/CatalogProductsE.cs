using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.Entities.Model
{
   public class CatalogProductsE
    {
        [Key]
        public int Id { get; set; }

        public string Code {get; set;}

        public string Description { get; set; }

        //public ICollection<ProductE> ProductEs { get; set; }
    }
}
