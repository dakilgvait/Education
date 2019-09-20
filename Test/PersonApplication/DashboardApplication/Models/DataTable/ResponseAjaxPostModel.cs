using Person.DAL.Entity;
using Person.DTO;

namespace DashboardApplication.Models.DataTable
{
    public class ResponseAjaxPostModel
    {
        private PersonViewModel[] persons;

        public ResponseAjaxPostModel(PersonViewModel[] persons)
        {
            this.recordsTotal = persons.Length;
            this.data = persons;
        }

        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public PersonViewModel[] data { get; set; }
    }
}