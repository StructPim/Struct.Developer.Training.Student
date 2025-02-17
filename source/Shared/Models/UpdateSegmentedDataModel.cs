using Struct.PIM.Api.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class UpdateSegmentedDataModel
    {
        public List<SegmentedData<string>> MarketingHeadline { get; set; }
    }
}
