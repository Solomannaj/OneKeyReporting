using DataExtractionTool.DataLayer.Models;


namespace DataExtractionTool.DataLayer.Repositories
{
    public class UserRepository : Repository<DataExtractionUsers>, IUserRepository
    {
        public UserRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class ActionKeyRepository : Repository<ActionKey>, IActionKeyRepository
    {
        public ActionKeyRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class LocatorTypeRepository : Repository<LocatorType>, ILocatorTypeRepository
    {
        public LocatorTypeRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class TestSuitRepository : Repository<TestSuit>, ITestSuitRepository
    {
        public TestSuitRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class TestCaseRepository : Repository<TestCase>, ITestCaseRepository
    {
        public TestCaseRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class TestCaseStepRepository : Repository<TestCaseStep>, ITestCaseStepRepository
    {
        public TestCaseStepRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class MatsocResultRepository : Repository<MatsocResult>, IMatsocResultRepository
    {
        public MatsocResultRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    public class HCPTypeResultRepository : Repository<HCPTypeResult>, IHCPTypeResultRepository
    {
        public HCPTypeResultRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }

    
}
