using Project.BAL.Entities;
using Project.BAL.Mapper;
using Project.DAL.AccessMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.BAL.Processor
{
    public class CampProcessor
    {
        readonly CampAccess _camp;
        readonly BookingAccess _booking;
        readonly CampMapper _cmapper;
        public CampProcessor()
        {
            _camp    = new CampAccess();
            _booking = new BookingAccess();
            _cmapper = new CampMapper();
        }

        public void CreateCamp(CampEntity camp)
        {
            _camp.Create(_cmapper.CampEntityToCamp(camp));
        }

        public IEnumerable<CampEntity> GetAllCamps()
        {
            return _cmapper.CampToCampEntity(_camp.GetAll());
        }

        public CampEntity GetCamp(int Id)
        {
            return _cmapper.CampToCampEntity(_camp.Get(Id));
        }

        public void DeleteCamp(int id)
        {
            _booking.DeleteBooking(id);
            _camp.Delete(id);
        }

        public void UpdateCamp(CampEntity camp)
        {
            _camp.Update(_cmapper.CampEntityToCamp(camp));
        }

        public IEnumerable<CampEntity> GetCamps(FilterEntity filter)
        {
            var bookedCamps   = _booking.CampBookedBetween(filter.CheckInDate, filter.CheckOutDate);
            var unbookedCamps = _camp.Get(bookedCamps);

            if (filter.Capacity != 0)
            {
                unbookedCamps = unbookedCamps.Where(s => s.Capacity == filter.Capacity).ToList();
            } 

            return _cmapper.CampToCampEntity(unbookedCamps);
        }

        public void SetRating(string bookingRef, int rating)
        {
            var campId = _booking.Get(bookingRef).CampId;
            int[] ratings = _booking.SetAndGetRatings(bookingRef, rating);

            int roundedRating = (int)Math.Round(ratings.Average(), MidpointRounding.AwayFromZero);
            _camp.SetRating(roundedRating, campId);
        }
    }
}
