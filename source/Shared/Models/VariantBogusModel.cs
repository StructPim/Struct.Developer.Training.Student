using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    /// <summary>
    /// Model reflecting the variant data structure in the bogus data
    /// </summary>
    public class VariantBogusModel
    {
        public string Sku { get; set; }
        public string Color { get; set; }
        public string Definition { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public PackageSize PackageSize { get; set; }
        public decimal Weight { get; set; }
        public decimal BaseCostPrice { get; set; }
        public string StyleNo { get; set; }
    }
    public class PackageSize
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
    }
}
