using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASINO.Classes
{
    public class Bet
    {
        public string Type { get; set; }
        public int Amount { get; set; }

        public Bet(string type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
