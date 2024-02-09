
using Checkpoint2;
using System.Diagnostics;

ProductList productList = new ProductList();

AddProducts();

InputCommands();



void AddProducts()
{
    //Lets the user add products to the list by enter the category, name and price.
    // Loops to let the user add additional products until they exit.
    //Displays the product list when finished.

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
    //Lets the user enter a command to chose what to do next.
    //Loops to let the user add a new command whenever they've finished what they're doing.

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
    //Let's the user enter a search phrase to find highlight products in the list. Loops until they enter a valid search term.
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
    // Asks the user to enter information about a product.
    //Loops until they enter a valid input. Also let's them enter a command to exit.
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
    //Asks the user to enter a price. Validates that they either enter an integer or a command to exit.
    while (true)
    {
        string input = InputInfo("Price");
        if (input == "q" || int.TryParse(input, out _)) return input;
        else ColoredText.WriteLine("You did not enter a valid price.", ConsoleColor.Red);
    }
}
















