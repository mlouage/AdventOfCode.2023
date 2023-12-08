using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day08;

public class Day08
{
    private readonly ITestOutputHelper _output;

    public Day08(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test.txt");

        var day08 = new AdventOfCode.Day08.Day08(data);
        var sum = day08.Part1();

        Assert.Equal(6, sum);
    }

    [Fact]
    public async Task Part1Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day08 = new AdventOfCode.Day08.Day08(data);
        var sum = day08.Part1();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(19241, sum);
    }

    [Fact]
    public async Task Part2TestDataTest()
    {
        var data = await File.ReadAllLinesAsync("Data/test_part2.txt");

        var day08 = new AdventOfCode.Day08.Day08(data);
        var sum = day08.Part2();

        Assert.Equal(6uL, sum);
    }

    [Fact]
    public async Task Part2Test()
    {
        var data = await File.ReadAllLinesAsync("Data/input.txt");

        var day08 = new AdventOfCode.Day08.Day08(data);
        var sum = day08.Part2();

        _output.WriteLine($"Sum: {sum}");

        Assert.Equal(9606140307013uL, sum);
    }
}
