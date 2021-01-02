using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class DeathDataResponseModel
    {
        public int TotalCases { get; set; }
        public int TotalDeath { get; set; }
        public double AverageAge { get; set; }
        public int DeadButAgeNotAvailable { get; set; }
        public int TotalDeathDataWithAgeAvaiable { get; set; }
        public HashSet<string> Status { get; set; }
        public int CasesWithNoStatusAvailable { get; set; }
    }
}
