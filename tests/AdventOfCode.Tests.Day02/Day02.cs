using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day02;

public class Day02
{
    private readonly ITestOutputHelper _output;

    public Day02(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day02 = new AdventOfCode.Day02.Day02(data);
        var sum = day02.Part1();

        Assert.Equal(8, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day02 = new AdventOfCode.Day02.Day02(data);
        var sum = day02.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(2283, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day02 = new AdventOfCode.Day02.Day02(data);
        var sum = day02.Part2();

        Assert.Equal(2286, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day02 = new AdventOfCode.Day02.Day02(data);
        var sum = day02.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(1, 1);
    }
}
