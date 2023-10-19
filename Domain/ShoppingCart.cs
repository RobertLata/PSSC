using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1.Domain
{
    public class ShoppingCart
    {
        public Client Client { get; set; }
        public List<UnvalidatedProduct> Products { get; set; }

    }
}
