using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day07;

public class Day07
{
    private readonly ITestOutputHelper _output;

    public Day07(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day07 = new AdventOfCode.Day07.Day07(data);
        var sum = day07.Part1();

        Assert.Equal(6440, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day07 = new AdventOfCode.Day07.Day07(data);
        var sum = day07.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(250120186, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day07 = new AdventOfCode.Day07.Day07(data);
        var sum = day07.Part2();

        Assert.Equal(5905, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day07 = new AdventOfCode.Day07.Day07(data);
        var sum = day07.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(250665248, sum);
    }
}
