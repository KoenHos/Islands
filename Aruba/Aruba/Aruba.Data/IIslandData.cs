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
        int Commit();
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
                    Name = "Spitsbergen",
                    Rating = 2
                }
            };
        }


        public IEnumerable<Island> GetByName(string name = null)
        {
            return from i in Islands
                   where string.IsNullOrEmpty(name) || i.Name.Contains(name)
                   orderby i.Name, i.Rating
                   select i;
        }

        public Island GetById(int id)
        {
            return Islands.SingleOrDefault(i => i.Id == id);
        }

        public Island Add(Island newIsland)
        {
            Islands.Add(newIsland);
            newIsland.Id = Islands.Max(i => i.Id) + 1;
            return newIsland;
        }

        public Island Update(Island updatedIsland)
        {
            Island island = Islands.SingleOrDefault<Island>(i => i.Id == updatedIsland.Id);
            if (island != null)
            {
                island.Name = updatedIsland.Name;
                island.ClimateType = updatedIsland.ClimateType;
                island.Rating = updatedIsland.Rating;
            }
            return island;
        }

        public int Commit()
        {
            return 0;
        }

    }

}
