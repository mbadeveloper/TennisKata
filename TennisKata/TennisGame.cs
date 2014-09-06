using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    public class TennisGame : IScorer
    {
        private List<Player> players;
        private IGameRules gameRules;

        public TennisGame(List<Player> gamePlayers, IGameRules rules)
        {
            players = gamePlayers;
            gameRules = rules;
        }

        public string GameScore
        {
            get { return gameRules.ApplyRules(players); }
        }

        public void RoundScore(Player player)
        {
            player.Points++;
        }
    }
}
