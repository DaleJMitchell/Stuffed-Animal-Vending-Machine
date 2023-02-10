using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Dollar: ISpendable 
    {
        public decimal Value { get; } = 1.00M; 
    }
}
