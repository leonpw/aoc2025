using System.Collections.Generic;
using System.Linq;

List<string> input = File.ReadAllLines("input").ToList();

int accessedByForklift = 0;

List<(int, int)> rollsToBeRemoved = new ();

do
{
    // remove rolls
    foreach (var item in rollsToBeRemoved)
    {
        var newCharArray = input[item.Item1].ToCharArray();
        newCharArray[item.Item2] = '.';
        input[item.Item1] = new string(newCharArray);

    }
    System.Console.WriteLine($"Removed {rollsToBeRemoved.Count} rolls!");
    rollsToBeRemoved.Clear();


    for (int i = 0; i < input.Count; i++)
    {
        for (int j = 0; j < input[i].Count(); j++)
        {
            if (IsRollOfPaper(i, j) && CanBeAccessedByForklift(i, j))
            {
                accessedByForklift++;
                rollsToBeRemoved.Add((i, j));
            }
        }
    }

} while (rollsToBeRemoved.Count > 0);

System.Console.WriteLine($"{accessedByForklift} were removed by a forklift.");


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
    if (x >= 0 && y >= 0 && x < input.Count && y < input[x].Count())
    {
        if (input[x][y] == '@')
        {
            return true;
        }
    }
    return false;
}