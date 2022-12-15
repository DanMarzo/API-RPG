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
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                List<PersonagemHabilidade> ph = new List<PersonagemHabilidade>();
                ph = await _context.PersonagemHabilidades.Where(x => x.PersonagemId == id).ToListAsync();

                if(ph == null)
                    throw new Exception("Nada foi encontrado +_+");
                return Ok(ph);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidades()
        {
            try
            {
                List<Habilidade> habilidades = new List<Habilidade>(); 
                habilidades = await _context.Habilidade.ToListAsync();
                if(habilidades == null)
                    throw new Exception("Nada Foi encontrado");
                return Ok(habilidades);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade ph)
        {
            try
            {
                PersonagemHabilidade deletePh = await _context.PersonagemHabilidades.FirstOrDefaultAsync(x => x.HabilidadeId == ph.HabilidadeId && x.PersonagemId == ph.PersonagemId);

                if(deletePh == null)
                    throw new Exception("Nada foi encontrado =(");

                _context.PersonagemHabilidades.Remove(deletePh);
                await _context.SaveChangesAsync();

                return Ok($"O Personagem {ph.PersonagemId} e a Habilidade: {ph.HabilidadeId}, foram excluidas!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}