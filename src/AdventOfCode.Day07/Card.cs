namespace AdventOfCode.Day07;

public class Card
{
    public char Label { get; }
    public virtual int Value => "23456789TJQKA".IndexOf(Label) + 1;

    public Card(char label)
    {
        Label = label;
    }
}
