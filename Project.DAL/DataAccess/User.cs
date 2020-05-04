namespace Project.DAL.DataAccess
{
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Key]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Role { get; set; }
    }
}
