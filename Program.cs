
using System.Diagnostics;

List<Product> products = new List<Product>();

AddProducts();

PrintList();

Console.ReadLine();



void AddProducts()
{
    while (true)
    {
        Product newProduct = new Product();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Follow the instructions to enter a new product. Write q to quit.");
        Console.ResetColor();

        Console.Write("Category: ");
        newProduct.Category = Console.ReadLine();
        if (newProduct.Category.ToLower() == "q") break;

        Console.Write("Product: ");
        newProduct.Name = Console.ReadLine();

        bool validPrice = false;
        int price;
        while (!validPrice)
        {
            Console.Write("Price: ");
            string input = Console.ReadLine();
            validPrice = int.TryParse(input, out price);

            if (validPrice) newProduct.Price = price;
            else InvalidPriceMessage();
        }


        products.Add(newProduct);
    }
}

void InvalidPriceMessage()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("A valid price was not entered.");
    Console.ResetColor();
}





void PrintList()
{
    Console.WriteLine("\nYour Product List:");
    foreach (Product product in products)
    {
        Console.WriteLine(product.Category + " " + product.Name + " " + product.Price);
    }

    int highestPrice = products.Max(p => p.Price);
    Console.WriteLine("Highest Price: " + highestPrice);

}



class Product
{

    public string Category {  get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public Product()
    {
    }

    public Product(string category, string name, int price)
    {
        this.Category = category;
        this.Name = name;
        this.Price = price;
    }
}


