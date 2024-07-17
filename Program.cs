using Blackjack.Models;

var game = new Game();

game.InitialDeal();
game.ShowHands();
if (game.InitialCheck())
{
   return; 
}
game.Play();




