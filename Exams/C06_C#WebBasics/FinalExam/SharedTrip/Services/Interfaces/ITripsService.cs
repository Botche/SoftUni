using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services.Interfaces
{
    public interface ITripsService
    {
        IEnumerable<AllTripsViewModel> GetAll();

        void AddTrip(string startPoint, string EndPoint, DateTime departureTime,int seats,string description,string imagePath);

        TripDetailsViewModel GetTripById(string id);

        bool AddPersonToTrip(string user, TripDetailsViewModel trip);
    }
}
