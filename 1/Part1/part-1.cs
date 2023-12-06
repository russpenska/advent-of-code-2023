var lines = System.IO.File.ReadAllLines("input.txt");
var sum = 0;

foreach (var line in lines)
{
    var firstDigit = -1; // means no char yet
    var lastDigit = -1;
    foreach (var character in line)
    {
        var code = (int)character;
        if (code >= 48 && code <= 57)
        {
            var digit = code - 48;
            if (firstDigit < 0)
            {
                firstDigit = digit;
            }

            lastDigit = digit;
        }
    }

    var combinedDigits = (firstDigit * 10) + lastDigit;
    sum += combinedDigits;
}


System.Console.WriteLine(sum);