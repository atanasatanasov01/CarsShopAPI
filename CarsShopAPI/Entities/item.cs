using System;

namespace RestAPI.Entities
{
    public record Item
    {

        public Guid Id { get; init; }
        public string CarMake { get; init; }

        public string CarModel { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}