using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models.Response;
using CoinVotesWeb.Services;

namespace CoinVotesWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesApiController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesApiController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceViewModel>>> GetDevices(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 50,
            [FromQuery] string searchTerm = "")
        {
            try
            {
                var result = await _deviceService.GetPagedListAsync(page, pageSize, searchTerm: searchTerm);
                return Ok(new { 
                    Items = result.Items.Select(x => new DeviceViewModel
                    {
                        ID = x.ID,
                        DeviceId = x.DeviceId,
                        DeviceType = x.DeviceType,
                        DeviceModel = x.DeviceModel,
                        UserId = x.UserId,
                        OsVersion = x.OsVersion,
                        DeviceLanguage = x.DeviceLanguage,
                        DeviceRegion = x.DeviceRegion,
                        IsNotificationPermissionGiven = x.IsNotificationPermissionGiven,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    }).ToList(), 
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
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            try
            {
                var device = await _deviceService.GetByIdAsync(id);
                if (device == null)
                {
                    return NotFound();
                }
                return Ok(device);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}