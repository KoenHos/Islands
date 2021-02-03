using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aruba.Core;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Aruba.Data
{
    public class ElementSeeder
    {
        private readonly IslandDbContext _islandDbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ElementSeeder(IslandDbContext islandDbContext, IHostingEnvironment hosting)
        {
            _islandDbContext = islandDbContext;
            _hostingEnvironment = hosting;

        }

        public void Seed()
        {
            _islandDbContext.Database.EnsureCreated();

            if (! _islandDbContext.Elements.Any())
            {
                //seed
                var file = Path.Combine(_hostingEnvironment.ContentRootPath, "Aruba.Data/elements.json");
                var json = File.ReadAllText(file);
                var elements = JsonConvert.DeserializeObject<IEnumerable<Element>>(json);
                _islandDbContext.Elements.AddRange(elements);
                _islandDbContext.SaveChanges();
            }
        }
  }
}
