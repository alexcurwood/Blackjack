namespace Blackjack.Models

{
    public class Game
    {
        public List <Player> Players {get;}

        public Deck Deck {get;}

        public Game()
        {
            Console.WriteLine("");
            Console.WriteLine ("Welcome to Blackjack (Ace is always 1)");
            var human = new Player(PlayerType.Human);
            var dealer = new Player(PlayerType.Dealer);

            Players = new List<Player>()
            {   
                human,
                dealer
            };
            Deck = new Deck();
            Deck.Shuffle();
        }
        public void InitialDeal()
        {
            Console.WriteLine("");
            Console.WriteLine("Initial Deal:");
            for (var i=0; i < 2; i ++)
            {
                foreach (var Player in Players)
                {
                    Player.Hand.Add (Deck.DealCard());
                }
            }
        }
        public void ShowHands()
        {
            foreach (var player in Players)
            {
                if (player.Type == PlayerType.Human)
                {
                player.ShowHand();
                }
            }
        }
        public bool InitialCheck()
        {
            if (Players.Any(p => p.HandValue == 21))
            {
                var message = "Game over, ";

                if (Players.All(p => p.HandValue == 21))
                {
                    message += "both players have Blackjack and the player wins";
                }
                else
                {
                    foreach (var player in Players)
                    {
                        if (player.HandValue == 21)
                        {
                            if (player.Type == PlayerType.Human)
                            {
                                message += " the player has won";
                            }
                            else
                            {
                                message += " the dealer has won";
                            }
                        }
                    }
                }
                Console.WriteLine(message);
                return true;
            }
            return false;
        }
        public void Play()
        {
            Console.WriteLine("");
            Console.WriteLine("Start of the game:");
            var human = Players.Single(p => p.Type == PlayerType.Human);
            PlayHand(human);
            if (human.HandValue > 21)
            {
                Console.WriteLine("");
                Console.WriteLine ("The player have gone bust and the dealer wins");
                return;
            }
            var dealer = Players.Single(p => p.Type == PlayerType.Dealer);
            PlayHand(dealer);
            if (dealer.HandValue > 21)
            {
                Console.WriteLine("");
                Console.WriteLine ("The dealer has gone bust and the player wins");
                return;
            }
            if (human.HandValue == dealer.HandValue)
            {
                Console.WriteLine("");
                Console.WriteLine ($"Both players have {human.HandValue} and the player wins");
                return;
            }
            if (human.HandValue < dealer.HandValue)
            {
                Console.WriteLine("");
                Console.WriteLine ($"The player has {human.HandValue} and the dealer has {dealer.HandValue} and the dealer wins");
                return;
            }
            Console.WriteLine("");
            Console.WriteLine ($"The player has {human.HandValue} and the dealer has {dealer.HandValue} and the player wins");
        }
        private void PlayHand(Player player)
        {
            Console.WriteLine("");
            var isHuman = player.Type == PlayerType.Human;
            var message = isHuman
                ? "Start of the hand for the player:"
                : "Start of the hand for the dealer:";
            Console.WriteLine(message);
            while (player.HandValue < 21)
            {
                if (isHuman)
                {
                    player.ShowHand();
                    Console.WriteLine("");
                    Console.WriteLine("Type 't' to twist and be dealt another card or type 's' to stick and end with these cards");
                    var input = Console.ReadKey(true);
                    if (input.KeyChar == 't' || input.KeyChar == 'T')
                    {
                        var nextCard = Deck.DealCard();
                        player.Hand.Add(nextCard);
                        Console.WriteLine("");
                        Console.WriteLine ($"You have been dealt {nextCard}");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine ($"You have stuck with{player.ShowCards()}");
                        return;
                    }
                }
                else
                {
                    player.ShowHand();
                    if (player.HandValue < 17)
                    {
                        var nextCard = Deck.DealCard();
                        player.Hand.Add(nextCard);
                        Console.WriteLine("");
                        Console.WriteLine ($"The dealer has been dealt {nextCard}");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"The dealer has stuck with{player.ShowCards()}");
                        return;
                    }
                }
            }
        }

    }
}