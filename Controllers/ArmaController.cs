using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {

        private readonly DataContext _context;//Declaração contexto do Banco

        public ArmasController(DataContext context)
        {
            _context = context; //inicialização do contexto do banco
        }


        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)//using using System.Threading.Tasks;
        {
            try
            {
                Armas a = await _context.Armas                        
                       .FirstOrDefaultAsync(aBusca => aBusca.Id == id);
                //using Microsoft.EntityFrameworkCore;

                return Ok(a);
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
                //using System.Collections.Generic;
                List<Armas> lista = await _context.Armas                    
                    .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {
                if (novaArma.Dano == 0)
                {
                    throw new System.Exception("O dano da arma não pode ser 0");
                }

                await _context.Armas.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Armas novaArma)
        {
            try
            {
                if (novaArma.Dano == 0)
                {
                    throw new System.Exception("O dano da arma não pode ser 0");
                }

                _context.Armas.Update(novaArma);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Armas aRemover = await _context.Armas
                   .FirstOrDefaultAsync(p => p.Id == id);

                _context.Armas.Remove(aRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
























// using Microsoft.AspNetCore.Mvc;
// using RpgApi.Data;
// using System.Threading.Tasks;
// using RpgApi. Models;
// using Microsoft.EntityFrameworkCore;
// using System;

// namespace RpgApi.Controllers
// {
//     [ApiController]

//     [Route("[Controller]")]
//     public class ArmaController :  ControllerBase
//     {
//         private readonly DataContext _context;

//         public ArmaController(DataContext context) //deixa o banco publico
//         {
//             _context = context;
//         }

//         [HttpGet("GetAll")]
//         public async Task<IActionResult> GetAll()
//         {
//             try{
//                 List<Armas> armasFull = await _context.Armas.ToListAsync();
//                 return Ok(armasFull);
//             }
//             catch(Exception ex)
//             {   
//                 return BadRequest(ex.Message);
//             }
//         }
//         [HttpPost]
//         public async Task<IActionResult> RegistrarArma(Armas arma) {
//             try {

//                 await _context.Armas.AddAsync (arma);
//                 await _context.SaveChangesAsync();

//                 return Ok("Adicionado amigão!");

//             }
//             catch (System.Exception ex) {
//                 return BadRequest ("LASCOU!");
//             }
//         }
//     }

// }