using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Processor
{
    public class AuthProcessor
    {
        readonly AuthAccess _user;
        public AuthProcessor()
        {
            _user = new AuthAccess();
        }

        public bool IsValid(string username, string password)
        {
            if (_user.IsValid(username, password))
            {
                return true;
            }
            else return false;
        }
    }
}
