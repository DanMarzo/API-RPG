using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                Personagem atacante = await _context.Personagens
                .Include(p => p.Armas)
                .FirstOrDefaultAsync(ps => ps.Id == d.AtacanteId);
                Personagem oponente = await _context.Personagens.FirstOrDefaultAsync(po => po.Id == d.OponenteId);
                

                return Ok(d);
            } catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}