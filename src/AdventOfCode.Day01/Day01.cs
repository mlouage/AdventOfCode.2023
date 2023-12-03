using System.Text.RegularExpressions;

namespace AdventOfCode.Day01;

public class Day01
{
    private readonly string[] _input;

    private Dictionary<string, int> _numberWords = new Dictionary<string, int>
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "1", 1 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 }
    };

    public Day01(string[] input)
    {
        _input = input;
    }

    public int Part1()
    {
        var sum = 0;
        foreach (var line in _input)
        {
            var numbers = Regex.Replace(line, "[^0-9]", string.Empty);

            if (string.IsNullOrWhiteSpace(numbers)) continue;

            var first = numbers.First().ToString();
            var last = numbers.Last().ToString();

            var number = $"{first}{last}";
            sum += int.Parse(number);
        }
        return sum;
    }

    public int Part2()
    {
        var totalSum = 0;

        foreach (var line in _input)
        {
            var firstDigit = -1;
            var lastDigit = -1;
            var firstDigitIndex = int.MaxValue;
            var lastDigitIndex = -1;

            foreach (var pair in _numberWords)
            {
                var firstIndex = line.IndexOf(pair.Key);
                var lastIndex = line.LastIndexOf(pair.Key);

                if (firstIndex >= 0 && firstIndex < firstDigitIndex)
                {
                    firstDigitIndex = firstIndex;
                    firstDigit = pair.Value;
                }

                if (lastIndex <= lastDigitIndex) continue;

                lastDigitIndex = lastIndex;
                lastDigit = pair.Value;
            }

            if (firstDigit != -1 && lastDigit != -1)
            {
                totalSum += firstDigit * 10 + lastDigit;
            }
        }

        return totalSum;
    }
}
