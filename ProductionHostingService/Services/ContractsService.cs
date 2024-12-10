using ProductionHostingService.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductionHostingService.Domain;

public class ContractsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;

    public ContractsService(IUnitOfWork unitOfWork, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task CreateContractAsync(string facilityCode, string equipmentCode, int quantity)
    {
        // Шукаємо фабрику
        var facility = await _context.ProductionFacilities
            .Include(f => f.Contracts)
            .FirstOrDefaultAsync(f => f.Code == facilityCode);
        
        if (facility == null)
            throw new InvalidOperationException($"Facility with code {facilityCode} not found.");

        // Шукаємо тип
        var equipment = await _context.ProcessEquipmentTypes
            .FirstOrDefaultAsync(e => e.Code == equipmentCode);
        
        if (equipment == null)
            throw new InvalidOperationException($"Equipment with code {equipmentCode} not found.");
        
        // Валыдуємо площу
        var usedArea = facility.Contracts.Sum(c => c.EquipmentQuantity * c.ProcessEquipmentType?.Area);
        var neededArea = quantity * equipment.Area;

        if (facility.StandardArea - usedArea < neededArea)
            throw new InvalidOperationException("Not enough free area in the facility to place this equipment.");

        var contract = new EquipmentPlacementContract
        {
            ProductionFacilityId = facility.Id,
            ProcessEquipmentTypeId = equipment.Id,
            EquipmentQuantity = quantity
        };

        await _unitOfWork.Contracts.AddAsync(contract);
        // Save
        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<EquipmentContractDto>> GetContractsAsync()
    {
        var contracts = await _unitOfWork.Contracts.GetContractsWithDetailsAsync();

        // Повертаємо типу ДТО
        return contracts.Select(c => new EquipmentContractDto
        {
            FacilityName = c.ProductionFacility?.Name ?? string.Empty,
            EquipmentName = c.ProcessEquipmentType?.Name ?? string.Empty,
            EquipmentQuantity = c.EquipmentQuantity
        });
    }
}