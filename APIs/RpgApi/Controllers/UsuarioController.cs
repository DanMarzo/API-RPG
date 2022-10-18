using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context) { _context = context; }

        public async Task<bool> UsuarioExistente (string username) 
        {
            if (await _context.Usuarios.AnyAsync(
                x => x.Username.ToLower() == username.ToLower())) {
                    
                    return (true);
            } 
            return (false);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user ) {
            try {
                if(await UsuarioExistente(user.Username))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty; //empty deixa a string vazia
                user.PasswordHash   = hash;
                user.PasswordSalt   = salt;
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync(); //essa função é responsavel por salvar no banco de dados

                return Ok(user.Id);
            }catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}