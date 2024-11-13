using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Index.Models
{
    internal class Index<T> where T : IndexModel
    {
        public Guid Uid { get; set; }
        public IndexType Type { get; set; }
        public string Language { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public List<T> Documents { get; set; } = new List<T>();
    }
}
