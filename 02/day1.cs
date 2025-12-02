string[] input = File.ReadAllLines("input");

string[] range = input[0].Split(',');

Int64 totalIvalid = 0;

foreach (var item in range)
{
    string[] ranges = item.Split('-');

    var f = Int64.Parse(ranges[0]);
    var l = Int64.Parse(ranges[1]);

    System.Console.WriteLine($"s:{f}, e: {l}");

    for (Int64 i = f; i <= l; i++)
    {
        if (IsInvalid(i.ToString()))
        {
            System.Console.WriteLine($"invalid: {i}");
            totalIvalid += i;
        }
    }
}

System.Console.WriteLine($"total invalid: {totalIvalid}");

static bool IsInvalid(string a)
{
    if (a.Length % 2 != 0)
        return false;

    for (int i = 0; i < a.Length / 2; i++)
    {
        if (a[i] != a[i + a.Length / 2])
            return false;
    }
    return true;
}
