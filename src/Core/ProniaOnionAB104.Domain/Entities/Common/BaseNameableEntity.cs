using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Domain.Entities
{
    public class BaseNameableEntity:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
