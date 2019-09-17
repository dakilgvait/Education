namespace DashboardApplication.Models.DataTable
{
    public class ColumnModel
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public SearchModel search { get; set; }
    }
}