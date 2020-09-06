using System;
using System.Collections.Generic;
using System.Text;

namespace Skinet.Core
{
    public class ProductType : BaseEntityCore
    {
        public string Name { get; set; }

        public ProductType(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
