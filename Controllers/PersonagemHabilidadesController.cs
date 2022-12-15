using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonagemHabilidadesController(DataContext context){ _context= context; }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novPersonagemHabilidade)
        {
            try
            {
                Personagem personagem = await _context.Personagens
                .Include(x => x.Armas)
                .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(x => x.Id == novPersonagemHabilidade.PersonagemId);

                if(personagem == null )
                    throw new Exception("Personagem não encontrado pelo ID informado");
                
                Habilidade habilidade = await _context.Habilidade.FirstOrDefaultAsync(h => h.Id == novPersonagemHabilidade.HabilidadeId);

                if(habilidade == null)
                    throw new Exception("Habilidade não encontrada");
                PersonagemHabilidade ph = new();

                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.PersonagemHabilidades.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}