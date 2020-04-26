using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Entities
{
    public class CampEntity
    {
        public int campid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int rate { get; set; }
        public string image { get; set; }
        public int capacity { get; set; }
    }
}
