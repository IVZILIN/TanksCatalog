using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanksCatalog.Entities;


namespace TanksCatalog.Repositories
{
    public interface ITanksRepository{
        Task<Tank> GetTankAsync(Guid Id);
        Task<IEnumerable<Tank>> GetTanksAsync();

        Task CreateTankAsync(Tank tank);

        Task UpdateTankAsync(Tank tank);

        Task DeleteTankAsync(Guid Id);
    }
}