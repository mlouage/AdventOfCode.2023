using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace AdventOfCode.Day01;

public partial class Day01
{
    private readonly string[] _input;

    public Day01(string[] input)
    {
        _input = input;
    }

    public int Part1()
    {
        var sum = 0;
        foreach (var line in _input)
        {
            var first = Regex.Replace(line, "[^0-9]", string.Empty).First();
            var last = Regex.Replace(line, "[^0-9]", string.Empty).Last();
            var number = $"{first}{last}";
            sum += int.Parse(number);

        }
        return sum;
    }

    public string Find(string input)
    {
        var numberWords = new Dictionary<string, string?>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
            { "1", "1" },
            { "2", "2" },
            { "3", "3" },
            { "4", "4" },
            { "5", "5" },
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" }
        };

        var pattern = string.Join("|", numberWords.Keys);
        var matches = Regex.Matches(input, $"[0-9]|{pattern}", RegexOptions.IgnoreCase);

        if (matches.Count == 0)
        {
            return "00";
        }

        var first = matches.OrderBy(m => m.Index).First();
        var last = matches.OrderBy(m => m.Index).Last();

        return $"{numberWords[first.Value]}{numberWords[last.Value]}";
    }

    public int Part2()
    {
        var sum = 0;
        foreach (var line in _input)
        {
            var number = Find(line);
            sum += int.Parse(number);

        }
        return sum;
    }

    [GeneratedRegex("[0-9]")]
    private static partial Regex IsNumeric();
    [GeneratedRegex("[^0-9]")]
    private static partial Regex IsNotNumeric();
}
