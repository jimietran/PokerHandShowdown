using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    public enum Suit
    {
        Diamond,
        Club,
        Heart,
        Spade
    }

    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    /// <summary>
    /// Class used to initialize the Card object.
    /// </summary>
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        
        /// <summary>
        /// Constructor. Sets the card's suit and rank.
        /// </summary>
        /// <param name="suit">Card suit.</param>
        /// <param name="rank">Card rank.</param>
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        /// <summary>
        /// First compares two cards ranks, then their suits if the ranks are equal.
        /// </summary>
        /// <param name="otherCard">Card to be compared to.</param>
        /// <returns>1 if true, -1 if false.</returns>
        public int CompareTo(Card otherCard)
        {
            if (this.ConvertRankToInt() > otherCard.ConvertRankToInt())
            {
                return 1;
            }
            else if (this.ConvertRankToInt() < otherCard.ConvertRankToInt())
            {
                return -1;
            }
            else
            {
                if (this.Suit > otherCard.Suit)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Converts rank to an integer type.
        /// </summary>
        /// <returns>Rank as an integer.</returns>
        public int ConvertRankToInt()
        {
            return Convert.ToInt32(Rank);
        }
    }
}
