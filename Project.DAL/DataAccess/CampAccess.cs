using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.DataAccess
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

        public IEnumerable<Camp> Get()
        {
            return _context.Camps.ToList();
        }
        public Camp Get(int Id)
        {
            return _context.Camps.First(s => s.CampId == Id);
        }
    }
}
