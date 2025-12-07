using System.Linq;

string[] input = File.ReadAllLines("input");

long totalJoltage = 0;

foreach (var bank in input)
{
    totalJoltage += getMaxJoltage(bank);
}

System.Console.WriteLine(totalJoltage);

long getMaxJoltage(string bank)
{
    long max = 0;
    int[] maxJoltage = new int[12];

    string tempBank = bank;
    for (int i = 0; i < 12; i++)
    {
        tempBank = GetHighestSubString(tempBank.Substring(i == 0 ? 0: 1), 12 - i);
        maxJoltage[i] = int.Parse(tempBank[0].ToString());
    }

    max = long.Parse(string.Join("", maxJoltage));
    System.Console.WriteLine($"{bank}: maxed joltage: {max}");
    return max;
}

// returns a substring with a minimum length
string GetHighestSubString(string a, int minimumLength)
{
    int index = 0;

    // walk right to left
    for (int i = a.Length - minimumLength; i >= 0; i--)
    {
        if (a[i] >= a[index])
        {
            index = i;
        }
    }
    return a.Substring(index);
}