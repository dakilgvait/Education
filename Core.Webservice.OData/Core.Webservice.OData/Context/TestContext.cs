using Client.OData.Model;
using Microsoft.EntityFrameworkCore;

namespace Client.OData.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ODataTable1> ODataTable1 { get; set; }
        public DbSet<ODataTable2> ODataTable2 { get; set; }
    }
}