using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.AccessMethods
{
    public class AuthAccess
    {
        readonly CampContext _context;
        public AuthAccess()
        {
            _context = new CampContext();
        }

        public bool IsValid(string username, string password)
        {
            return _context.Users.Any(s => (s.Email == username && s.Password == password));
        }
    }
}
