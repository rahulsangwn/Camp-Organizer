using Project.DAL.AccessMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Logic
{
    class TotalAmountCalculator
    {
        CampAccess _camp = new CampAccess();

        public int CalculateAmount(DateTime checkIn, DateTime checkOut, int campId)
        {
            return ((checkOut - checkIn).Days) * _camp.Get(campId).Price;
        }

    }
}
