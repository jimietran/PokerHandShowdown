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
    /// Used for testing the HandRanking class.
    /// </summary>
    [TestClass()]
    public class HandRankingTests
    {
        [TestMethod()]
        public void IdentifyHandTest()
        {
            List<Card> highCardHand = new List<Card> { new Card(Suit.Heart, Rank.Two), new Card(Suit.Club, Rank.Five), new Card(Suit.Spade, Rank.Seven), new Card(Suit.Club, Rank.Ten), new Card(Suit.Club, Rank.Ace) };
            HandRanking handRanking = new HandRanking(highCardHand);
            Assert.AreEqual(PokerHand.HighCard, handRanking.Hand);
        }

        [TestMethod()]
        public void CheckForFlushTest()
        {
            List<Card> flushHand = new List<Card> { new Card(Suit.Heart, Rank.Three), new Card(Suit.Heart, Rank.Six), new Card(Suit.Heart, Rank.Eight), new Card(Suit.Heart, Rank.Jack), new Card(Suit.Heart, Rank.King) };
            HandRanking handRanking = new HandRanking(flushHand);
            Assert.AreEqual(PokerHand.Flush, handRanking.Hand);
        }

        [TestMethod()]
        public void CheckForThreeOfAKindTest()
        {
            List<Card> threeOfAKindHand = new List<Card> { new Card(Suit.Club, Rank.Three), new Card(Suit.Diamond, Rank.Three), new Card(Suit.Spade, Rank.Three), new Card(Suit.Club, Rank.Eight), new Card(Suit.Diamond, Rank.Ten) };
            HandRanking handRanking = new HandRanking(threeOfAKindHand);
            Assert.AreEqual(PokerHand.ThreeOfAKind, handRanking.Hand);
        }

        [TestMethod()]
        public void CheckForOnePairTest()
        {
            List<Card> onePairHand = new List<Card> { new Card(Suit.Heart, Rank.Two), new Card(Suit.Club, Rank.Two), new Card(Suit.Spade, Rank.Five), new Card(Suit.Club, Rank.Ten), new Card(Suit.Heart, Rank.Ace) };
            HandRanking handRanking = new HandRanking(onePairHand);
            Assert.AreEqual(PokerHand.OnePair, handRanking.Hand);
        }
    }
}