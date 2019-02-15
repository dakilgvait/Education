using Client.OData.Config;

namespace Client.OData.Model.Startup
{
    public class ConfigureServicesModel
    {
        public ApplicationConfiguration AppConfig { get; set; }
        public ConnectionStringConfiguration ConnectionStringConfig { get; set; }
    }
}