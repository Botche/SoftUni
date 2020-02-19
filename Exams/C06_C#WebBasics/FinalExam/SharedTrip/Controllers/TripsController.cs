using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.Services.Interfaces;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var allTrips = this.tripsService.GetAll();

            return this.View(allTrips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(input.StartPoint)
                || string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            var isParsedDate = DateTime.TryParse(input.DepartureTime, out DateTime parsedDate);
            if (!isParsedDate)
            {
                return this.Redirect("/Trips/Add");
            }

            var isParsedSeats = int.TryParse(input.Seats, out int parsedSeats);
            if (!isParsedSeats || parsedSeats < 2 || parsedSeats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.AddTrip(input.StartPoint,
                input.EndPoint,
                parsedDate,
                parsedSeats,
                input.Description,
                input.ImagePath);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var trip = this.tripsService.GetTripById(tripId);

            if (trip == null)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var trip = this.tripsService.GetTripById(tripId);

            if (trip == null)
            {
                return this.Redirect("/Trips/All");
            }

            bool isAlreadyRegistered = this.tripsService.AddPersonToTrip(this.User, trip);

            if (isAlreadyRegistered)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            return this.Redirect("/Trips/All");
        }
    }
}
