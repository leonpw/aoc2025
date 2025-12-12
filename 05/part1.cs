using System.Collections.Generic;
using System.Linq;

List<string> input = File.ReadAllLines("input").ToList();
List<long> itemToCheck = new();
List<(long start, long end)> fresh = new();

int freshCount = 0;

foreach (var item in input)
{
    if (item.Contains('-'))
    {
        var range = item.Split('-');
        long s = long.Parse(range[0]);
        long e = long.Parse(range[1]);

        fresh.Add((s, e));

        System.Console.WriteLine($"Added range: {s} - {e}");
    }

    else if (!string.IsNullOrEmpty(item))
    {
        long prod = long.Parse(item);
        itemToCheck.Add(prod);

        foreach (var itemProduct in fresh)
        {
            if (itemProduct.start < prod && prod < itemProduct.end)
            {
                freshCount++;
                break;
            }
        }
    }

}
System.Console.WriteLine($"Found {freshCount} fresh products.");