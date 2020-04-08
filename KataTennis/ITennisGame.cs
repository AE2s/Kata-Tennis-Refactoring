using System;
using System.Collections.Generic;
using System.Text;

namespace KataTennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}
