using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using RpgApi. Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace RpgApi.Controllers
{
    [ApiController]

    [Route("[Controller]")]//Nunca ESQUEÇA dos colchete entre o controller 
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext  context) 
        {
            _context = context;
        }

        public async Task<bool> PersonagemExistente(string userName)
        {
            if(await _context.Personagens.AnyAsync(x => x.Nome.ToLower() == userName.ToLower()))
                return true;
            return false;
        }
        

        //Primeira função
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Personagem p = await _context.Personagens
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                
                return Ok(p);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try 
            { 
                List<Personagem> lista = await _context.Personagens.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
//dotnet ef migrations add <nome>
        [HttpPost("PostAdd")]
        public async Task<IActionResult> Add(Personagem novoPersonagem)
        {
            try 
            {
                if(await PersonagemExistente(novoPersonagem.Nome))
                    throw new Exception("Personagem ja existe, coloca mais criatividade aê!");
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new Exception("Pontos de vida não pode ser maior que 100.");
                }
                await _context.Personagens.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Personagem pRemover = await _context.Personagens
                    .FirstOrDefaultAsync(pRemover => pRemover.Id == id);

                _context.Personagens.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateAsync(int id, Personagem p)
        {
            try
            {
                Personagem pBusca = await _context.Personagens.FirstOrDefaultAsync(x => x.Id == id);

                if(pBusca != null)
                {
                    pBusca.Nome           = p.Nome;
                    pBusca.Armas          = p.Armas;
                    pBusca.Classe         = p.Classe;
                    pBusca.PontosVida     = p.PontosVida;
                    pBusca.Inteligencia   = p.Inteligencia;
                    pBusca.Defesa         = p.Defesa;
                    pBusca.Forca          = p.Forca;
                    pBusca.FotoPersonagem = p.FotoPersonagem;
                    await _context.SaveChangesAsync();
                    return Ok("Dados atualizados");
                }
                else
                {
                    throw new Exception("Personagem não encontrado =)");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}