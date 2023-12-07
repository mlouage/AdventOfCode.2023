namespace AdventOfCode.Day07;

public class CardWithJoker : Card
{
    public override int Value  => "J23456789TQKA".IndexOf(Label) + 1;

    public CardWithJoker(char label)
        : base(label)
    { }
}
