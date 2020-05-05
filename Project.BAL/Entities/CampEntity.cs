using System.ComponentModel.DataAnnotations;

namespace Project.BAL.Entities
{
    public class CampEntity
    {
        [Required]
        public int CampId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int Capacity { get; set; }
        public int Rating { get; set; }
    }
}
