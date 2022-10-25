using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context; //
        public UsuarioController(DataContext context) { _context = context; }

        public async Task<bool> UsuarioExistente(string userName)
        {
            if (await _context.Usuarios.AnyAsync(
                x => x.UserName.ToLower() == userName.ToLower()))
            {

                return (true);
            }
            return (false);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.UserName))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty; //empty deixa a string vazia
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync(); //essa função é responsavel por salvar no banco de dados

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(credenciais.UserName.ToLower()));

                if (usuario == null)
                    throw new System.Exception("Usuário não encontrado"); // throw espera que aconteça um erro, se o mesmo for detectado ele pula para o CATCH
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                    throw new System.Exception("Senha incorreta");
                else
                    return Ok(usuario.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("AlterarSenha")]

        public async Task<IActionResult> AlterarSenha(Usuario dadosUse) { 
            
            try {
                Usuario senhaTroca = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(dadosUse.UserName.ToLower()));
                if (senhaTroca == null) 
                    throw new Exception("O Usuario não exite");
                    
                Criptografia.CriarPasswordHash(dadosUse.PasswordString,out byte[] hash, out byte[] salt);
                senhaTroca.PasswordString = string.Empty; 
                senhaTroca.PasswordHash = hash;
                senhaTroca.PasswordSalt = salt;

                _context.Usuarios.Update(senhaTroca);
                int valLinhas = await _context.SaveChangesAsync();
                
                return Ok($"{valLinhas} ALTERADAS");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarTodos() {
            try {
            List<Usuario> lista = await _context.Usuarios.ToListAsync();
            if (lista == null )
                throw new Exception ("Não foi encontrado nenhuma informação");
            return Ok(lista);
            }catch (System.Exception e) {
                return BadRequest(e.Message);
            }         
        }
        [HttpPost("AutenticarUsuario")]
        public async Task<IActionResult> ValidarUsuario (Usuario validaDados) {
            try {
                Usuario pesquisaDados = await _context.Usuarios.FirstOrDefaultAsync(ps => ps.UserName.ToLower().Equals(validaDados.UserName.ToLower()));
                //Use o equals
                if(pesquisaDados == null)
                    throw new Exception("Nenhum Usuario encontrado");
                else if(!Criptografia.VerificarPasswordHash(validaDados.PasswordString, pesquisaDados.PasswordHash, pesquisaDados.PasswordSalt))
                    throw new Exception("Senha Incorreta");
                else {
                    
                }
            }catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }


        }
    }
}