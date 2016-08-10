using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown.Tests
{
    /// <summary>
    /// Used for testing the PlayerRanking class.
    /// </summary>
    [TestClass()]
    public class PlayerRankingTests
    {
        [TestMethod()]
        public void DetermineWinnerTest()
        {
            List<Card> joeHand = new List<Card> { new Card(Suit.Heart, Rank.Three), new Card(Suit.Diamond, Rank.Four), new Card(Suit.Club, Rank.Nine), new Card(Suit.Diamond, Rank.Nine), new Card(Suit.Heart, Rank.Queen) };
            List<Card> jenHand = new List<Card> { new Card(Suit.Club, Rank.Five), new Card(Suit.Diamond, Rank.Seven), new Card(Suit.Heart, Rank.Nine), new Card(Suit.Spade, Rank.Nine), new Card(Suit.Spade, Rank.Queen) };
            List<Card> bobHand = new List<Card> { new Card(Suit.Heart, Rank.Two), new Card(Suit.Club, Rank.Two), new Card(Suit.Spade, Rank.Five), new Card(Suit.Club, Rank.Ten), new Card(Suit.Heart, Rank.Ace) };
            List<Player> players = new List<Player> { new Player("Joe", joeHand), new Player("Jen", jenHand), new Player("Bob", bobHand) };
            PlayerRanking playerRanking = new PlayerRanking(players);
            Assert.AreEqual("Jen", playerRanking.Winner.Name);
        }
    }
}