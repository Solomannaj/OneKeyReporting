using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Models
{
    public class TestCase_DTO
    {
        public int TestCaseId { get; set; }

        public string TestCaseName { get; set; }

        public bool RunMode { get; set; }

        public string RunModeText { get; set; }

        public int TestSuitId { get; set; }
    }
}
