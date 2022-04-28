using System;


namespace TanksCatalog.Dtos
{
    public record TankDto
    {
        public Guid Id { get; init; }
        public string? Model { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public decimal EnginSpeed {get; init;}
        public decimal BarrelGauge {get;init;}
    }
}