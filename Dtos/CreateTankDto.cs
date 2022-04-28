using System;
using System.ComponentModel.DataAnnotations;

namespace TanksCatalog.Dtos
{
    public record CreateTankDto
    {
        [Required]
        public string? Model { get; init; }
        [Required]
        [Range(1,10000000)]
        public decimal Price { get; init; }
        [Required]
        [Range(1,100000)]
        public decimal EnginSpeed {get; init;}
        [Required]
        [Range(30,255)]
        public decimal BarrelGauge {get;init;}
    }
}