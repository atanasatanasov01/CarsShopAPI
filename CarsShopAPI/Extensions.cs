 using RestAPI.Dtos;
using RestAPI.Entities;


namespace RestAPI
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {

            return new ItemDto
            {
            Id = item.Id,
            CarMake = item.CarMake,
            CarModel = item.CarModel,
            Price = item.Price,
            CreatedDate = item.CreatedDate
            };
            }

        }
}
