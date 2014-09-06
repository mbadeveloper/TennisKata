using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisKata
{
    public interface IGameRules
    {
        string ApplyRules(List<Player> players);
    }
}
