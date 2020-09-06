using System;
using System.Collections.Generic;
using System.Text;

namespace Skinet.Core
{
    public class ProductBrand : BaseEntityCore
    {
        public string Name { get; set; }

        public ProductBrand(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
