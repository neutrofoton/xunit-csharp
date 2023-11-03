using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class BaseModel<TId>
    {
        public TId Id { get; set; }

    }
}