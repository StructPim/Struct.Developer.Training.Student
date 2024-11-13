using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Index.Models
{
    public class LookupRequest
    {
        public string CultureCode { get; set; }
        public string SearchQuery { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? CategoryId { get; set; }
    }
}
