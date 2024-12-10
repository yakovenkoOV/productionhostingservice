using Microsoft.EntityFrameworkCore;
using ProductionHostingService.Repository.Interfaces;

namespace ProductionHostingService.Repository;
public class EquipmentContractRepository : BaseRepository<EquipmentPlacementContract>, IEquipmentContractRepository
{
    public EquipmentContractRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<EquipmentPlacementContract>> GetContractsWithDetailsAsync()
    {
        return await _dbSet.Include(c => c.ProductionFacility)
            .Include(c => c.ProcessEquipmentType)
            .ToListAsync();
    }
}
