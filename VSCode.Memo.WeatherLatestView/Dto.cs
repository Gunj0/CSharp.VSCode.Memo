using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSCode.Memo.WeatherLatestView
{
    public class Dto
    {
        public int AreaId { get; set; }

        public DateTime DataDate { get; set; }

        public int Condition { get; set; }

        public float Temperature { get; set; }
    }
}