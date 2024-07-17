namespace Blackjack.Models
{
    public class Deck
    {
        private int index;
        public List <Card> Cards { get; private set;}
        
        public Deck()
        {
            Cards = new List<Card> (); 
                for (int i = 1; i < 14; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        var card = new Card((Suit)j, i);
                        Cards.Add (card);
                    }
                }
            index = 0;
        }
        public void Shuffle()
        {
            var random = new Random();
            Cards = Cards.OrderBy(x => random.Next()).ToList();
        }

        public Card DealCard()
        {
            var cardToDeal = Cards[index];
            index ++;
            return cardToDeal;
        }
    }
}