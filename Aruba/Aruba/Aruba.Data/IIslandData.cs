using System;
using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Data
{
    public interface IIslandData
    {
        public IEnumerable<Island> GetAllIslands();
    }
}
