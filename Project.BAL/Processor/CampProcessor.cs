using Project.BAL.Entities;
using Project.DAL;
using Project.DAL.AccessMethods;
using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Processor
{
    public class CampProcessor
    {
        readonly CampAccess _camp;
        readonly BookingAccess _booking;
        public CampProcessor()
        {
            _camp = new CampAccess();
            _booking = new BookingAccess();
        }

        public void CreateCamp(CampEntity camp)
        {
            Camp newCamp = new Camp
            {
                Name        = camp.name,
                Description = camp.description,
                Capacity    = camp.capacity,
                Image       = camp.image,
                Price       = camp.rate
            };

            _camp.Create(newCamp);
        }

        public CampEntity GetCamp(int Id)
        {
            var camp = _camp.Get(Id);
            CampEntity entity = new CampEntity
            {
                campid      = camp.CampId,
                name        = camp.Name,
                description = camp.Description,
                image       = camp.Image,
                rate        = camp.Price,
                capacity    = camp.Capacity
            };

            return entity;
        }

        public IEnumerable<CampEntity> GetAllCamps(FilterEntity filter)
        {
            var bookedCamps = _booking.CampBookedBetween(filter.CheckInDate, filter.CheckOutDate);
            var unbookedCamps = _camp.Get(bookedCamps);

            if (filter.Capacity != 0)
            {
                unbookedCamps = unbookedCamps.Where(s => s.Capacity == filter.Capacity).ToList();
            } 

            List<CampEntity> entities = new List<CampEntity>();
            foreach(var camp in unbookedCamps)
            {
                CampEntity entity = new CampEntity
                {
                    campid      = camp.CampId,
                    name        = camp.Name,
                    description = camp.Description,
                    image       = camp.Image,
                    rate        = camp.Price,
                    capacity    = camp.Capacity
                };

                entities.Add(entity);
            }

            return entities;
        }
    }
}
