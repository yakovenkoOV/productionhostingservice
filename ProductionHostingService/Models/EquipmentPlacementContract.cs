using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EquipmentPlacementContract
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Production facility is required")]
    public required int ProductionFacilityId { get; set; }

    [ForeignKey("ProductionFacilityId")]
    public ProductionFacility? ProductionFacility { get; set; }

    [Required(ErrorMessage = "Production type is required")]
    public required int ProcessEquipmentTypeId { get; set; }

    [ForeignKey("ProcessEquipmentTypeId")]
    public ProcessEquipmentType? ProcessEquipmentType { get; set; } 

    [Required(ErrorMessage = "count of equipment is required")]
    [Range(1, int.MaxValue, ErrorMessage = "EquipmentQuantity should be more then 0")]
    public required int EquipmentQuantity { get; set; }

    // Поля аудиту
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
