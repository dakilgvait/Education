using System.Collections.Generic;

namespace DashboardApplication.Models.DataTable
{
    public class RequstAjaxPostModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<ColumnModel> columns { get; set; }
        public SearchModel search { get; set; }
        public List<OrderModel> order { get; set; }
    }
}