string[] input = File.ReadAllLines("input");

int accessedByForklift = 0;

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        if (IsRollOfPaper(i, j) && CanBeAccessedByForklift(i, j))
            accessedByForklift++;
    }
}

System.Console.WriteLine($"{accessedByForklift} rolls can be accesed by a forklift.");


bool CanBeAccessedByForklift(int x, int y)
{
    int[,] toCheck = {
        {x -1, y -1},
        {x -1, y},
        {x -1, y +1},
        {x , y -1},
        {x , y +1},
        {x +1, y -1},
        {x +1, y},
        {x +1, y +1},
        };

    int count = 0;


    for (int k = 0; k < toCheck.GetLength(0); k++)
    {
        if (IsRollOfPaper(toCheck[k, 0], toCheck[k, 1]))
            count++;
    }

    return count < 4;
}

bool IsRollOfPaper(int x, int y)
{
    if (x >= 0 && y >= 0 && x < input.Length && y < input[x].Length)
    {
        if (input[x][y] == '@')
        {
            return true;
        }
    }
    return false;
}