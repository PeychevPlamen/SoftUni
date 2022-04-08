using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSpot.Test
{
    public class InMemoryDbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<MusicSpotDbContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<MusicSpotDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new MusicSpotDbContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public MusicSpotDbContext CreateContext() => new MusicSpotDbContext(dbContextOptions);

        public void Dispose() => connection.Dispose();
    }
}
