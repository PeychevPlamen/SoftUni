namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .ToArray()
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(g => g.Purchases.Any())
                    .ToArray()
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Select(z=>z.Purchases.Count).Sum()

                })
                .OrderByDescending(x=>x.TotalPlayers)
                .ThenBy(x=>x.Id)
                .ToArray();

            return JsonConvert.SerializeObject(genres, Formatting.Indented);

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            throw new NotImplementedException();
        }
    }
}