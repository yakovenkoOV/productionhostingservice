
namespace ProductionHostingService.Repository.Interfaces;
public interface IEquipmentContractRepository : IBaseRepository<EquipmentPlacementContract>
{
    Task<IEnumerable<EquipmentPlacementContract>> GetContractsWithDetailsAsync();
}