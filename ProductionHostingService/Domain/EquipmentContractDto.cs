using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionHostingService.Domain
{
    public class EquipmentContractDto
    {
        public string FacilityName { get; set; } = string.Empty;
        public string EquipmentName { get; set; } = string.Empty;
        public int EquipmentQuantity { get; set; }
    }
}