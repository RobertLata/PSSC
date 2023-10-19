using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1.Domain
{
    public record ValidatedProduct(ProductCodeValidation productCode, ProductQuantityValidation productQuantity, double price = 5.0);

}
