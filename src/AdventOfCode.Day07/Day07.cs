namespace AdventOfCode.Day07;

public class Day07
{
    private readonly IEnumerable<string> _input;

    public enum HandType
    {
        HighCard, OnePair, TwoPair, ThreeOfAKind, FullHouse, FourOfAKind, FiveOfAKind
    }

    public class Card
    {
        public char Label { get; }
        public virtual int Value => "23456789TJQKA".IndexOf(Label) + 1;

        public Card(char label)
        {
            Label = label;
        }
    }

    public class CardWithJoker : Card
    {
        public override int Value  => "J23456789TQKA".IndexOf(Label) + 1;

        public CardWithJoker(char label)
            : base(label)
        { }
    }

    public class Hand : IComparable<Hand>
    {
        public List<Card> Cards { get; set; }
        public HandType Type { get; set; }

        public int Bid { get; set; }

        public Hand(string hand, int bid)
        {
            Cards = hand.Select(c => new Card(c)).ToList();
            Type = DetermineHandType();
            Bid = bid;
        }

        public virtual HandType DetermineHandType()
        {
            var groups = Cards.GroupBy(c => c.Label).Select(group => new { Label = group.Key, Count = group.Count() }).ToList();
            return groups.Count switch
            {
                1 => HandType.FiveOfAKind,
                2 => groups.Any(g => g.Count == 4) ? HandType.FourOfAKind : HandType.FullHouse,
                3 => groups.Any(g => g.Count == 3) ? HandType.ThreeOfAKind : HandType.TwoPair,
                4 => HandType.OnePair,
                _ => HandType.HighCard
            };
        }

        public int CompareTo(Hand other)
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

    public class HandWithJoker : Hand
    {
        public HandWithJoker(string hand, int bid)
            : base(hand, bid)
        {
            Cards = hand.Select(c => new CardWithJoker(c)).ToList();
            Type = DetermineHandType();
            Bid = bid;
        }

        public override HandType DetermineHandType()
        {
            var groups = Cards
                .GroupBy(c => c.Label)
                .Select(group => new
                {
                    Label = group.Key,
                    Count = group.Count()
                }).ToList();

            if (groups.Any(c => c.Label == 'J'))
            {
                var jokerGroup = groups.First(c => c.Label == 'J');
                var jokerCount = jokerGroup.Count;

                if (jokerCount == 4)
                {
                    return HandType.FiveOfAKind;
                }

                if (jokerCount == 3)
                {
                    return groups.Any(g => g.Count == 2) ? HandType.FullHouse : HandType.ThreeOfAKind;
                }

                if (jokerCount == 2)
                {
                    return groups.Any(g => g.Count == 3) ? HandType.FullHouse : HandType.TwoPair;
                }

                if (jokerCount == 1)
                {
                    return groups.Any(g => g.Count == 4) ? HandType.FourOfAKind : HandType.OnePair;
                }

                return HandType.HighCard;
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

    public static List<Hand> SortHands(List<string> hands)
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
        var sortedHands = SortHands(hands);

        var sum = sortedHands.Select(hand => hand.Bid * (sortedHands.IndexOf(hand) + 1)).Sum();

        return sum;
    }
}
