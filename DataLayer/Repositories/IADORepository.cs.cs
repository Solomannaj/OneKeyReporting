using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Repositories
{
    public interface IADORepository
    {
        Task<DataTable> GetDataTable(string spName, SqlParameter[] inputParameter);
    }
}
