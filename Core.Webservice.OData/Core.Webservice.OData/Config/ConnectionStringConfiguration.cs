using System.Data.SqlClient;

namespace Client.OData.Config
{
    public class ConnectionStringConfiguration
    {
        public string ProviderName { get; set; }
        public SqlConnectionStringBuilder ConnectionStringBuilder { get; set; }
    }
}