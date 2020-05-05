using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.DAL.AccessMethods
{
    public class CampAccess
    {
        readonly CampContext _context;
        public CampAccess()
        {
            _context = new CampContext();
        }

        public void Create(Camp camp)
        {
            _context.Camps.Add(camp);
            _context.SaveChanges();
        }

        public IEnumerable<Camp> Get(List<int> bookedCampsId)
        {
            return _context.Camps
                .Where(s => !bookedCampsId.Contains(s.CampId)).ToList();
        }
        public Camp Get(int Id)
        {
            return _context.Camps.FirstOrDefault(s => s.CampId == Id);
        }

        public void Delete(int id)
        {
            if (_context.Camps.Any(s => s.CampId == id))
            {
                var camp = _context.Camps.FirstOrDefault(s => s.CampId == id);
                _context.Camps.Remove(camp);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Camp> GetAll()
        {
            return _context.Camps.ToList();
        }

        public void Update(Camp camp)
        {
            var obj = _context.Camps.FirstOrDefault(c => c.CampId == camp.CampId);

            obj.Bookings = camp.Bookings;
            obj.Capacity = camp.Capacity;
            obj.Description = camp.Description;
            obj.Image = camp.Image;
            obj.Name = camp.Name;
            obj.Price = camp.Price;
            obj.Rating = camp.Rating;

            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
