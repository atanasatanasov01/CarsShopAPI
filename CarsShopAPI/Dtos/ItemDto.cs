using System;


namespace RestAPI.Dtos
{

     public record ItemDto
    {

        public int Id { get; init; }
        public string CarMake { get; init; }

        public string CarModel { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }

}