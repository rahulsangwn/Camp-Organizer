using Project.BAL.Entities;
using Project.DAL;
using Project.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Processor
{
    public class CampProcessor
    {
        readonly CampAccess _camp;
        public CampProcessor()
        {
            _camp = new CampAccess();
        }

        public void CreateCamp(CampEntity camp)
        {
            Camp newCamp = new Camp
            {
                Name = camp.name,
                Description = camp.description,
                Capacity = camp.capacity,
                Image = camp.image,
                Price = camp.rate
            };

            _camp.Create(newCamp);
        }

        public CampEntity GetCamp(int Id)
        {
            var camp = _camp.Get(Id);
            CampEntity entity = new CampEntity
            {
                campid = camp.CampId,
                name = camp.Name,
                description = camp.Description,
                image = camp.Image,
                rate = camp.Price,
                capacity = camp.Capacity
            };

            return entity;
        }

        public IEnumerable<CampEntity> GetAllCamps()
        {
            var camps = _camp.Get();
            List<CampEntity> entities = new List<CampEntity>();
            foreach(var camp in camps)
            {
                CampEntity entity = new CampEntity
                {
                    campid = camp.CampId,
                    name = camp.Name,
                    description = camp.Description,
                    image = camp.Image,
                    rate = camp.Price,
                    capacity = camp.Capacity
                };

                entities.Add(entity);
            }

            return entities;
        }
    }
}
