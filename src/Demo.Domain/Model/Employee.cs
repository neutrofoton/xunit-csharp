using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Demo.Domain.Model
{
    public class Employee : BaseModel<int>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public int Age {get;set;}

    }
}