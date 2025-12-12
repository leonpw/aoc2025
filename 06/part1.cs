List<string> input = [.. File.ReadAllLines("input")];

Console.WriteLine($"Read {input.Count} lines from input.");

List<long[]> numbers = [];

int count = input.Count;

List<char> math = [];
for (int i = 0; i < count - 1; i++)
{
    numbers.Add([.. input[i]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(long.Parse)]);
}

math = [.. input[count - 1].Split(' ',
    StringSplitOptions.RemoveEmptyEntries).Select(x => x[0])];

decimal total = 0;

for (int i = 0; i < numbers[0].Length; i++)
{
    for (int j = 0; j < count - 1; j++)
    {
        Console.Write($"{numbers[j][i]} ");
    }

    long amount = 0;
    switch (math[i])
    {
        case '+':
            amount += numbers.Sum(x => x[i]);
            break;
        case '*':
            amount += numbers.Aggregate(1L, (acc, x) => acc * x[i]);
            break;
        default:
            break;
    }

    Console.WriteLine($"{math[i]} = {amount}");
    total += amount;

}

Console.WriteLine($"Total: {total}");
