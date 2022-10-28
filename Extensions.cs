using TanksCatalog.Dtos;
using TanksCatalog.Entities;

namespace TanksCatalog
{
    public static class Extensions
    {
        public static TankDto AsDto(this Tank tank)
        {
            return new TankDto
            {
                Id = tank.Id,
                Model = tank.Model,
                Price = tank.Price,
                CreatedDate = tank.CreatedDate,
                EnginSpeed = tank.EnginSpeed,
                BarrelGauge = tank.EnginSpeed
            };
        }
    }
}