using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Index.Models
{
    public abstract class IndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
