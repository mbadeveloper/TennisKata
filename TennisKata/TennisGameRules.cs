using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    public class TennisGameRules : IGameRules 
    {
        private List<IGameRule> gameRules;

        public TennisGameRules()
        {
            gameRules = new List<IGameRule>();
            gameRules.Add(new FourPointsWithTwoPointsOfDifferenceRule());
            gameRules.Add(new DeduceRule());
            gameRules.Add(new AdvantageRule());
            gameRules.Add(new GameScoreRule());
        }

        public string ApplyRules(List<Player> players)
        {
            return gameRules.First(r => r.IsMatch(players)).CalculateScore(players);
        }
    }
}
