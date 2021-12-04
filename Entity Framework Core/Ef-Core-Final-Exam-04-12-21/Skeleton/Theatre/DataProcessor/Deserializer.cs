namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Theatre.Data;
    using Theatre.DataProcessor.ImportDto;
    using Theatre.Data.Models;
    using System.Xml.Serialization;
    using System.IO;
    using Theatre.Data.Models.Enums;
    using System.Globalization;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlaysDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportPlaysDto[] playsDtos = (ImportPlaysDto[])xmlSerializer.Deserialize(sr);

            var plays = new List<Play>();

            foreach (var play in playsDtos)
            {

                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (TimeSpan.Parse(play.Duration).Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenre = Enum.TryParse(typeof(Genre), play.Genre, out var genre);

                bool isDuration = TimeSpan.TryParseExact(
                                        play.Duration, "c", CultureInfo.InvariantCulture, out var duration);

                if (!isGenre || !isDuration)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                

                var p = new Play()
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = play.Rating,
                    Genre = (Genre)genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };



                plays.Add(p);

                sb.AppendLine(String.Format(SuccessfulImportPlay,
                    p.Title, p.Genre, p.Rating));

            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastsDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportCastsDto[] castsDtos = (ImportCastsDto[])xmlSerializer.Deserialize(sr);

            var casts = new List<Cast>();

            foreach (var castDto in castsDtos)
            {

                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId

                };


                casts.Add(cast);

                string character = cast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(String.Format(SuccessfulImportActor,
                    cast.FullName, character));

            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportProjectionJsonDto[] projectionDto = JsonConvert.DeserializeObject<ImportProjectionJsonDto[]>(jsonString);

            var theaters = new List<Theatre>();

            foreach (var theater in projectionDto)
            {
                if (!IsValid(theater))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var t = new Theatre()
                {
                    Name = theater.Name,
                    NumberOfHalls = theater.NumberOfHalls,
                    Director = theater.Director
                };

                foreach (var ticket in theater.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currTicket = new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };

                    t.Tickets.Add(currTicket);

                }

                theaters.Add(t);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, t.Name, t.Tickets.Count()));
            }

            context.Theatres.AddRange(theaters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
