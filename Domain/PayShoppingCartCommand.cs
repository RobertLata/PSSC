using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1.Domain
{
    public record PayShoppingCartCommand
    {

        public PayShoppingCartCommand(IReadOnlyCollection<UnvalidatedProduct> inputShoppingCart)
        {
            InputShoppingCart = inputShoppingCart;
        }

        public IReadOnlyCollection<UnvalidatedProduct> InputShoppingCart { get; }
    }
}
