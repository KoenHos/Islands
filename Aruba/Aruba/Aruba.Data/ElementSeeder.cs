using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Aruba.Data
{
    public class ElementSeeder : IElementSeeder
    {
        private readonly IslandDbContext _islandDbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<StoreUser> _userManager;

        public ElementSeeder(IslandDbContext islandDbContext, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _islandDbContext = islandDbContext;
            _hostingEnvironment = hosting;
            _userManager = userManager;

        }

        public async Task SeedAsync()
        {
            _islandDbContext.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("koenhos@hotmail.com");
            if (user == null)
            {
                user = new StoreUser
                {
                    FirstName = "Koen",
                    LastName = " Hos",
                    Email = "koenhos@hotmail.com",
                    UserName = "koenhos@hotmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
            }

            if (! _islandDbContext.Elements.Any())
            {
                //seed
                var file = Path.Combine(_hostingEnvironment.ContentRootPath, "../Aruba.Data/Elements.json");
                var json = File.ReadAllText("../Aruba.Data/Elements.json");
                var elements = JsonConvert.DeserializeObject<IEnumerable<Element>>(json);

                foreach (Element element in elements)
                {
                    element.User = user;
                }

                _islandDbContext.Elements.AddRange(elements);
                _islandDbContext.SaveChanges();
            }
        }
  }
}
