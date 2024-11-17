using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASINO.Classes
{
    public class RouletteGame
    {
        private Random _random;
        private List<Bet> _bets;
        private int _winningNumber;

        public RouletteGame()
        {
            _random = new Random();
            _bets = new List<Bet>();
        }

        public void SpinWheel()
        {
            _winningNumber = _random.Next(1, 37);
        }

        public int GetWinningNumber()
        {
            return _winningNumber;
        }

        public void PlaceBet(Bet bet)
        {
            _bets.Add(bet);
        }

        public void UpdateUserBalance()
        {
            // Update user balance based on winning bets
        }
    }
}
