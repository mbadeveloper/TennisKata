using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    class AdvantageRule : IGameRule
    {
        public bool IsMatch(List<Player> players)
        {
            return ((players[0].Points >= 3 && players[1].Points >= 3) &&
                (((players[0].Points - players[1].Points) > 0) || ((players[1].Points - players[0].Points) > 0)));
        }

        public string CalculateScore(List<Player> players)
        {
            return "advantage " + ((players[0].Points - players[1].Points) > 0? players[0].Name : players[1].Name);
        }
    }
}
