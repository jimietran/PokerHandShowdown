# PokerHandShowdown

## How It Works
The PlayerRanking class determines the winner of Poker Hand Showdown. It takes in a list of n players, and each player must have a name and a list of n cards.

Here is an example of how to retrieve the name of the winner:

List<Card> joeHand = new List<Card> { new Card(Suit.Heart, Rank.Three), new Card(Suit.Diamond, Rank.Four), new Card(Suit.Club, Rank.Nine), new Card(Suit.Diamond, Rank.Nine), new Card(Suit.Heart, Rank.Queen) };
List<Card> jenHand = new List<Card> { new Card(Suit.Club, Rank.Five), new Card(Suit.Diamond, Rank.Seven), new Card(Suit.Heart, Rank.Nine), new Card(Suit.Spade, Rank.Nine), new Card(Suit.Spade, Rank.Queen) };
List<Card> bobHand = new List<Card> { new Card(Suit.Heart, Rank.Two), new Card(Suit.Club, Rank.Two), new Card(Suit.Spade, Rank.Five), new Card(Suit.Club, Rank.Ten), new Card(Suit.Heart, Rank.Ace) };

List<Player> players = new List<Player> { new Player("Joe", joeHand), new Player("Jen", jenHand), new Player("Bob", bobHand) };
PlayerRanking playerRanking = new PlayerRanking(players);
Console.WriteLine(playerRanking.Winner.Name);

In this case the winner is Jen.

## Assumptions
- Suit order: Diamond < Club < Heart < Spade
- Hand order: High Card < One Pair < Three of a Kind < Flush
- Assume different decks are used. Players can each have the exact same hand.
- If exact identical hands are drawn, the first player to receive that hand wins.