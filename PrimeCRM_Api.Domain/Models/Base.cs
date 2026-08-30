using System.ComponentModel.DataAnnotations;

namespace PrimeCRM_Api.Domain.Models
{
    public abstract class Base
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

    }
}