using AdventOfCode.Day07;

public class HandWithJoker : IComparable<HandWithJoker>
{
    public List<CardWithJoker> Cards { get; set; }
    public HandType Type { get; set; }

    public int Bid { get; set; }

    public HandWithJoker(string hand, int bid)
    {
        Cards = hand.Select(c => new CardWithJoker(c)).ToList();
        Type = DetermineHandType();
        Bid = bid;
    }

    private HandType DetermineHandType()
    {
            var groups = Cards
                .GroupBy(c => c.Label)
                .Select(group => new
                {
                    Label = group.Key,
                    Count = group.Count()
                }).ToList();

            var groupCount = groups.Count - 1;

            if (groups.Any(c => c.Label == 'J'))
            {
                var jokerCount = groups.First(c => c.Label == 'J').Count;

                if (groupCount == 1) return HandType.FiveOfAKind;

                if (jokerCount == 2)
                {
                    if (groupCount == 2) return HandType.FourOfAKind;
                    if (groupCount == 3) return HandType.ThreeOfAKind;
                }

                if (jokerCount == 1)
                {
                    if (groupCount == 2)
                    {
                        return groups.Any(g => g.Count == 3) ? HandType.FourOfAKind : HandType.FullHouse;
                    }
                    if (groupCount == 3) return HandType.ThreeOfAKind;
                    if (groupCount == 4) return HandType.OnePair;
                }
            }

            return groups.Count switch
            {
                1 => HandType.FiveOfAKind,
                2 => groups.Any(g => g.Count == 4) ? HandType.FourOfAKind : HandType.FullHouse,
                3 => groups.Any(g => g.Count == 3) ? HandType.ThreeOfAKind : HandType.TwoPair,
                4 => HandType.OnePair,
                _ => HandType.HighCard
            };
    }

    public int CompareTo(HandWithJoker other)
    {
        if (Type != other.Type)
            return Type.CompareTo(other.Type);

        // Compare cards one by one
        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i].Value != other.Cards[i].Value)
                return Cards[i].Value.CompareTo(other.Cards[i].Value);
        }

        return 0;
    }
}
