using System;
using Aruba.Core;
using Microsoft.EntityFrameworkCore;

// https://database.guide/how-to-install-sql-server-on-a-mac/
// https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

namespace Aruba.Data
{
    public class IslandDbContext : DbContext
    {
        public DbSet<Island> Islands { get; set; }

        public IslandDbContext(DbContextOptions<IslandDbContext> options) : base(options)
        {

        }
    }

}

