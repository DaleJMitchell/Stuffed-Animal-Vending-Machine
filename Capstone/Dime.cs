using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Dime : ISpendable
    {
        public decimal Value { get; } = .10M; 
    }
}
