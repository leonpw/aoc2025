string[] input = File.ReadAllLines("input");

int dial = 50;
int password = 0; // amount of times it pointed at 0;

foreach (var item in input)
{
    int a;
    a = int.Parse(item.Where(Char.IsDigit).ToArray());
    System.Console.WriteLine($"{item[0]}: {a}");

    if (item[0] == 'L')
    {
        for (int i = 0; i < a; i++)
        {
            dial--;
            if (dial == -1)
                dial = 99;
            if (dial == 0)
            {
                password++;
            }
        }
    }
    else
    {
        for (int i = 0; i < a; i++)
        {
            dial++;
            if (dial == 101)
                dial = 1;
            if (dial == 100)
            {
                password++;
            }
        }

    }
    System.Console.WriteLine($"dial: {dial}");
    System.Console.WriteLine($"The password is {password}");
}