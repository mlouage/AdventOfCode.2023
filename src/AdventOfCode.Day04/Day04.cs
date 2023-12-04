namespace AdventOfCode.Day04;

public class Day04
{
    private readonly string[] _input;

    public Day04(string[] input)
    {
        _input = input;
    }

    public double Part1()
    {
        double sum = 0;
        foreach (var game in _input)
        {
            var card = game.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var numbers = card[1].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var winningNumbers = numbers[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var cardNumbers = numbers[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var amountOfWinningNumbers = winningNumbers.Count() - winningNumbers.Except(cardNumbers).Count();

            if (amountOfWinningNumbers == 0)
            {
                continue;
            }

            var y = (amountOfWinningNumbers - 1) < 0
                ? 0
                : (amountOfWinningNumbers - 1);

            var total = Math.Pow((double)2, (double)(y)) * 1;

            sum += total;
        }

        return sum;
    }

    public int Part2()
    {
        double sum = 0;
        var total = Enumerable.Repeat(1, _input.Length + 1).ToArray();

        // Initialize the first card with 0
        total[0] = 0;
        total[1] = 1;

        foreach (var game in _input)
        {
            var card = game.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var cardId = int.Parse(card[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
            var numbers = card[1].Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var winningNumbers = numbers[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var cardNumbers = numbers[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var amountOfWinningNumbers = winningNumbers.Count() - winningNumbers.Except(cardNumbers).Count();

            for(var i = 1; i <= amountOfWinningNumbers; i++)
            {
                if (cardId + i > total.Length) continue;
                total[cardId + i] += total[cardId];
            }
        }

        return total.Sum();
    }
}
