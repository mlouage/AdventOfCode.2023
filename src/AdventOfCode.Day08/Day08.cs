using System.Collections.Concurrent;

namespace AdventOfCode.Day08;

public class Day08
{
    private readonly IEnumerable<string> _input;
    private readonly IDictionary<string, (string Left, string Right)> _nodes
        = new Dictionary<string, (string Left, string Right)>();
    private readonly ConcurrentDictionary<string, (string Left, string Right)> _concurrentNodes
        = new();
    private readonly string _instructions;

    private readonly ConcurrentDictionary<int, IEnumerable<string>> _nodeResults = new();

    public Day08(IEnumerable<string> input)
    {
        _input = input;
        _instructions = _input.ElementAt(0);
    }

    public int Part1()
    {
        var instructions = _input.ElementAt(0);
        var notDone = true;
        GenerateNodes();

        var totalSteps = 0;
        var index = -1;
        var node = _nodes["AAA"];


        var instructionsLength = instructions.Length;

        while(notDone)
        {
            index++;
            if (index >= instructionsLength)
            {
                index = 0;
            }

            var instruction = instructions[index];
            totalSteps++;

            if (instruction == 'L')
            {
                if (node.Left.EndsWith("ZZZ"))
                {
                    notDone = false;
                }

                node = _nodes[node.Left];
            }
            else
            {
                if (node.Right.EndsWith("ZZZ"))
                {
                    notDone = false;
                }

                node = _nodes[node.Right];
            }
        }

        return totalSteps;
    }

    public ulong Part2()
    {
        var nodes = GenerateNodes();
        var steps = nodes.Select(CalculateSteps).ToList();

        return LeastCommonMultiple(steps);
    }

    private static ulong LeastCommonMultiple(IEnumerable<ulong> numbers)
    {
        return numbers.Aggregate(1UL, LeastCommonMultiple);
    }

    private static ulong LeastCommonMultiple(ulong a, ulong b)
    {
        return a / GreatestCommonDivisor(a, b) * b;
    }

    private static ulong GreatestCommonDivisor(ulong a, ulong b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private ulong CalculateSteps(string nodeKey)
    {
        var totalSteps = 0uL;
        var instructionsLength = _instructions.Length;
        var notDone = true;
        var index = -1;
        var node = _nodes[nodeKey];

        while(notDone)
        {
            index++;
            if (index >= instructionsLength)
            {
                index = 0;
            }

            var instruction = _instructions[index];
            totalSteps++;

            if (instruction == 'L')
            {
                if (node.Left.EndsWith("Z"))
                {
                    notDone = false;
                }

                node = _nodes[node.Left];
            }
            else
            {
                if (node.Right.EndsWith("Z"))
                {
                    notDone = false;
                }

                node = _nodes[node.Right];
            }
        }

        return totalSteps;
    }

    private IEnumerable<string> GenerateNodes()
    {
        var startNodes = new List<string>();
        for(var i = 1; i < _input.Count(); i++)
        {
            var line = _input.ElementAt(i);
            if (string.IsNullOrWhiteSpace(line)) continue;
            var lineData = line.Split("=".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var node = lineData[0];

            if (node.EndsWith("A"))
            {
                startNodes.Add(node);
            }

            var values = lineData[1].Split(",".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var valueLeft = values[0].TrimStart('(');
            var valueRight = values[1].TrimEnd(')');

            _nodes.Add(node, (valueLeft, valueRight));
            _concurrentNodes.TryAdd(node, (valueLeft, valueRight));
        }

        return startNodes;
    }
}
