using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Rounding
{
    public class RoundingUp : IRounding
    {
        public decimal Round(decimal value)
        {
            decimal roundValue;

            roundValue = Math.Ceiling(value * 20) / 20;

            return roundValue;
        }
    }
}
