using DataExtractionTool.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Repositories
{
    public class ADORepository: IADORepository
    {
        public ADORepository() { }
        public async Task<DataTable> GetDataTable(string spName, SqlParameter [] inputParameter,string country) {

            SqlConnection con = new SqlConnection(AppSettings.GetConnectinString(country));
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            if(inputParameter != null)
            {
                cmd.Parameters.AddRange(inputParameter);
            }
           
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            await Task.Run(() => da.Fill(dt));          

            return dt;

        }

    }
}
