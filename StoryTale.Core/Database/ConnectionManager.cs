using System.Data;
using System.Data.SqlClient;

namespace StoryTale.Core.Database
{
    public class ConnectionManager
    {
        public IDbConnection GetDb()
        {
            return new SqlConnection("Data Source=select;Initial Catalog=KielDb;Persist Security Info=True;User ID=select;Password=select");
        }
    }
}