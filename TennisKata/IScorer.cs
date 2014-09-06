using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    public interface IScorer
    {
        string GameScore { get; }
        void RoundScore(Player player);
    }
}
