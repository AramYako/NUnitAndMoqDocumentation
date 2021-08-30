using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Module6
{
    public class CreditScore : ICreditScore
    {
        public int CreditScoreValue { get; set; }
        public int Count { get; set; }
    }
}
