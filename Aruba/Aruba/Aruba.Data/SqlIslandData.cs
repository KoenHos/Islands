using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using Microsoft.EntityFrameworkCore;

namespace Aruba.Data
{
    public class SqlIslandData : IIslandData
    {
        private readonly IslandDbContext db;

        public SqlIslandData(IslandDbContext db)
        {
            this.db = db;
        }

        public Island Add(Island newIsland)
        {
            db.Islands.Add(newIsland);
            return newIsland;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Island delete(int id)
        {
            var island = GetById(id);
            if (island != null)
            {
                db.Islands.Remove(island);
            }
            return island;
        }

        public Island GetById(int id)
        {
            return db.Islands.Find(id);
        }

        public IEnumerable<Island> GetByName(string name)
        {
            var query = from i in db.Islands
#pragma warning disable RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        where i.Name.StartsWith(name) || string.IsNullOrEmpty(name)
#pragma warning restore RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        select i;
            return query;
        }

        public Island Update(Island updatedIsland)
        {
            var entity = db.Islands.Attach(updatedIsland);
            entity.State = EntityState.Modified;
            return updatedIsland;
        }
    }
}
