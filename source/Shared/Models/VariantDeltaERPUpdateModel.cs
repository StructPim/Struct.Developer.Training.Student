using Struct.PIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class VariantDeltaERPUpdateModel
    {
        public MaterialGlobalListModel Material { get; set; }
        public decimal? BaseCostPrice { get; set; }
        public ColorsGlobalListModel Color { get; set; }
        public PackageSizeModel PackageSize { get; set; }
        public string SKU { get; set; }
        public decimal? Weight { get; set; }
        public string Size { get; set; }
    }
}
