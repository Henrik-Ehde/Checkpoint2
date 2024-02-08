
using Checkpoint2;
using System.Diagnostics;

ProductList productList = new ProductList();

AddProducts();

InputCommands();



void AddProducts()
{
    while (true)
    {
        Product newProduct = new();

        ColoredText.WriteLine("Follow the instructions to enter a new product. Enter Q to quit.", ConsoleColor.Yellow);

        string input = InputInfo("Category");
        if (input == "q") break;
        else newProduct.Category = input;

        input = InputInfo("Product name");
        if (input == "q") break;
        else newProduct.Name = input;

        input = InputPrice();
        if (input == "q") break;
        else newProduct.Price = int.Parse(input);

        productList.Add(newProduct);
        ColoredText.WriteLine("The product has been added.\n", ConsoleColor.Green);
    }

    productList.PrintSorted();
}

void InputCommands()
{
    while (true)
    {
        ColoredText.WriteLine("COMMANDS: P - Enter more products | S - Search | Q - Quit", ConsoleColor.DarkYellow);
        Console.Write("Input a Command: ");

        switch (Console.ReadLine().ToLower().Trim())
        {
            case "p":
                Console.Write("\n");
                AddProducts();
                break;

            case "s":
                Search();
                break;

            case "q":
                Environment.Exit(0);
                break;

            default:
                ColoredText.WriteLine("You did not enter a valid command.", ConsoleColor.Red);
                break;
        }
    }
}

void Search()
{
    while (true)
    {
        ColoredText.Write("Search for: ", ConsoleColor.Yellow);
        string searchString = Console.ReadLine();
        if (searchString == "") ColoredText.WriteLine("You did not enter anything", ConsoleColor.Red);
        else
        {
            productList.PrintSearched(searchString);
            break;
        }   
    }
}



string InputInfo(string info)
{
    while (true)
    {
        Console.Write("Enter the " + info + ": ");
        string input = Console.ReadLine();
        if (input == "") ColoredText.WriteLine("You did not enter anything.", ConsoleColor.Red);
        else if (input.ToLower().Trim() == "q") return "q";
        else return input;
    }
}

string InputPrice()
{
    while (true)
    {
        string input = InputInfo("Price");
        if (input == "q" || int.TryParse(input, out _)) return input;
        else ColoredText.WriteLine("You did not enter a valid price.", ConsoleColor.Red);
    }
}
















