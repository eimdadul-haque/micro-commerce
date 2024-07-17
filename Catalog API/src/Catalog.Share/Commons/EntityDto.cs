using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Share.Commons
{
    public class EntityDto<T>
    {
        public T Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime modified { get; set; }
        public string CreatorId { get; set; }
        public string modifierId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
