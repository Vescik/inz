using System.ComponentModel.DataAnnotations;

namespace Contractor.API.Entities
{
    public class Contractor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Nip { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }
    }
}
