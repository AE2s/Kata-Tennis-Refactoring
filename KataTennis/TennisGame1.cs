using System;
using System.Collections.Generic;

namespace KataTennis
{
    public class TennisGame1 : ITennisGame
    {
        private const int MAX_SCORE = 4;
        private int _mScore1;
        private int _mScore2;
        private readonly string _player1Name;
        private readonly string _player2Name;

        private readonly IReadOnlyDictionary<int, string> _scoreFromIntToString;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _scoreFromIntToString = new Dictionary<int, string>()
            {
                {0, "Love" },
                {1, "Fifteen" },
                {2, "Thirty" },
                {3, "Forty"}
            };
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _mScore1++;
            else
                _mScore2++;
        }

        public string GetScore()
        {
            if (_mScore1 == _mScore2)
            {
                return IsDeuce() ? "Deuce" : $"{_scoreFromIntToString[_mScore1]}-All";
            }

            if (_mScore1 >= MAX_SCORE || _mScore2 >= MAX_SCORE)
            {
                var playerName = _mScore1 > _mScore2 ? _player1Name : _player2Name;
                return IsAdvantage() ? $"Advantage {playerName}" : $"Win for {playerName}";
            }

            return $"{_scoreFromIntToString[_mScore1]}-{_scoreFromIntToString[_mScore2]}";
        }

        private bool IsDeuce()
        {
            return _mScore1 >= 3 && _mScore2 >= 3;
        }

        private bool IsAdvantage()
        {
            return Math.Abs(_mScore1 - _mScore2) == 1;
        }
    }
}
