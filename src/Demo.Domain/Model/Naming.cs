using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Domain.Model
{
    public class Naming
    {
        public string MakeFullName(string firstName, string lastName)
		{
			return $"{firstName} {lastName}";
		}
        
    }
}