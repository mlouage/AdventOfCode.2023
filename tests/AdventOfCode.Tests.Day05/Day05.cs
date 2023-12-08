using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day05;

public class Day05
{
    private readonly ITestOutputHelper _output;

    public Day05(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day05 = new AdventOfCode.Day05.Day05(data);
        var min = day05.Part1();

        Assert.Equal(35uL, min);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day05 = new AdventOfCode.Day05.Day05(data);
        var min = day05.Part1();

        _output.WriteLine($"Min: {min}");

        Assert.Equal(57075758uL, min);
    }
    
    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day05 = new AdventOfCode.Day05.Day05(data);
        var min = day05.Part2();

        Assert.Equal(46uL, min);
    }

    [Fact(Skip = "Takes too long to run")]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day05 = new AdventOfCode.Day05.Day05(data);
        var min = day05.Part2();

        _output.WriteLine($"Min: {min}");

        Assert.Equal(1uL, min);
    }
}
