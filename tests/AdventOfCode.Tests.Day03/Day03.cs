using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day03;

public class Day03
{
    private readonly ITestOutputHelper _output;

    public Day03(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day03 = new AdventOfCode.Day03.Day03(data);
        var sum = day03.Part1();

        Assert.Equal(4361, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day03 = new AdventOfCode.Day03.Day03(data);
        var sum = day03.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(544433, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day03 = new AdventOfCode.Day03.Day03(data);
        var sum = day03.Part2();

        Assert.Equal(467835, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day03 = new AdventOfCode.Day03.Day03(data);
        var sum = day03.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(76314915, sum);
    }
}
