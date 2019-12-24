using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using static Aruba.Core.ClimateTypes;

namespace Aruba.Data
{
    public interface IIslandData
    {
        public IEnumerable<Island> GetAllIslands();
    }

    public class InMemoryIslandData : IIslandData
    {
        readonly List<Island> Islands;

        public InMemoryIslandData()
        {
            Islands = new List<Island>()
            {
                new Island {
                    Id = 1,
                    ClimateType = ClimateType.Dry,
                    Name = "Aruba",
                    Rating = 5
                },
                new Island {
                    Id = 2,
                    ClimateType = ClimateType.Dry,
                    Name = "La Palma",
                    Rating = 5
                },
                new Island {
                    Id = 3,
                    ClimateType = ClimateType.Polar,
                    Name = "Spitbergen",
                    Rating = 2
                }
            };
        }


        public IEnumerable<Island> GetAllIslands()
        {
            return from i in Islands
                   orderby i.Name
                   select i;
        }
    }

}
