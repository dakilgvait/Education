using Person.DTO;
using System.Linq;

namespace DashboardApplication.Models.Select2
{
    public class ResponseAjaxPostModel
    {
        public ResponseAjaxPostModel(GenderModel[] models)
        {
            this.items = models.Select(i => this.ConvertToItem(i)).ToArray();
        }

        protected ItemModel ConvertToItem(GenderModel model)
        {
            return new ItemModel()
            {
                Id = model.Id,
                Text = model.Name
            };
        }

        public ItemModel[] items { get; set; }
    }
}