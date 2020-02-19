using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SharedTrip.Models;
using SharedTrip.Services.Interfaces;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AddPersonToTrip(string userId, TripDetailsViewModel trip)
        {
            var tripDb = this.db.Trips
                .Include(tripFromDb=>tripFromDb.UserTrips)
                .FirstOrDefault(tripToFind => tripToFind.Id == trip.Id);

            if (tripDb.UserTrips.Select(userTrip => userTrip.UserId).ToList().Contains(userId)
                || tripDb.Seats - tripDb.UserTrips.Select(userTrip => userTrip.UserId).Count() == 0)
            {
                return true;
            }

            this.db.UsersTrips.Add(new UserTrip
            {
                TripId = tripDb.Id,
                UserId = userId
            });

            this.db.SaveChanges();

            return false;
        }

        public void AddTrip(string startPoint, string EndPoint, DateTime departureTime, int seats, string description, string imagePath)
        {
            var trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = EndPoint,
                Description = description,
                DepartureTime = departureTime,
                Seats = seats,
                ImagePath = imagePath
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<AllTripsViewModel> GetAll()
            => this.db.Trips
            .Select(trip => new AllTripsViewModel
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm",
                      CultureInfo.InvariantCulture),
                Seats = trip.Seats - trip.UserTrips.Count(user => user.TripId == trip.Id)
            })
            .ToArray();

        public TripDetailsViewModel GetTripById(string id)
            => this.db.Trips
            .Where(trip => trip.Id == id)
            .Select(trip => new TripDetailsViewModel()
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm",
                      CultureInfo.InvariantCulture),
                Seats = trip.Seats - trip.UserTrips.Count(user => user.TripId == id),
                Description = trip.Description,
                ImagePath = trip.ImagePath
            })
            .FirstOrDefault();
    }
}
