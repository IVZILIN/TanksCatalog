using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanksCatalog.Entities;


namespace TanksCatalog.Repositories
{
    public class InMemTanksRepository : ITanksRepository
    {
        private readonly List<Tank> tanks = new()
        {
            new Tank {Id = Guid.NewGuid(),Model = "T-90", Price = 9000, CreatedDate = DateTimeOffset.UtcNow},
            new Tank {Id = Guid.NewGuid(),Model = "T-80", Price = 8000, CreatedDate = DateTimeOffset.UtcNow},
            new Tank {Id = Guid.NewGuid(),Model = "T-64", Price = 1000, CreatedDate = DateTimeOffset.UtcNow}
        };

        public async Task<IEnumerable<Tank>> GetTanksAsync()
        {
            return await Task.FromResult(tanks);
        }

        public async Task<Tank?> GetTankAsync(Guid id)
        {
            var tank = tanks.Where(tank => tank.Id == id).SingleOrDefault();
            return await Task.FromResult(tank);
        }

        public async Task CreateTankAsync(Tank tank)
        {
            tanks.Add(tank);
            await Task.CompletedTask;
        }

        public async Task UpdateTankAsync(Tank tank)
        {
            var index = tanks.FindIndex(existingTank => existingTank.Id == tank.Id);
            tanks[index] = tank;
            await Task.CompletedTask;
        }

        public async Task DeleteTankAsync(Guid Id)
        {
            var index = tanks.FindIndex(existingTank => existingTank.Id == Id);
            tanks.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
