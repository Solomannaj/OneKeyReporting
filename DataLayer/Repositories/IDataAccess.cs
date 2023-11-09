using DataExtractionTool.DataLayer.Models;

namespace DataExtractionTool.DataLayer.Repositories
{
    public interface IUserRepository : IRepository<DataExtractionUsers>
    {
    }

    public interface IMatsocResultRepository : IRepository<MatsocResult>
    {
    }

    public interface IHCPTypeResultRepository : IRepository<HCPTypeResult>
    {
    }

    public interface IReportResultRepository : IRepository<ReportResult>
    {
    }


}
