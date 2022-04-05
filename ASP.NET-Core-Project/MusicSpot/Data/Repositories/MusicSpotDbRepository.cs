namespace MusicSpot.Data.Repositories
{
    using MusicSpot.Data.Common;

    public class MusicSpotDbRepository : Repository, IMusicSpotDbRepository
    {
        public MusicSpotDbRepository(MusicSpotDbContext context)
        {
            this.Context = context;
        }
    }
}
