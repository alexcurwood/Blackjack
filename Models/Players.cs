namespace Blackjack.Models

{
    public class Player
    {
        public List <Card> Hand { get; }

        public PlayerType Type { get; }

        public Player(PlayerType type)
        {
            Type = type;
            Hand = new List<Card>();
        }
        public int HandValue =>
           Hand.Sum(c => c.CardValue); 

        public void ShowHand()
        {
            var message = "";
                if (Type == PlayerType.Human)
                {
                    message = "Your hand is";
                    
                }
                if (Type == PlayerType.Dealer)
                {
                    message = "The dealer's hand is";
                }
                
                message += ShowCards();

                Console.WriteLine(message);
        }

        public string ShowCards()
        {
            var message = "";

            foreach (var card in Hand)
            {
                message += $" {card}";
            }
            return message;
        }
    }

}
