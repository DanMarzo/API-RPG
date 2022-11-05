using System.Text;
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
        public DisputasController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                Personagem atacante = await _context.Personagens
                .Include(p => p.Armas)
                .FirstOrDefaultAsync(ps => ps.Id == d.AtacanteId);

                Personagem oponente = await _context.Personagens.FirstOrDefaultAsync(po => po.Id == d.OponenteId);

                int dano = atacante.Armas.Dano + (new Random().Next(atacante.Forca));
                dano = dano - new Random().Next(oponente.Defesa);

                if (dano > 0)
                    oponente.PontosVida = oponente.PontosVida - (int)dano;
                if (oponente.PontosVida <= 0)
                    d.Narracao = $"O {oponente.Nome} foi eliminado ahahah";
                _context.Personagens.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat($"Atacante: {atacante.Nome}");
                dados.AppendFormat($"Oponente: {oponente.Nome}");
                dados.AppendFormat($"Pontos de vida do atacante: {atacante.PontosVida}");
                dados.AppendFormat($"Pontos de vida do oponente: {oponente.PontosVida}");
                dados.AppendFormat($"Arma utilizada: {atacante.Armas.Nome}");
                dados.AppendFormat($"Dano: {dano}");

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.Disputas.Add(d);
                _context.SaveChanges();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                Personagem atacante = await _context.Personagens
                .Include(p => p.PersonagemHabilidades)
                .ThenInclude(ph => ph.Habilidade)
                .FirstOrDefaultAsync(at => at.Id == d.AtacanteId);

                Personagem oponente = await _context.Personagens.FirstOrDefaultAsync(po => po.Id == d.OponenteId);

                PersonagemHabilidade ph = await _context.PersonagemHabilidades
                .Include(h => h.Habilidade)
                .FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId && phBusca.PersonagemId == d.AtacanteId);

                if (ph == null)
                    d.Narracao = $"O {atacante.Nome} não possui habilidades";
                else
                {
                    int dano = ph.Habilidade.Dano + (new Random().Next(atacante.Inteligencia));
                    dano = dano - new Random().Next(oponente.Defesa);

                    if (dano == 0)
                        oponente.PontosVida = oponente.PontosVida - dano;
                    if (oponente.PontosVida <= 0)
                        d.Narracao += $"O {oponente.Nome} foi eliminado ahahah";
                    _context.Personagens.Update(oponente);
                    await _context.SaveChangesAsync();
                    
                    StringBuilder dados = new StringBuilder();
                    dados.AppendFormat($"Atacante: {atacante.Nome}");
                    dados.AppendFormat($"Oponente: {oponente.Nome}");
                    dados.AppendFormat($"Pontos de vida do atacante: {atacante.PontosVida}");
                    dados.AppendFormat($"Pontos de vida do oponente: {oponente.PontosVida}");
                    dados.AppendFormat($"Arma utilizada: {atacante.Armas.Nome}");
                    dados.AppendFormat($"Dano: {dano}");

                    d.Narracao += dados.ToString();
                    d.DataDisputa = DateTime.Now;
                    _context.Disputas.Add(d);
                    _context.SaveChanges();

                }
                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PersonagemRandom")]
        public async Task<IActionResult> Sorteio()
        {
            List<Personagem> ps = await _context.Personagens.ToListAsync();
            int sorteio = new Random().Next(ps.Count);
            Personagem pIndice = ps[sorteio];

            string msg = $"O numero sorteado foi {sorteio}, e o personagem selecionado foi {pIndice.Nome}";

            return Ok(msg);
        }
    }
}