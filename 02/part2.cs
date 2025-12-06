string[] input = File.ReadAllLines("input");
string[] range = input[0].Split(',');

Int64 totalIvalid = 0;

foreach (var item in range)
{
    string[] ranges = item.Split('-');

    var f = Int64.Parse(ranges[0]);
    var l = Int64.Parse(ranges[1]);

    for (Int64 i = f; i <= l; i++)
    {
        if (!IsValid(i.ToString()))
        {
            totalIvalid += i;
        }
    }
}

System.Console.WriteLine($"total invalid: {totalIvalid}");

static bool IsValid(string a)
{
    // l is the divider
    for (int l = 2; l < 15; l++)
    {
        // check if the sequence fits and is can fit at least twice
        if (a.Length % l == 0 && a.Length / l > 0)
        {

            int sub = a.Length / l;
            bool valid = false;

            for (int i = 1; i < l && !valid; i++)
            {
                if (a.Substring(0, sub) != a.Substring(sub * i, sub))
                {
                    valid = true;
                    break;
                }
            }

            if (!valid)
            {
                return false;
            }
        }
    }

    return true;
}
