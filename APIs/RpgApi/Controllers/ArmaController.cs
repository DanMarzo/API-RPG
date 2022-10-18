using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using RpgApi. Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace RpgApi.Controllers
{
    [ApiController]

    [Route("[Controller]")]
    public class ArmaController :  ControllerBase
    {
        private readonly DataContext _context;

        public ArmaController(DataContext context) //deixa o banco publico
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try{
                List<Armas> armasFull = await _context.Armas.ToListAsync();
                return Ok(armasFull);
            }
            catch(Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarArma(Armas arma) {
            try {

                await _context.Armas.AddAsync (arma);
                await _context.SaveChangesAsync();

                return Ok("Adicionado amigão!");

            }
            catch (System.Exception ex) {
                return BadRequest ("LASCOU!");
            }
        }
    }

}