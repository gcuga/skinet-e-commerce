using System;
using System.Collections.Generic;
using System.Text;

namespace Skinet.Core
{
    public class BaseEntityCore
    {
        public int Id { get; set; }

        public BaseEntityCore(int id)
        {
            Id = id;
        }
    }
}
