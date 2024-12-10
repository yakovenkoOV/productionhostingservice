// Controllers/ContractsController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ContractsController : ControllerBase
{
    private readonly ContractsService _contractsService;

    public ContractsController(ContractsService contractsService)
    {
        _contractsService = contractsService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateContract([FromQuery]string facilityCode, [FromQuery]string equipmentCode, [FromQuery]int quantity)
    {
        try
        {
            await _contractsService.CreateContractAsync(facilityCode, equipmentCode, quantity);
            return Ok("Contract created successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetContracts()
    {
        var result = await _contractsService.GetContractsAsync();
        return Ok(result);
    }
}
