using System.ComponentModel.DataAnnotations;

namespace RestAPI.Dtos
{
    public record UpdateItemDto
    {
     
        [Required]
        public string CarMake { get; init; }

        [Required]
        public string CarModel { get; init; }

        [Required]
        [Range(1, 5000000)]
        public decimal Price { get; init; }
    }
}