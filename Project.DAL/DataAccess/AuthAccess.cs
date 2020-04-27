using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.DataAccess
{
    public class AuthAccess
    {
        readonly CampContex _context;
        public AuthAccess()
        {
            _context = new CampContex();
        }

        public bool IsValid(string username, string password)
        {
            return _context.Users.Any(s => (s.Email == username && s.Password == password));
        }
    }
}
