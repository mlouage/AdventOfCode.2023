namespace AdventOfCode.Day07;

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

        public HandType DetermineHandType()
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
