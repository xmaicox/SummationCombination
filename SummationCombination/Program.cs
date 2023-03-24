// See https://aka.ms/new-console-template for more information
using SummationCombination;

SummationHelper helper = new SummationHelper();

while (true) {
    Console.Clear();
    Console.WriteLine("Enter a number:");
    string c = Console.ReadLine();

    int enteredValue = 0;

    if (int.TryParse(c, out enteredValue))
    {
        var res = helper.GetSumItems(enteredValue);
        Console.WriteLine($"Result: {res}");
        Console.WriteLine("Press Enter To Put In A New Value");
        Console.ReadLine(); //Wait for enter to enter new number
    }

    else {
        Console.WriteLine("Program is Exiting...");
        Console.ReadLine();//Will exit after typing in enter
        break;
    }

}
