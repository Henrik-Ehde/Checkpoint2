using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2
{
    internal class ProductList
    {
        List<Product> products = new();

        public void Add(Product product)
        {
            products.Add(product);
        }


        //Prints the list sorted by price from lowest to highest. Also displays the sum of every product's price
        public void PrintSorted()
        {
            List<Product> productsSorted = products.OrderBy(p => p.Price).ToList();

            ColoredText.WriteLine("\n\nPRODUCT LIST", ConsoleColor.Blue);
            Console.WriteLine("Sorted by price");
            ColoredText.WriteLine("CATEGORY:".PadRight(16) + "NAME:".PadRight(16) + "PRICE:", ConsoleColor.Blue);

            foreach (Product product in productsSorted)
            {
                Console.WriteLine(product.Category.PadRight(16) + product.Name.PadRight(16) + product.Price);
            }

            int sum = productsSorted.Sum(p => p.Price);
            ColoredText.WriteLine("".PadRight(16) + "TOTAL: ".PadRight(16) + sum + "\n", ConsoleColor.Magenta);

        }


        //Lets the user search for a string.
        //Displays the list and also highlights any item containing the searched string in the category or name
        public void PrintSearched(string searchString)
        {
            List<Product> productsSorted = products.OrderBy(p => p.Price).ToList();

            searchString = searchString.ToLower();

            ColoredText.WriteLine("\n\nPRODUCT LIST", ConsoleColor.Blue);
            Console.WriteLine("Sorted by price. Sought items are highlighted.");
            ColoredText.WriteLine("CATEGORY:".PadRight(16) + "NAME:".PadRight(16) + "PRICE:", ConsoleColor.Blue);

            foreach (Product product in productsSorted)
            {
                if (product.Name.ToLower().Contains(searchString) || product.Category.ToLower().Contains(searchString))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.WriteLine(product.Category.PadRight(16) + product.Name.PadRight(16) + product.Price);
                Console.ResetColor();
            }

            int sum = productsSorted.Sum(p => p.Price);
            ColoredText.WriteLine("".PadRight(16) + "TOTAL: ".PadRight(16) + sum + "\n", ConsoleColor.Magenta);

        }
    }
}
