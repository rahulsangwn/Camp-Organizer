using Project.DAL.DataAccess;
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
            var camp = _context.Camps.FirstOrDefault(s => s.CampId == id);

            if (camp != null)
            {
                _context.Camps.Remove(camp);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Camp> GetAll()
        {
            return _context.Camps.ToList();
        }
    }
}
