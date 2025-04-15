using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models.Request;
using CoinVotesWeb.Models.Response;
using CoinVotesWeb.Services;

namespace CoinVotesWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymbolsApiController : ControllerBase
    {
        private readonly ISymbolService _symbolService;

        public SymbolsApiController(ISymbolService symbolService)
        {
            _symbolService = symbolService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SymbolViewModel>>> GetSymbols(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 50,
            [FromQuery] string searchTerm = "")
        {
            try
            {
                var result = await _symbolService.GetPagedListAsync(page, pageSize, searchTerm: searchTerm);
                return Ok(new { 
                    Items = result.Items.Select(x => new SymbolViewModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        SymbolUsdt = x.SymbolUsdt,
                        Code = x.Code,
                        OrderNo = x.OrderNo,
                        CreatedAt = x.CreatedAt,
                        IsActive = x.IsActive
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

        [Route("/detail/{id}")]
        [HttpGet]
        public async Task<ActionResult<Symbol>> GetSymbol(int id)
        {
            try
            {
                var symbol = await _symbolService.GetByIdAsync(id);
                if (symbol == null)
                {
                    return NotFound();
                }
                return Ok(symbol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Symbol>> UpdateSymbol(int id, [FromBody] SymbolUpdateModel model)
        {
            try
            {
                var symbol = await _symbolService.GetByIdAsync(id);
                if (symbol == null)
                {
                    return NotFound();
                }

                // Update symbol properties
                symbol.Name = model.Name;
                symbol.SymbolUsdt = model.SymbolUsdt;
                symbol.Code = model.Code;
                symbol.OrderNo = model.OrderNo;
                symbol.IsActive = model.IsActive;

                await _symbolService.UpdateAsync(symbol);
                return Ok(symbol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatus(int id, [FromBody] ToggleStatusRequest request)
        {
            try
            {
                var symbol = await _symbolService.GetByIdAsync(id);
                if (symbol == null)
                {
                    return NotFound();
                }

                symbol.IsActive = request.IsActive;
                await _symbolService.UpdateAsync(symbol);

                return Ok(new { message = "Symbol status updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the symbol status", error = ex.Message });
            }
        }
    }

    public class ToggleStatusRequest
    {
        public bool IsActive { get; set; }
    }
}