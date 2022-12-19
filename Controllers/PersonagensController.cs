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

        public PersonagensController(DataContext  context) { _context = context; }

        public async Task<bool> PersonagemExistente(string userName)
        {
            if(await _context.Personagens.AnyAsync(x => x.Nome.ToLower() == userName.ToLower()))
                return true;
            return false;
        }
        
        //Primeira função
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Personagem p = await _context.Personagens
                    .Include(ar => ar.Armas)//inclui a propriedade Arma do obejto P
                    .Include(ph => ph.PersonagemHabilidades)
                        .ThenInclude(h => h.Habilidade) // Inclui na lista de personagemHabilidade de p
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                
                if(p == null)
                    throw new Exception("Nada foi encontrado =(");

                return Ok(p);
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
                return Ok(habilidades);
            }
            catch (System.Exception ex)
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
        [HttpPost]
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
        public async Task<IActionResult> UpdateAsync(int id, Personagem p)
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
        [HttpPut("AtualizarFoto")]
        public async Task<IActionResult> AtualizarFotoAsync(Personagem p)
        {
            try
            {
                Personagem personagem = await _context.Personagens.FirstOrDefaultAsync(x => x.Id == p.Id);
                
                personagem.FotoPersonagem = p.FotoPersonagem;

                var attach = _context.Attach(personagem);

                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.FotoPersonagem).IsModified = true;
                
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RestaurarPontosVida")]
        public async Task<IActionResult> RestaurarPontosVidaAsync(Personagem p)
        {
            try
            {
                int linhasAfetadas = 0;
                Personagem pEncontrado = await _context.Personagens.FirstOrDefaultAsync(pBusca => pBusca.Id == p.Id);
                if(pEncontrado == null)
                    throw new Exception("Nada foi encontrado!");
                
                pEncontrado.PontosVida = 100;

                bool atualizou = await TryUpdateModelAsync<Personagem>(pEncontrado, "p", pAtualizar => pAtualizar.PontosVida);

                if(atualizou)
                    linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ZerarRanking")]
        public async Task<IActionResult> ZerarRankingAsync(Personagem p)
        {
            try
            {
                Personagem pEncontrado = await _context.Personagens.FirstOrDefaultAsync(pBusca => pBusca.Id == p.Id );
                pEncontrado.Disputas = 0;
                pEncontrado.Vitorias = 0;
                pEncontrado.Derrotas = 0;
                int linhasAfetadas = 0;

                bool atualizou = await TryUpdateModelAsync<Personagem>(pEncontrado, "p",
                    pAtualizar => pAtualizar.Disputas,
                    pAtualizar => pAtualizar.Vitorias,
                    pAtualizar => pAtualizar.Derrotas);
                    // EF vai detectar e atualizar apenas as colunas que foram alteradas.
                if (atualizou)
                    linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        [HttpPut("ZerarRankingRestaurarVidas")]
        public async Task<IActionResult> ZerarRankingRestaurarVidasAsync()
        {
            try
            {
                List<Personagem> lista =
                await _context.Personagens.ToListAsync();
                foreach (Personagem p in lista)
                {
                    await ZerarRankingAsync(p);
                    await RestaurarPontosVidaAsync(p);
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetByUserAsync(int userId)
        {
            try
            {
                List<Personagem> lista = await _context.Personagens
                .Where(u => u.Usuario.Id == userId)
                .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByPerfil/userId")]
        public async Task<IActionResult> GetByPerfilAsync(int userId)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Id == userId);

                List<Personagem> lista = new List<Personagem>();
                
                if(usuario.Perfil == "Admin")
                    lista = await _context.Personagens.ToListAsync();
                else
                    lista = await _context.Personagens.Where(p => p.Usuario.Id == userId).ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}