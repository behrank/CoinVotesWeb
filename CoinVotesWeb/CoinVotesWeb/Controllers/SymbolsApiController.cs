using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoinVotesWeb.Models;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Symbol>> GetSymbol(int id)
        {
            try
            {
                var symbol = await _symbolService.GetByIdAsync(id);
                return Ok(symbol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
} 