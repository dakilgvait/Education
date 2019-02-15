using Client.OData.Config;
using Client.OData.Model;
using Microsoft.AspNet.OData.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;

namespace Client.OData.Common
{
    public class StartupDynamicSettings
    {
        public StartupDynamicSettings(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.EdmModel = new Lazy<IEdmModel>(this.GetEdmModel);
        }

        public IConfiguration Configuration { get; protected set; }

        public Lazy<IEdmModel> EdmModel { get; protected set; }

        public ApplicationConfiguration AppConfig
        {
            get
            {
                ApplicationConfiguration config = new ApplicationConfiguration();
                this.Configuration.Bind("ApplicationSection", config);
                return config;
            }
        }

        public ConnectionStringConfiguration ConnectionStringConfig
        {
            get
            {
                var config = new Dictionary<string, ConnectionStringConfiguration>();
                this.Configuration.Bind("ConnectionStringsSection", config);
                return config[this.AppConfig.DatabaseName];
            }
        }

        protected IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ODataTable1>("ODataTable1");
            builder.EntitySet<ODataTable2>("ODataTable2");
            return builder.GetEdmModel();
        }
    }
}