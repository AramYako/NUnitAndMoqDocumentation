using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Module6
{
    public class LoadProcess
    {
        private readonly ICreditScore _creditScore;
        public LoadProcess(ICreditScore creditScore)
        {
            _creditScore = creditScore;
        }

        public bool Execute()
        {
            this._creditScore.Count++;

            if (this._creditScore.CreditScoreValue < 300)
                return false;


            return true; 
        }
    }
}
