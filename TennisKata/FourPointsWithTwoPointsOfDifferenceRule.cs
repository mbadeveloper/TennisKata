using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    class FourPointsWithTwoPointsOfDifferenceRule : IGameRule 
    {
        public bool IsMatch(List<Player> players)
        {
            return (players[0].Points >= 4 && (players[0].Points - players[1].Points) >= 2);
        }

        public string CalculateScore(List<Player> players)
        {
            return players[0].Name + " win";
        }
    }
}
