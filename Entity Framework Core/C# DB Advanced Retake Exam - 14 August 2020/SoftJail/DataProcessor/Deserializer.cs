namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentsCellsDto[] departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString);

            var departments = new List<Department>();

            foreach (var department in departmentsDto)
            {
                if (!IsValid(department))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (department.Cells.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (department.Cells.Any(c => c.CellNumber < 1 || c.CellNumber > 1000))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currDepartment = new Department()
                {
                    Name = department.Name,
                    Cells = department.Cells
                        .Select(c => new Cell()
                        {
                            CellNumber = c.CellNumber,
                            HasWindow = c.HasWindow
                        })
                        .ToArray()
                };

                departments.Add(currDepartment);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonersMailsDto[] prisonersMailDto = JsonConvert.DeserializeObject<ImportPrisonersMailsDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisoner in prisonersMailDto)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!prisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                // DateTime is required so we dont need to do TryParse
                var incarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                             
                // datetime? can be null so we need to do TryParse

                var isValidReleaseDate = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);
                               

                var currPrisoner = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = prisoner.Mails
                        .Select(m=> new Mail()
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        }).ToArray()
                };

                prisoners.Add(currPrisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisonersDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportOfficersPrisonersDto[] OfficerPrisonerDtos = (ImportOfficersPrisonersDto[])xmlSerializer.Deserialize(sr);

            var officers = new List<Officer>();

            foreach (var officer in OfficerPrisonerDtos)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //Position position;

                //var isPositionValid = Enum.TryParse(officer.Position, out position);

                //Weapon weapon;

                //var isWeaponValid = Enum.TryParse(officer.Weapon, out weapon);

                //if (!isPositionValid || !isWeaponValid)
                //{
                //    sb.AppendLine("Invalid Data");

                //    continue;
                //}


                var currOfficer = new Officer()
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = Enum.Parse<Position>(officer.Position),
                    Weapon = Enum.Parse<Weapon>(officer.Weapon),
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners
                        .Select(x => new OfficerPrisoner
                        {
                            PrisonerId = x.Id

                        }).ToArray()
                };

                officers.Add(currOfficer);

                sb.AppendLine($"Imported {officer.Name} ({officer.Prisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}