using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
        
    public class DisputasController : ControllerBase
    {
        
        private readonly DataContext _context;
        public DisputasController (DataContext context) {
            _context = context;
        }
        public async Task<IActionResult> AtaqueComArmaAsync(Disputas d)
        {
            try {
                return Ok(d);
            } catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}