using System.Collections.Generic;
using System.Linq;
using System.Threading;


List<string> input = File.ReadAllLines("input").ToList();
List<long> itemToCheck = new();

List<(long start, long end)> fresh = new();

// Read all input and add to fresh list.
foreach (var item in input)
{
    if (item.Contains('-'))
    {
        var range = item.Split('-');
        if (range.Length != 2) continue;
        long s = long.Parse(range[0]);
        long e = long.Parse(range[1]);

        fresh.Add((s, e));
        System.Console.WriteLine($"Added range: {s} - {e}");
    }
}

var merged = MergeRanges(fresh);

Console.WriteLine("Merged ranges:");
foreach (var r in merged)
    Console.WriteLine($"{r.start} - {r.end}. Count: {r.end - r.start + 1}");

Console.WriteLine($"Total merged ranges: {merged.Count}, Total count: {merged.Sum(r => r.end - r.start + 1)}    ");


static List<(long start, long end)> MergeRanges(List<(long start, long end)> ranges)
{
    if (ranges == null || ranges.Count == 0) return new List<(long, long)>();

    var sorted = ranges.OrderBy(r => r.start).ThenBy(r => r.end).ToList();
    var result = new List<(long start, long end)>();

    var current = sorted[0];

    for (int i = 1; i < sorted.Count; i++)
    {
        var next = sorted[i];

        // If overlapping or contiguous (change +1 to 0 if contiguity shouldn't merge)
        if (next.start <= current.end + 1)
        {
            current.end = Math.Max(current.end, next.end);
        }
        else
        {
            result.Add(current);
            current = next;
        }
    }

    result.Add(current);
    return result;
}