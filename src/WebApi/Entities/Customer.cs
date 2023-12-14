using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FirstName { get; init; }
        
        [Required]
        public string LastName { get; init; }
    }
}