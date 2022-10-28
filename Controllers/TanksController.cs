using System.Collections.Generic;
using System.Threading.Tasks;
using TanksCatalog.Repositories;
using TanksCatalog.Entities;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using TanksCatalog.Dtos;

namespace TanksCatalog.Controllers
{
    //GET /tanks
    [ApiController]
    [Route("[controller]")]
    public class TanksController : ControllerBase
    {
        private readonly ITanksRepository repositry;

        public TanksController(ITanksRepository repository)
        {
            this.repositry = repository;
        }

        // GET /tanks
        [HttpGet]
        public async Task<IEnumerable<TankDto>> GetTanksAsync()
        {
            var tanks = (await repositry.GetTanksAsync()).Select(tank => tank.AsDto());
            return tanks;
        }

        // GET / tanks/{id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<TankDto>> GetTankAsync(Guid Id)
        {
            var tank = await repositry.GetTankAsync(Id);
            if (tank is null)
            {
                return NotFound();
            }
            return tank.AsDto();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<TankDto>> CreateTankAsync(CreateTankDto tankDto)
        {
            Tank tank = new()
            {
                Id = Guid.NewGuid(),
                Model = tankDto.Model,
                Price = tankDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
                EnginSpeed = tankDto.EnginSpeed,
                BarrelGauge = tankDto.BarrelGauge
            };

            await repositry.CreateTankAsync(tank);

            return CreatedAtAction(nameof(GetTankAsync), new { id = tank.Id }, tank.AsDto());
        }

        //PUT /tanks/{id}
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateTankAsync(Guid Id, UpdateTankDto tankDto)
        {
            var existingTank = await repositry.GetTankAsync(Id);

            if (existingTank is null)
            {
                return NotFound();
            }

            Tank updatedTank = existingTank with
            {
                Model = tankDto.Model,
                Price = tankDto.Price,
                EnginSpeed = tankDto.EnginSpeed,
                BarrelGauge = tankDto.BarrelGauge
            };

            await repositry.UpdateTankAsync(updatedTank);

            return NoContent();
        }

        //DELETE /tanks/{id}
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTankAsync(Guid Id)
        {
            var existingTank = await repositry.GetTankAsync(Id);

            if (existingTank is null)
            {
                return NotFound();
            }

            await repositry.DeleteTankAsync(Id);

            return NoContent();
        }

    }
}