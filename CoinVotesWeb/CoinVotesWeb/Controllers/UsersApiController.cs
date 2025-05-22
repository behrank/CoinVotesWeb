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
    public class UsersApiController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers(
            [FromQuery] int page, 
            [FromQuery] int pageSize,
            [FromQuery] string searchTerm = "")
        {
            try
            {
                var result = await userService.GetPagedListAsync(page, pageSize, searchTerm: searchTerm);
                return Ok(new { 
                    Items = result.Items.Select(x => new UserViewModel
                    {
                        Id = x.ID,
                        Email = x.Email,
                        CreatedAt = x.CreatedAt,
                        Device = x.Email.Contains("anonymous") ? "iOS" : "Android",
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
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await userService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
} 