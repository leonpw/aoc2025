List<string> input = [.. File.ReadAllLines("input")];

Console.WriteLine($"Read {input.Count} lines from input.");

List<List<long>> numbers = [[]];

int count = input.Count;

List<char> math = [];

math = input[count - 1].Split(' ',
    StringSplitOptions.RemoveEmptyEntries).Select(x => x[0]).ToList();


math.Reverse();

int group = 0;

for (int i = input[0].Length - 1; i >= 0; i--)
{
    Console.WriteLine(i);
    string n = "";

    for (int j = 0; j < count - 1; j++)
    {
        n += input[j][i];
    }

    if (string.IsNullOrWhiteSpace(n))
    {
        group++;
        numbers.Add([]);
    }
    else
    {
        numbers.Last().Add(long.Parse(n));
    }
}

decimal total = 0;


for (int i = 0; i < numbers.Count; i++)
{
    for (int j = 0; j < numbers[i].Count; j++)
    {
        Console.Write($"{numbers[i][j]} ");
    }

    long amount = 0;
    switch (math[i])
    {
        case '+':
            amount += numbers[i].Sum();
            break;
        case '*':
            amount += numbers[i].Aggregate(1L, (acc, x) => acc * x);
            break;
        default:
            break;
    }

    Console.WriteLine($"{math[i]} = {amount}");
    total += amount;
}

Console.WriteLine($"Total: {total}");
