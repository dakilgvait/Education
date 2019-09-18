using Person.DAL.Entity;
using Person.DTO;

namespace DashboardApplication.Models.DataTable
{
    public class ResponseAjaxPostModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public PersonViewModel[] data { get; set; }
    }
}