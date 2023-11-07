using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Models
{
    public class TestSuit_DTO
    {
        public int TestSuitId { get; set; }

        public string TestSuitName { get; set; }

        public bool RunMode { get; set; }

        public string RunModeText { get; set; }
    }
}
