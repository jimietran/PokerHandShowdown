using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    public enum PokerHand
    {
        HighCard,
        OnePair,
        ThreeOfAKind,
        Flush
    }

    /// <summary>
    /// Class used to determine hand and card rankings.
    /// </summary>
    public class HandRanking
    {
        public PokerHand Hand { get; set; }
        public List<Card> Cards { get; set; }
        public Card HighestCard { get; set; }

        /// <summary>
        /// Constructor. Sets the hand type and highest card.
        /// </summary>
        /// <param name="cards">List of cards to be processed.</param>
        public HandRanking(List<Card> cards)
        {
            this.Cards = cards;
            SortCards();
            this.HighestCard = Cards.Last();
            this.Hand = IdentifyHand();
        }

        /// <summary>
        /// Sorts the cards from lowest to highest.
        /// </summary>
        public void SortCards()
        {
            Cards.Sort((card, otherCard) => card.CompareTo(otherCard));
        }

        /// <summary>
        /// Identifies the kind of hand the cards create.
        /// </summary>
        /// <returns>The corresponding poker hand.</returns>
        public PokerHand IdentifyHand()
        {
            PokerHand pokerHand;
            if (CheckForFlush())
            {
                pokerHand = PokerHand.Flush;
            }
            else if (CheckForThreeOfAKind())
            {
                pokerHand = PokerHand.ThreeOfAKind;
            }
            else if (CheckForOnePair())
            {
                pokerHand = PokerHand.OnePair;
            }
            else
            {
                pokerHand = PokerHand.HighCard;
            }
            return pokerHand;
        }

        /// <summary>
        /// Specifically looks for a flush by counting the number of repeating suits.
        /// </summary>
        /// <returns>True if a flush is found, false otherwise.</returns>
        public bool CheckForFlush()
        {
            int numberOfDiamonds = 0;
            int numberOfClubs = 0;
            int numberOfHearts = 0;
            int numberOfSpades = 0;
            foreach (Card card in Cards)
            {
                if (card.Suit.Equals(Suit.Diamond))
                {
                    numberOfDiamonds++;
                }
                else if (card.Suit.Equals(Suit.Club))
                {
                    numberOfClubs++;
                }
                else if (card.Suit.Equals(Suit.Heart))
                {
                    numberOfHearts++;
                }
                else if (card.Suit.Equals(Suit.Spade))
                {
                    numberOfSpades++;
                }
            }
            return ((numberOfDiamonds >= 5) || (numberOfClubs >= 5) || (numberOfHearts >= 5) || (numberOfSpades >= 5));
        }

        /// <summary>
        /// Specifically looks for a three of a kind by checking matching ranks.
        /// </summary>
        /// <returns>True if a three of a kind is found, false otherwise.</returns>
        public bool CheckForThreeOfAKind()
        {
            return CheckForNumberOfCardMatches(3);
        }

        /// <summary>
        /// Specifically looks for one pair by checking matching ranks.
        /// </summary>
        /// <returns>True if one pair is found, false otherwise.</returns>
        public bool CheckForOnePair()
        {
            return CheckForNumberOfCardMatches(2);
        }

        /// <summary>
        /// Counts the number of times a card matches another card.
        /// </summary>
        /// <param name="desiredCardMatches">Specific number of card matches needed.</param>
        /// <returns>True if the desired match number is found, false otherwise.</returns>
        private bool CheckForNumberOfCardMatches(int desiredCardMatches)
        {
            bool successfulMatch = false;
            int currentCardRank = 0;
            int matchCount = 1;
            foreach (Card card in Cards)
            {
                if (currentCardRank.Equals(card.ConvertRankToInt()))
                {
                    matchCount++;
                    HighestCard = card;
                }
                else
                {
                    currentCardRank = card.ConvertRankToInt();
                }

                if (matchCount.Equals(desiredCardMatches))
                {
                    successfulMatch = true;
                }
                else if (matchCount < desiredCardMatches)
                {
                    successfulMatch = false;
                }
            }
            if (matchCount == 1)
            {
                if (HighestCard.CompareTo(Cards.Last()) == -1)
                {
                    HighestCard = Cards.Last();
                }
            }
            return successfulMatch;
        }
    }
}
