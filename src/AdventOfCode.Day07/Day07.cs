namespace AdventOfCode.Day07;

public partial class Day07
{
    private readonly IEnumerable<string> _input;

    private static List<Hand> SortHands(List<string> hands)
    {
        var handObjects = hands.Select(hand =>
        {
            var cards = hand.Split(" ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var cardsInHand = cards[0];
            var bid = int.Parse(cards[1]);
            return new Hand(cardsInHand, bid);
        }).ToList();

        handObjects.Sort();

        return handObjects;
    }

    private static List<HandWithJoker> SortHandsWithJoker(List<string> hands)
    {
        var handObjects = hands.Select(hand =>
        {
            var cards = hand.Split(" ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var cardsInHand = cards[0];
            var bid = int.Parse(cards[1]);
            return new HandWithJoker(cardsInHand, bid);
        }).ToList();

        handObjects.Sort();

        return handObjects;
    }
    
    public Day07(IEnumerable<string> input)
    {
        _input = input;
    }

    public int Part1()
    {
        var hands = _input.ToList();
        var sortedHands = SortHands(hands);

        var sum = sortedHands.Select(hand => hand.Bid * (sortedHands.IndexOf(hand) + 1)).Sum();

        return sum;
    }

    public int Part2()
    {
        var hands = _input.ToList();
        var sortedHands = SortHandsWithJoker(hands);

        var sum = sortedHands.Select(hand => hand.Bid * (sortedHands.IndexOf(hand) + 1)).Sum();

        return sum;
    }
}
