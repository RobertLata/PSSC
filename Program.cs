using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using tema1.Domain;
using System.Net;

namespace tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            Client roby = new Client
            {
                Name = "Robert",
                Address = "Ale. Sperantei"
            };

            Client edy = new Client
            {
                Name = "Eduard",
                Address = "Bul. Republicii"
            };

            Console.WriteLine("Press Enter twice to stop");
            var listOfProducts = ReadListOfProducts();

            ShoppingCart shoppingCart = new ShoppingCart
            {
                Client = roby,
                Products = listOfProducts
            };

            if (roby.Address != shoppingCart.Client.Address)
            {
                Console.WriteLine("Invalid address!");
                return;
            }

            PayShoppingCartCommand command = new PayShoppingCartCommand(listOfProducts);
            PayShoppingCartWorkflow workflow = new PayShoppingCartWorkflow();

            var result = workflow.Execute(command, productCode => true, quantity => true);

            result.Match(
                whenShoppingCartPaidFailedEvent: @event =>
                {
                    Console.WriteLine($"Failed payment: {@event.Reason}");
                    return @event;
                },
                whenShoppingCartPaidSucceededEvent: @event =>
                {
                    Console.WriteLine($"Successful payment: ");
                    Console.WriteLine(@event.Csv);
                    return @event;
                }
            );
        }

        private static List<UnvalidatedProduct> ReadListOfProducts()
        {
            List<UnvalidatedProduct> listOfProducts = new List<UnvalidatedProduct>();

            while (true)
            {
               var productCode = ReadValue("Product Code: ");
                if (string.IsNullOrEmpty(productCode))
                {
                    break;
                }

                var productQuantity = ReadValue("Product Quantity: ");
                if (int.TryParse(productQuantity, out int productQuantityInt))
                {
                    listOfProducts.Add(new UnvalidatedProduct(productCode, productQuantityInt));
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                }
            }

            return listOfProducts;
        }

        private static string ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
