using Client.OData.Config;
using Client.OData.Context;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Client.OData.Controllers
{
    public class TestController : ODataController
    {
        private readonly TestContext _dbContext;

        public TestController(TestContext dbContext, IOptions<ApplicationConfiguration> options)
        {
            this._dbContext = dbContext;
        }

        [EnableQuery]
        [ODataRoute("ODataTable1", RouteName = "ODataTest")]
        public IActionResult GetODataTable1All()
        {
            var data = this._dbContext.ODataTable1;
            return Ok(data);
        }

        [EnableQuery]
        [ODataRoute("ODataTable2", RouteName = "ODataTest")]
        public IActionResult GetAllRecords()
        {
            return Ok(_dbContext.ODataTable2);
        }
    }
}