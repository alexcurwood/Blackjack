namespace Blackjack.Models

{
    public class Card
    {
        public Suit Suit { get; }
        public int Value { get; }

        public int CardValue 
        { 
            get
            {
                if (Value > 10)
                {
                    return 10;
                }
                return Value;
            }
        }

        public Card(Suit suit, int value)
        {
            Suit = suit;
            Value = value;
        }
        public override string ToString()
        {
            string value = Value.ToString();
            if (Value == 1)
            {
                value = "A";
            }
            else if (Value == 11)
            {
                value = "J";   
            }
            else if (Value == 12)
            {
                value = "Q";   
            }
            else if (Value == 13)
            {
                value = "K";   
            }
            return $"{value} {Suit}";
        }
    }
}
