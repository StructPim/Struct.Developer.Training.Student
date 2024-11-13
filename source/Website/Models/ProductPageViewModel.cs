using Shared.Index.Models;
using Struct.PIM.Models;

namespace Website.Models
{
    public class ProductPageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public BrandsGlobalListModel Brand { get; set; }
        public VariantIndexModel? Variant { get; set; }
        public List<VariantIndexModel> Variants { get; set; }
    }
}
