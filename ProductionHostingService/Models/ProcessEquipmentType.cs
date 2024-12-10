using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ProcessEquipmentType
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Code is Required")]
    [StringLength(20, ErrorMessage = "Code as string with max length 20 syb")]
    public required string Code { get; set; }

    [Required(ErrorMessage = "Name is Required")]
    [StringLength(50, ErrorMessage = "Name as string with max length 20 syb")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Area is Required")]
    [Range(0, int.MaxValue, ErrorMessage = "Area should be more then 0")]
    public required int Area { get; set; }

    // Поля аудиту
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigate
    public  ICollection<EquipmentPlacementContract> Contracts { get; set; } = new List<EquipmentPlacementContract>();
}
 