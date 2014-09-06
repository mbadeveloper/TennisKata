using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    public interface IGameRule
    {
        bool IsMatch(List<Player> players);
        string CalculateScore(List<Player> players);
    }
}
