﻿namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var validMovies = new List<Movie>();
            var sb = new StringBuilder();

            foreach (var movieDto in moviesDtos)
            {
                var isExist = validMovies.Any(m => m.Title == movieDto.Title);
                var isValidGenre = Enum.TryParse(typeof(Genre), movieDto.Genre, out object genre);
                var isValid = IsValid(movieDto);
                
                if (isExist || !isValidGenre || !isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = AutoMapper.Mapper.Map<Movie>(movieDto);

                validMovies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var validHalls = new List<Hall>();
            var sb = new StringBuilder();

            foreach (var hallSeatDto in hallsDtos)
            {
                if (!IsValid(hallSeatDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallSeatDto.Name,
                    Is3D = hallSeatDto.Is3D,
                    Is4Dx = hallSeatDto.Is4Dx,
                };

                for (int i = 0; i < hallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                validHalls.Add(hall);

                string status = "";
                if (hall.Is4Dx)
                {
                    status = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    status = "3D";
                }
                else
                {
                    status = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, status, hall.Seats.Count));
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Projection>();
            var sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var movie = context.Movies.Find(projectionDto.MovieId);
                var hall = context.Halls.Find(projectionDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerTicketDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();
            var sb = new StringBuilder();

            foreach (var customerDto in customersDto)
            {
                var projections = context.Projections.Select(x => x.Id).ToArray();
                var projectionExists = projections.Any(x => customerDto.Tickets.Any(s => s.ProjectionId != x));

                if (!IsValid(customerDto) && customerDto.Tickets.All(IsValid)
                    && projectionExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                };

                foreach (var ticket in customerDto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticket.ProjectionId,
                        Price = ticket.Price
                    });
                }

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}