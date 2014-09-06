using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    class GameScoreRule : IGameRule
    {
        public bool IsMatch(List<Player> players)
        {
            return true;
        }

        public string CalculateScore(List<Player> players)
        {
            return EquivalentScore(players[0].Points) + "-" + EquivalentScore(players[1].Points);
        }

        public string EquivalentScore(int points)
        {
            switch (points)
            {
                case 3:
                    return "forty";
                case 2:
                    return "thirty";
                case 1:
                    return "fifteen";
                case 0:
                    return "love";
                default:
                    return "";
            }
        }
    }
}
