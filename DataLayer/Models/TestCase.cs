using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Models
{
    public class TestCase
    {
        public int TestCaseId { get; set; }

        public string TestCaseName { get; set; }

        public bool RunMode { get; set; }

        public int TestSuitId { get; set; }
    }
}
