namespace ProductionHostingService.Repository.Interfaces;

public interface IUnitOfWork
{
    IEquipmentContractRepository Contracts { get; }
    Task<int> CompleteAsync();
}