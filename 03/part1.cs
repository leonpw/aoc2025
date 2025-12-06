string[] input = File.ReadAllLines("input");

int totalJoltage =0;

foreach (var bank in input)
{
    totalJoltage += getMaxJoltage(bank);
}

System.Console.WriteLine(totalJoltage);

int getMaxJoltage(string bank)
{
    int max = 0;
    for (int i = 0; i < bank.Length -1; i++)
    {
        for(int j = i +1; j < bank.Length; j++)
        {
            int joltage = int.Parse( $"{bank[i]}{bank[j]}");
            if(joltage > max)
                max = joltage;
        }    
    }

    return max;
}