// See https://aka.ms/new-console-template for more information
using owasp_a1_injection.Database;

Console.WriteLine("Hello. Init database :");

var db = new DatabaseHandler();

Console.WriteLine("What do you want to do ? (0 = Insert datas, 1 = show stocks, 2 = search reference, -1 = exit");
var action = Console.ReadLine();
while(action != "-1")
{
    if (action == "0")
        db.FillDatabase();
    else if (action == "1")
        db.GetStocks();
    else if (action == "2")
    {
        Console.WriteLine("Type the reference to search :");
        var reference = Console.ReadLine();
        db.GetStocks(reference);
    }

    Console.WriteLine("What do you want to do ? (1 = show stocks, 2 = search reference, 0 = exit");
    action = Console.ReadLine();
}

Console.WriteLine("Goodbye !");
