namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Sum(t => t.Price),
                    Tickets = t.Tickets
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .ToArray()
                        .Select(x => new
                        {
                            Price = x.Price,
                            RowNumber = x.RowNumber
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()

                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlaysDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            var isRatingZero = context.Plays.FirstOrDefault(x => x.Rating == 0);

            var plays = context.Plays
                .Where(p => p.Rating <= rating)
                .ToArray()
                .Select(p => new ExportPlaysDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(), // ???? string and float
                    Genre = p.Genre.ToString(),
                    Actor = p.Casts
                    .Where(c => c.IsMainCharacter)
                    .Select(c => new ActorsDto
                    {
                        FullName = c.FullName,
                        MainCharacter = String.Format($"Plays main character in '{c.Play.Title}'.")
                    })
                    .OrderByDescending(c => c.FullName)  // c or p ??
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            xmlSerializer.Serialize(sw, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
