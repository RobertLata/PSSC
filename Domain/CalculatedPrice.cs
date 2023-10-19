using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1.Domain
{
    public record CalculatedPrice(ProductCodeValidation code, ProductQuantityValidation quantity, double totalPrice, double price = 5.0);
}
