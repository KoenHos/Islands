using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aruba.Data
{
    public class SqlElementDataService : IElementDataService
    {
        private readonly IslandDbContext _db;
        private readonly ILogger _logger;

        public SqlElementDataService(IslandDbContext db, ILogger<SqlElementDataService> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public Element Add(Element element)
        {
            try
            {
                _logger.LogInformation($"Add element: {element.Name}");
                _db.Elements.Add(element);               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add element: {element.Name} - {ex}");
            };
            return element;

        }

        //Todo Add try catch
        public bool Commit()
        {
            _logger.LogInformation($"Commit - Save all changes");
            _db.SaveChanges();
            return true;
            //return db.SaveChanges() > 0;
        }

        public Element Delete(int id)
        {
            try
            {
                var element = GetById(id);

                if (element != null)
                {
                    _logger.LogInformation($"Delete element: {element.Name}");
                    _db.Elements.Remove(element);
                }
                return element;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete element with id: {id} - {ex}");
            };
            return null;
        }


        //Todo Add try catch
        public void Truncate()
        {
            _logger.LogInformation($"Truncate elements tabe");

            TruncateOccurence();  //ToDO: refactor this

            var elements = GetByName("");
            _db.Elements.RemoveRange(elements);
        }

        //Todo Add try catch
        public Element GetById(int id)
        {
            return _db.Elements.Find(id);
        }

        //Todo Add try catch
        public IEnumerable<Element> GetByName(string name)
        {
            var query = from i in _db.Elements
#pragma warning disable RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        where i.Name.StartsWith(name) || string.IsNullOrEmpty(name)
#pragma warning restore RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        select i;
            return query.OrderBy( i => i.Name);
        }

        //Todo Add try catch
        public int GetCountOfIElements()
        {
            return _db.Elements.Count();
        }

        public Element Update(Element element)
        {
            try
            {
                _logger.LogInformation($"Update element: {element.Name}");

                var entity = _db.Elements.Attach(element);
                entity.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update element: {element.Name} - {ex}");
            };

            return element;
        }

        public IEnumerable<Element> GetByUserAndName(string username, string name)
        {
            var query = from i in _db.Elements
#pragma warning disable RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        where (i.Name.StartsWith(name) || string.IsNullOrEmpty(name)) && i.User.UserName == username
#pragma warning restore RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.
                        select i;
            return query.OrderBy(i => i.Name);
        }

        // ElementOccurences --> Move to separate class? ==============================================

        public ElementOccurrence Add(ElementOccurrence elementOccurrence)
        {
            try
            {
                _logger.LogInformation($"Add element: {elementOccurrence.Name}");
                _db.ElementOccurrences.Add(elementOccurrence);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add element: {elementOccurrence.Name} - {ex}");
            };
            return elementOccurrence;
        }

        //Todo Add try catch
        public IEnumerable<ElementOccurrence> GetOccurrenceByElementId(int id)
        {
            return _db.ElementOccurrences.Where(e => e.Element == _db.Elements.Find(id));
        }

        //Todo Add try catch
        public bool TruncateOccurence()
        {
            _logger.LogInformation($"Truncate elements tabe");

            var occurences = _db.ElementOccurrences.Where(e => !string.IsNullOrEmpty(e.Description));

            try
            {
                _db.ElementOccurrences.RemoveRange(occurences);
                _db.SaveChanges();
            }
            catch
            {

            }
            return true;
        }

     
    }
}
