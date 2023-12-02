namespace AdventOfCode.Day02;

public class Day02
{
    private readonly string[] _input;

    public Day02(string[] input)
    {
        _input = input;
    }

    record Game(int Red, int Green, int Blue);

    public int Part1()
    {
        var sum = 0;
        var maxRed = 12;
        var maxGreen = 13;
        var maxBlue = 14;

        foreach (var game in _input)
        {
            var data = game.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var gameId = int.Parse(data[0].Replace("Game ", string.Empty).Replace(" ", ""));
            var gamedata = data[1];
            var results = gamedata.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var gameIsPossible = true;
            foreach (var result in results)
            {
                var rgb = result.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var red = rgb.Where(red => red.Contains("red")).Select(x => x.Replace(" red", string.Empty)).FirstOrDefault() ?? "0";
                var green = rgb.Where(green => green.Contains("green")).Select(x => x.Replace(" green", string.Empty)).FirstOrDefault() ?? "0";
                var blue = rgb.Where(blue => blue.Contains("blue")).Select(x => x.Replace(" blue", string.Empty)).FirstOrDefault() ?? "0";

                var gameDetails = new Game(int.Parse(red), int.Parse(green), int.Parse(blue));

                if (gameDetails.Red > maxRed || gameDetails.Green > maxGreen || gameDetails.Blue > maxBlue)
                {
                    gameIsPossible = false;
                    break;
                }
            }

            if (gameIsPossible)
            {
                sum += gameId;
            }
        }

        return sum;
    }

    public int Part2()
    {
        var sum = 0;

        foreach (var game in _input)
        {
            var data = game.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var gamedata = data[1];
            var results = gamedata.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var maxRed = 0;
            var maxGreen = 0;
            var maxBlue = 0;

            foreach (var result in results)
            {
                var rgb = result.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var red = int.Parse(rgb.Where(red => red.Contains("red")).Select(x => x.Replace(" red", string.Empty)).FirstOrDefault() ?? "0");
                var green = int.Parse(rgb.Where(green => green.Contains("green")).Select(x => x.Replace(" green", string.Empty)).FirstOrDefault() ?? "0");
                var blue = int.Parse(rgb.Where(blue => blue.Contains("blue")).Select(x => x.Replace(" blue", string.Empty)).FirstOrDefault() ?? "0");

                if (red > maxRed)
                {
                    maxRed = red;
                }

                if (green > maxGreen)
                {
                    maxGreen = green;
                }

                if (blue > maxBlue)
                {
                    maxBlue = blue;
                }
            }

            sum += maxRed * maxGreen * maxBlue;
        }

        return sum;
    }
}
