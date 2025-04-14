using CoinVotesWeb.Models;
using CoinVotesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoinVotesWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DevicesApiController(IDeviceService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Device>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        try
        {
            var result = await service.GetPagedListAsync(page, pageSize);
            return Ok(new { 
                Items = result.Items, 
                TotalCount = result.TotalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize)
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Device>> GetBy(int id)
    {
        try
        {
            var result = await service.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}