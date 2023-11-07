using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Models
{
    public class TestCaseStep
    {
        public int TestCaseStepId { get; set; }
        public int TestCaseId { get; set; }
        public int TestCaseStepSequence { get; set; }
        public int ActionKeyId { get; set; }
        public string TestCaseStepDesc { get; set; }
        public int LocatorTypeId { get; set; }
        public string Locator { get; set; }
        public string Varible { get; set; }
        public string Data { get; set; }
        public string PerformanceTrack { get; set; }
        public string TestCaseStepResult { get; set; }
        public string ExpMessage { get; set; }
        public bool ScreenShot { get; set; }
        public bool RunMode { get; set; }
    }
}
