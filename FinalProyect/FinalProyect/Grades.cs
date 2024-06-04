using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect
{
    public class Grade
    {
        public int Unit { get; set; }
        public double Score { get; set; }

        public Grade(int unit, double score)
        {
            Unit = unit;
            Score = score;
        }
    }
}
