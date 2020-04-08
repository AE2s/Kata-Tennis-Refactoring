using System;
using System.Collections.Generic;

namespace KataTennis
{
    public class TennisGame2 : ITennisGame
    {
        private const int FORTY = 3;
        private int _player1Point;
        private int _player2Point;

        private string _p1Result = "";
        private string _p2Result = "";
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly IReadOnlyDictionary<int, string> _scoreFromIntToString;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _player1Point = 0;
            _player2Point = 0;
            _scoreFromIntToString = new Dictionary<int, string>()
            {
                {0, "Love" },
                {1, "Fifteen" },
                {2, "Thirty" },
                {3, "Forty"}
            };
        }

        public string GetScore()
        {
            if (_player1Point == _player2Point)
                return IsDeuce() ? "Deuce" : $"{_scoreFromIntToString[_player1Point]}-All";

            string playerName = _player1Point > _player2Point ? _player1Name : _player2Name;

            if (IsAdvantage())
                return $"Advantage {playerName}";

            if (IsWinner())
                return $"Win for {playerName}";

            if (_scoreFromIntToString.ContainsKey(_player2Point))
                _p2Result = _scoreFromIntToString[_player2Point];
            
            if (_scoreFromIntToString.ContainsKey(_player1Point))
                _p1Result = _scoreFromIntToString[_player1Point];

            return $"{_p1Result}-{_p2Result}";
        }

        private bool IsWinner()
        {
            return _player1Point > FORTY || _player2Point > FORTY && Math.Abs(_player1Point - _player2Point) >= 2;
        }

        private bool IsAdvantage()
        {
            return Math.Abs(_player1Point - _player2Point) == 1 && _player1Point >= FORTY && _player2Point >= FORTY;
        }

        private bool IsDeuce()
        {
            return _player1Point >= FORTY;
        }

        private void IncrementPlayer1Score()
        {
            _player1Point++;
        }

        private void IncrementPlayer2Score()
        {
            _player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name)
                IncrementPlayer1Score();
            else
                IncrementPlayer2Score();
        }

    }
}
