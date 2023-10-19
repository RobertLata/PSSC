using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1.Domain
{
    public class ProductQuantityValidation
    {
        public static int stock = 20;

        public int Value { get; set; }

        public ProductQuantityValidation(int value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductQuantityException("");
            }
        }

        public double CalculateTotalPrice()
        {
            Product product = new Product();
            double totalPrice = Value * product.ProductPrice;
            return totalPrice;
        }

        private static bool IsValid(int stringValue) => stringValue < stock;


        public static bool TryParse(int intValue, out ProductQuantityValidation productQuantity)
        {
            bool isValid = false;
            productQuantity = null;

            if (IsValid(intValue))
            {
                isValid = true;
                productQuantity = new(intValue);
            }

            return isValid;
        }
    }
}
