using Microsoft.EntityFrameworkCore;
using ProductionHostingService.Repository.Interfaces;

namespace ProductionHostingService.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IEquipmentContractRepository Contracts { get; }

    public UnitOfWork(ApplicationDbContext context, IEquipmentContractRepository contractRepository)
    {
        _context = context;
        Contracts = contractRepository;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
}