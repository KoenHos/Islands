using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using static Aruba.Core.ClimateType;

namespace Aruba.Data
{
    public interface IIslandDataService
    {
        IEnumerable<Island> GetByName(string name);
        Island GetById(int id);
        Island Update(Island island);
        Island Add(Island island);
        Island Delete(int id);
        int GetCountOfIslands();
        int Commit();
    }

}
