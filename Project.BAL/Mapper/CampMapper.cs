using Project.BAL.Entities;
using Project.DAL.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Project.BAL.Mapper
{
    class CampMapper
    {
        public CampEntity CampToCampEntity(Camp camp)
        {
            var entity = new CampEntity()
            {
                CampId      = camp.CampId,
                Name        = camp.Name,
                Description = camp.Description,
                Capacity    = camp.Capacity,
                Image       = camp.Image,
                Rate        = camp.Price,
                Rating      = camp.Rating
            };

            return entity;
        }

        public Camp CampEntityToCamp(CampEntity entity)
        {
            var camp = new Camp()
            {
                CampId      = entity.CampId,
                Name        = entity.Name,
                Description = entity.Description,
                Capacity    = entity.Capacity,
                Image       = entity.Image,
                Price       = entity.Rate,
                Rating      = entity.Rating
            };

            return camp;
        }

        public List<Camp> CampEntityToCamp(List<CampEntity> entity)
        {
            var results = entity.Select(obj => CampEntityToCamp(obj)).ToList();
            return results;
        }

        public IEnumerable<CampEntity> CampToCampEntity(IEnumerable<Camp> camp)
        {
            var results = camp.Select(obj => CampToCampEntity(obj)).ToList();
            return results;
        }
    }
}
