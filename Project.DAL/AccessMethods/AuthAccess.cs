using Project.DAL.DataAccess;
using System.Linq;

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
