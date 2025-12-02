string[] input = File.ReadAllLines("input");

int dial = 50;
int password = 0; // amount of times it pointed at 0;

foreach (var item in input)
{
    int a;
    a = int.Parse(item.Where(Char.IsDigit).ToArray());
    System.Console.WriteLine($"{item[0]}: {a}");
    dial = item[0] == 'L' ? dial - a : dial + a;

    System.Console.WriteLine($"dial: {dial}");
    if (dial % 100 == 0)
    {
        System.Console.WriteLine($"we hit the 0");
        password++;
    }
    System.Console.WriteLine($"The password is {password}");
}