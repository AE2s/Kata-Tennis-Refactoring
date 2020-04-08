using System;

namespace KataTennis
{
    public class TennisGame3 : ITennisGame
    {
        private const int FORTY = 3;
        private const string ALL = "All";
        private int _scorePlayer2;
        private int _scorePlayer1;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _scoreLabels;

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _scoreLabels = new[] { "Love", "Fifteen", "Thirty", "Forty" };
        }

        public string GetScore()
        {
            if (IsDeuce())
                return "Deuce";

            if (_scorePlayer1 <= FORTY && _scorePlayer2 <= FORTY)
            {
                return SameScore() ? $"{_scoreLabels[_scorePlayer1]}-{ALL}" : 
                    $"{_scoreLabels[_scorePlayer1]}-{_scoreLabels[_scorePlayer2]}";
            }

            var playerName = _scorePlayer1 > _scorePlayer2 ? _player1Name : _player2Name;
            return IsAdvantage() ? $"Advantage {playerName}" : $"Win for {playerName}";
        }

        private bool IsDeuce()
        {
            return SameScore() && _scorePlayer1 >= FORTY;
        }

        private bool SameScore()
        {
            return _scorePlayer1 == _scorePlayer2;
        }

        private bool IsAdvantage()
        {
            return Math.Abs(_scorePlayer1 - _scorePlayer2) == 1;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _scorePlayer1++;
            else
                _scorePlayer2++;
        }

    }
}
