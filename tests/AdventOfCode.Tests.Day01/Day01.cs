using Xunit.Abstractions;

namespace AdventOfCode.Tests.Day01;

public class Day01
{
    private readonly ITestOutputHelper _output;

    public Day01(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData("xcntwmkm", "00")]
    [InlineData("99lbqpxzzlbtvkmfrvrnmcxttseven", "97")]
    [InlineData("q7cnfslbtpkvseven", "77")]
    [InlineData("6threezlljtzcr1sdjkthree4cx", "64")]
    [InlineData("21xfxfourmzmqbqp1", "21")]
    [InlineData("lkdbjd5", "55")]
    [InlineData("fourmsmjqfmbjvtwosevendcljsdcstl3one", "41")]
    [InlineData("fourone29", "49")]
    [InlineData("4two5two9xcpkkjqxcfivessqqvhbbt", "45")]
    [InlineData("ncnqg1sixt9ninedlfgsqhnxx6", "16")]
    [InlineData("xrlsktwodnbcbonefvxxqgbrsdthree3seven", "27")]
    [InlineData("klvsv73", "73")]
    [InlineData("onezvbhrblrkzcrsevensix96jnpxjone", "11")]
    [InlineData("nine6chd4", "94")]
    [InlineData("bdvkqlrh9eight6eightninehq7", "97")]
    [InlineData("fivexpx1vsrreightkp7dph", "57")]
    [InlineData("3eightlrrlgck967", "37")]
    [InlineData("xcntwone4633sixmkm1nine", "29")]
    [InlineData("225", "25")]
    [InlineData("teightwofprzdscnts4nv88", "88")]
    [InlineData("eighteightshqcbqzxmbktwo54fourpdkf", "84")]
    [InlineData("sixfhvgkfourfoursjxnstgqnjh2", "62")]
    [InlineData("6two1vtnqbrhqjbnkm7six9six", "66")]
    [InlineData("9963onefourthree6oneightq", "91")]
    [InlineData("9963onefourthree6oneightwo", "92")]
    [InlineData("9oneighthree9", "99")]
    public void FindTest(string input, string expected)
    {
        var empty = Enumerable.Empty<string>().ToArray();
        var day01 = new AdventOfCode.Day01.Day01(empty);
        var result = day01.Find(input);
        Assert.Equal(expected, result);
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
        var data = await File.ReadAllLinesAsync("Data/test.txt");

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
