using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day01;

public class Day01
{
    private readonly ITestOutputHelper _output;

    public Day01(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test_part1.txt");

        var day01 = new AdventOfCode.Day01.Day01(data);
        var sum = day01.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(142, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day01 = new AdventOfCode.Day01.Day01(data);
        var sum = day01.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(56042, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test_part2.txt");

        var day01 = new AdventOfCode.Day01.Day01(data);
        var sum = day01.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(281, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day01 = new AdventOfCode.Day01.Day01(data);
        var sum = day01.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(55358, sum);
    }
}
