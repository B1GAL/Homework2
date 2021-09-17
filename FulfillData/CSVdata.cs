using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillData
{
    public class CSVdata
    {
        public string State { get; set; }
        public string Gender { get; set; }
        public double Mean { get; set; }
        public int N { get; set; }

        public CSVdata()
        {
            State = string.Empty;
            Gender = string.Empty;
            Mean = 0;
            N = 0;
        }




    }
}
