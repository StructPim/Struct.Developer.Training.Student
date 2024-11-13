using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    /// <summary>
    /// Model reflecting the product data structure in the bogus data
    /// </summary>
    public class ProductBogusModel
    {
        public string NameEng { get; set; }
        public string NameDa { get; set; }
        public string StyleNo { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string CountryOfOrigin { get; set; }
        public List<string> SaleChannels { get; set; }
        public string ErpType { get; set; }
    }
}
