using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    /// <summary>
    /// Class used to initialize the Player object.
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        /// <summary>
        /// Constructor. Sets the player's name and card hand.
        /// </summary>
        /// <param name="name">Player's name.</param>
        /// <param name="hand">Player's cards.</param>
        public Player(string name, List<Card> hand)
        {
            this.Name = name;
            this.Hand = hand;
        }
    }
}
