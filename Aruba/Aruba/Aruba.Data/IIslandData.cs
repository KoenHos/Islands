using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using static Aruba.Core.ClimateType;

namespace Aruba.Data
{
    public interface IIslandData
    {
        IEnumerable<Island> GetByName(string name);
        Island GetById(int id);
        Island Update(Island island);
        Island Add(Island island);
        Island delete(int id);
        int Commit();
    }

}
