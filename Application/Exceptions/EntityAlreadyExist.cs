using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityAlreadyExist : Exception
    {
        public EntityAlreadyExist()
        {
            
        }
        public EntityAlreadyExist(string msg) : base(msg)
        {
               
        }
    }
}
