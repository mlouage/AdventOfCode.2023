using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day04;

public class Day04
{
    private readonly ITestOutputHelper _output;

    public Day04(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day04 = new AdventOfCode.Day04.Day04(data);
        var sum = day04.Part1();

        Assert.Equal(13, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day04 = new AdventOfCode.Day04.Day04(data);
        var sum = day04.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(21568, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day04 = new AdventOfCode.Day04.Day04(data);
        var sum = day04.Part2();

        Assert.Equal(30, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day04 = new AdventOfCode.Day04.Day04(data);
        var sum = day04.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(11827296, sum);
    }
}
