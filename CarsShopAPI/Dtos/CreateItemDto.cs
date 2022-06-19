using System.ComponentModel.DataAnnotations;

namespace RestAPI.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public int Id { get; init; }

        [Required]
        public string CarMake { get; init; }

        [Required]
        public string CarModel { get; init; }

        [Required]
        [Range(1, 5000000)]
        public decimal Price { get; init; }
    }
}