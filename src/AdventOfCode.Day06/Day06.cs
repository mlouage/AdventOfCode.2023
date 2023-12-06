namespace AdventOfCode.Day06;

public class Day06
{
    private readonly string[] _input;

    public Day06(string[] input)
    {
        _input = input;
    }

    public int Part1()
    {
        var total = new List<int>();
        var times = _input[0].Split(":")[1].Trim().Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var distances = _input[1].Split(":")[1].Trim().Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var races = times.Zip(distances);

        foreach (var race in races)
        {
            var distancesForRace = GetDistances(race.First);
            total.Add(distancesForRace.Count(x => x > race.Second));
        }

        return total.Aggregate((x, y) => x * y);

        IEnumerable<int> GetDistances(int raceTime)
        {
            for (var x = 0; x <= raceTime; x++)
            {
                yield return x * (raceTime - x);
            }
        }
    }

    public ulong Part2()
    {
        var time = long.Parse(_input[0].Split(":")[1].Trim().Replace(" ", ""));
        var distance = long.Parse(_input[1].Split(":")[1].Trim().Replace(" ", ""));

        var distances = GetDistances((ulong)time);

        return (ulong)distances.Count(x => x > (ulong)distance);

        IEnumerable<ulong> GetDistances(ulong raceTime)
        {
            for (var x = 0uL; x <= raceTime; x++)
            {
                yield return x * (raceTime - x);
            }
        }
    }
}
