List<string> input = [.. File.ReadAllLines("input")];

Console.WriteLine($"Read {input.Count} lines from input.");

List<(int x, int y, int z)> points = new();

foreach (var line in input)
{
    points.Add(line.Split(',') switch
    {
        var parts when parts.Length == 3 =>
            (int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])),
        _ => throw new Exception($"Invalid line: {line}")
    });
}

int n = points.Count;

// build all pairwise edges with squared Euclidean distance, sort, take 1000 shortest
var edges = new List<(int a, int b, long dist)>();
for (int i = 0; i < n; i++)
{
    var (x1, y1, z1) = points[i];
    for (int j = i + 1; j < n; j++)
    {
        var (x2, y2, z2) = points[j];
        long dx = x2 - x1;
        long dy = y2 - y1;
        long dz = z2 - z1;
        long d2 = dx * dx + dy * dy + dz * dz;
        edges.Add((i, j, d2));
    }
}
edges.Sort((e1, e2) => e1.dist.CompareTo(e2.dist));

int take = Math.Min(1000, edges.Count);
var adj = new List<int>[n];
for (int i = 0; i < n; i++) adj[i] = new List<int>();

for (int k = 0; k < take; k++)
{
    var (a, b, _) = edges[k];
    if (!adj[a].Contains(b)) adj[a].Add(b);
    if (!adj[b].Contains(a)) adj[b].Add(a);
}

// compute connected components
var seen = new bool[n];
var sizes = new List<int>();
for (int i = 0; i < n; i++)
{
    if (seen[i]) continue;
    int size = 0;
    var stack = new Stack<int>();
    stack.Push(i);
    seen[i] = true;
    while (stack.Count > 0)
    {
        var u = stack.Pop();
        size++;
        foreach (var v in adj[u])
        {
            if (!seen[v])
            {
                seen[v] = true;
                stack.Push(v);
            }
        }
    }
    sizes.Add(size);
}

sizes.Sort((a, b) => b.CompareTo(a)); // descending
long product = 1;
for (int k = 0; k < Math.Min(3, sizes.Count); k++) product *= sizes[k];

Console.WriteLine($"Sizes (desc): {string.Join(", ", sizes)}");
Console.WriteLine($"Product of three largest circuits: {product}");