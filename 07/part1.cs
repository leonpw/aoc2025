List<string> input = [.. File.ReadAllLines("input")];

Console.WriteLine($"Read {input.Count} lines from input.");

int splitCount = 0;

List<(int, int)> beamsProcessed = [];
Queue<(int r, int c)> beams = new();

beams.Enqueue((0, input[0].IndexOf('S')));

while (beams.Count > 0)
{
    var (r, c) = beams.Dequeue();

    if (r >= input.Count - 1)
    {
        continue;
    }

    if (input[r + 1][c] == '.')
    {
        if (!beamsProcessed.Contains((r + 1, c)))
        {

            beams.Enqueue((r + 1, c));
            beamsProcessed.Add((r + 1, c));
            Console.WriteLine($"Beam at row {r} col {c} moving down.");
        }
    }

    if (input[r + 1][c] == '^')
    {
        splitCount++;
        Console.WriteLine($"Beam at row {r} col {c} splitting.");
        if (!beamsProcessed.Contains((r + 1, c - 1)))
        {
            beamsProcessed.Add((r + 1, c - 1));
            beams.Enqueue((r + 1, c - 1));

        }
        if (!beamsProcessed.Contains((r + 1, c + 1)))
        {
            beamsProcessed.Add((r + 1, c + 1));
            beams.Enqueue((r + 1, c + 1));
        }
    }

}

System.Console.WriteLine($"Total splits: {splitCount}");