using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day06;

public class Day06
{
    private readonly ITestOutputHelper _output;

    public Day06(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day06 = new AdventOfCode.Day06.Day06(data);
        var sum = day06.Part1();

        Assert.Equal(288, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day06 = new AdventOfCode.Day06.Day06(data);
        var sum = day06.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(160816, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day06 = new AdventOfCode.Day06.Day06(data);
        var sum = day06.Part2();

        Assert.Equal(71503uL, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day06 = new AdventOfCode.Day06.Day06(data);
        var sum = day06.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(46561107uL, sum);
    }
}
