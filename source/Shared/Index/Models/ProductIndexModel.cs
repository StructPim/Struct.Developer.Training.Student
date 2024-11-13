using Struct.PIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Index.Models
{
    public class ProductIndexModel : IndexModel
    {        
        public string StyleNumber { get; set; }
        public string Description { get; set; }
        public BrandsGlobalListModel Brand { get; set; }
        public List<VariantIndexModel> Variants { get; set; } = new List<VariantIndexModel>();
        public List<int> Categories { get; set; }
        public string ImageUrl { get; set; }
    }
}
