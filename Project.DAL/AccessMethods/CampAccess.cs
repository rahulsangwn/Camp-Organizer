using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
