List<string> input = [.. File.ReadAllLines("input")];

Console.WriteLine($"Read {input.Count} lines from input.");

List<(int x, int y, int z)> points = [];

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

// build all pairwise edges with squared Euclidean distance, sort ascending
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

int[] parent = new int[n];
int[] size = new int[n];
for (int i = 0; i < n; i++) { parent[i] = i; size[i] = 1; }

int Find(int x)
{
    while (parent[x] != x) { parent[x] = parent[parent[x]]; x = parent[x]; }
    return x;
}

long MultiplyXOfLastConnected = -1;
int components = n;

foreach (var (a, b, _) in edges)
{
    int ra = Find(a);
    int rb = Find(b);
    if (ra == rb) continue;

    // union by size
    if (size[ra] < size[rb]) (ra, rb) = (rb, ra);
    parent[rb] = ra;
    size[ra] += size[rb];
    components--;

    if (components == 1)
    {
        MultiplyXOfLastConnected = (long)points[a].x * points[b].x;
        Console.WriteLine($"Last connection that unifies all: indices {a} and {b}, coords {points[a].x},{points[a].y},{points[a].z} and {points[b].x},{points[b].y},{points[b].z}");
        Console.WriteLine($"Product of their X coordinates: {MultiplyXOfLastConnected}");
        break;
    }
}

if (components > 1)
{
    Console.WriteLine("Graph did not become a single component after processing all edges.");
}