using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    class DeduceRule :IGameRule 
    {
        public bool IsMatch(List<Player> players)
        {
            return (players[0].Points >= 3 && players[1].Points >= 3 && players[0].Points == players[1].Points);
        }

        public string CalculateScore(List<Player> players)
        {
            return "deuce";
        }
    }
}
