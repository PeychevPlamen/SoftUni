using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicSpot.Data
{
    public class MusicSpotDbContext : IdentityDbContext
    {
        public MusicSpotDbContext(DbContextOptions<MusicSpotDbContext> options)
            : base(options)
        {
        }
    }
}