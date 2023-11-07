using DataExtractionTool.DataLayer.Models;

namespace DataExtractionTool.DataLayer.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public interface IActionKeyRepository : IRepository<ActionKey>
    {
    }

    public interface ILocatorTypeRepository : IRepository<LocatorType>
    {
    }

    public interface ITestSuitRepository : IRepository<TestSuit>
    {
    }

    public interface ITestCaseRepository : IRepository<TestCase>
    {
    }
    public interface ITestCaseStepRepository : IRepository<TestCaseStep>
    {
    }


}
