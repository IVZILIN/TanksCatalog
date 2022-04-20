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
    }
}