using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    /// <summary>
    /// Class used to determine player rankings.
    /// </summary>
    public class PlayerRanking
    {
        public Player Winner { get; set; }

        /// <summary>
        /// Constructor. Sets player rankings such as the winner.
        /// </summary>
        /// <param name="players">List of players to be processed.</param>
        public PlayerRanking(List<Player> players)
        {
            this.Winner = DetermineWinner(players);
        }

        /// <summary>
        /// Determines the winner by finding the players' largest hand.
        /// </summary>
        /// <param name="players">List of players to be used to find the winner.</param>
        /// <returns>The winning player.</returns>
        public Player DetermineWinner(List<Player> players)
        {
            HandRanking currentPlayerRank = null;
            HandRanking highestPlayerRank = null;
            Player winningPlayer = null;
            List<Player> tiedPlayers = new List<Player>();
            if (players != null)
            {
                foreach (Player player in players)
                {
                    currentPlayerRank = new HandRanking(player.Hand);
                    if (highestPlayerRank != null)
                    {
                        if (currentPlayerRank.Hand > highestPlayerRank.Hand)
                        {
                            highestPlayerRank = currentPlayerRank;
                            winningPlayer = player;
                            tiedPlayers.Clear();
                        }
                        else if (currentPlayerRank.Hand.Equals(highestPlayerRank.Hand))
                        {
                            if (!tiedPlayers.Contains(winningPlayer))
                            {
                                tiedPlayers.Add(winningPlayer);
                            }
                            tiedPlayers.Add(player);
                        }
                    }
                    else
                    {
                        highestPlayerRank = currentPlayerRank;
                        winningPlayer = player;
                    }
                }
                if (tiedPlayers.Count > 0)
                {
                    return ResolveTie(tiedPlayers);
                }
                else
                {
                    return winningPlayer;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(players));
            }
        }

        /// <summary>
        /// Resolves any ties that occur between players that share the largest hand by looking at the highest card.
        /// </summary>
        /// <param name="tiedPlayers">List of players that all have the same poker hand, but different highest cards. </param>
        /// <returns>The winner among tied players.</returns>
        private Player ResolveTie(List<Player> tiedPlayers)
        {
            HandRanking currentTiedPlayerRank = null;
            HandRanking highestTiedPlayerRank = null;
            Player winningTiedPlayer = null;
            foreach (Player tiedPlayer in tiedPlayers)
            {
                currentTiedPlayerRank = new HandRanking(tiedPlayer.Hand);
                if (highestTiedPlayerRank != null)
                {
                    if (currentTiedPlayerRank.HighestCard.CompareTo(highestTiedPlayerRank.HighestCard) == 1)
                    {
                        highestTiedPlayerRank = currentTiedPlayerRank;
                        winningTiedPlayer = tiedPlayer;
                    }
                }
                else
                {
                    highestTiedPlayerRank = currentTiedPlayerRank;
                    winningTiedPlayer = tiedPlayer;
                }
            }
            return winningTiedPlayer;
        }
    }
}
