using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aruba.Core;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Aruba.Data
{
    public class ElementSeeder : IElementSeeder
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
                var file = Path.Combine(_hostingEnvironment.ContentRootPath, "../Aruba.Data/Elements.json");
                var json = File.ReadAllText("../Aruba.Data/Elements.json");
                var elements = JsonConvert.DeserializeObject<IEnumerable<Element>>(json);
                _islandDbContext.Elements.AddRange(elements);
                _islandDbContext.SaveChanges();
            }
        }
  }
}
