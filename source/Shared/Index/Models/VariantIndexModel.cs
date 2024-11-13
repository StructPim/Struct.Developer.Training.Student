using Struct.PIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Index.Models
{
    public class VariantIndexModel : IndexModel
    {
        public string SKU { get; set; }
        public decimal? Price { get; set; }
        public MaterialGlobalListModel Material { get; set; }
        public string PrimaryImage { get; set; }
        public List<string> ExtraImages { get; set; }
    }
}
