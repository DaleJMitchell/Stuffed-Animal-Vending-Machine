using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Nickel: ISpendable
    {
        public decimal Value { get; } = .05M; 
    }
}
