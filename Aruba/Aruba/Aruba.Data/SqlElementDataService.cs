using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using Microsoft.EntityFrameworkCore;

namespace Aruba.Data
{
    public class SqlElementDataService : IElementDataService
    {
        private readonly IslandDbContext db;

        public SqlElementDataService(IslandDbContext db)
        {
            this.db = db;
        }

        public Element Add(Element element)
        {
            db.Elements.Add(element);
            return element;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Element Delete(int id)
        {
            var element = GetById(id);
            if (element != null)
            {
                db.Elements.Remove(element);
            }
            return element;
        }

        public Element GetById(int id)
        {
            return db.Elements.Find(id);
        }

        public IEnumerable<Element> GetByName(string name)
        {
            var query = from i in db.Elements
#pragma warning disable RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        where i.Name.StartsWith(name) || string.IsNullOrEmpty(name)
#pragma warning restore RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        select i;
            return query.OrderBy( i => i.Name);
        }

        public int GetCountOfIElements()
        {
            return db.Elements.Count();
        }

        public Element Update(Element element)
        {
            var entity = db.Elements.Attach(element);
            entity.State = EntityState.Modified;
            return element;
        }
    }
}
