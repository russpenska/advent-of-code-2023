var lines = System.IO.File.ReadAllLines("input.txt");

var digitRepresentations = new System.Collections.Generic.Dictionary<string, int>() {
    { "1", 1 },
    { "2", 2 },
    { "3", 3 },
    { "4", 4 },
    { "5", 5 },
    { "6", 6 },
    { "7", 7 },
    { "8", 8 },
    { "9", 9 },
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 },
};

var sum = 0;
foreach(var line in lines)
{
    var firstDigit = -1;
    var lastDigit = -1;
    
    for (int i = 0; i < line.Length; i++)
    {
        foreach (var key in digitRepresentations.Keys)
        {
            if (key.Length <= line.Length - i && line.Substring(i, key.Length) == key)
            {
                if (firstDigit == -1)
                {
                    firstDigit = digitRepresentations[key];
                }

                lastDigit = digitRepresentations[key];
            }
        }
    }

    sum += (firstDigit * 10) + lastDigit;

    System.Console.WriteLine(line + "\t" + firstDigit + "\t" + lastDigit);
}

System.Console.WriteLine(sum);