using System;
using System.Collections.Generic;
using System.Text;

namespace Skinet.Core
{
    public interface IMapToCoreEntity<T> where T : BaseEntityCore
    {
        T ToCoreEntity();
    }
}
