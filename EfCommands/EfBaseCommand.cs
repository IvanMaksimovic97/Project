using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class EfBaseCommand
    {
        protected readonly Context context;

        public EfBaseCommand(Context context)
        {
            this.context = context;
        }
        
    }
}
