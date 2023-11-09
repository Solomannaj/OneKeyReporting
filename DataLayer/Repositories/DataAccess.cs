using DataExtractionTool.DataLayer.Models;


namespace DataExtractionTool.DataLayer.Repositories
{
    public class UserRepository : Repository<DataExtractionUsers>, IUserRepository
    {
        public UserRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
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

    public class ReportResultRepository : Repository<ReportResult>, IReportResultRepository
    {
        public ReportResultRepository(DataExtractionToolContext DataExtractionToolContext) : base(DataExtractionToolContext)
        {
        }

    }


}
