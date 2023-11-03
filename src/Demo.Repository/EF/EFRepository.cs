using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repository.EF
{
    public abstract class EFRepository
    {
        private EFContext efContext;
        public EFRepository(EFContext efContext){

            this.efContext=efContext;
        }

        protected EFContext EFContext
        {
            get{return efContext;}
        }
    }
}