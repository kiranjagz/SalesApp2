using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Rounding
{
    public interface IRounding
    {
        decimal Round(decimal value);
    }
}
