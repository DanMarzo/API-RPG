using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;
using System;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context; //
        public UsuariosController(DataContext context) { _context = context; }

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

                usuario.DataAcesso = DateTime.Now;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                
                return Ok(usuario.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == u.Id);
                
                usuario.Email = u.Email;

                var attach = _context.Attach(usuario);

                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Email).IsModified = true;
                
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);

            }
            catch(Exception ex)
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
                    pesquisaDados.DataAcesso = DateTime.Now;
                    _context.Usuarios.Update(pesquisaDados);
                    await _context.SaveChangesAsync();//confirmar a alteração no banco de dados
                    return Ok(pesquisaDados.Id);
                }       
            }catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id) {
            try {
                Personagem findId = await _context.Personagens
                .Include(ar => ar.Armas) //o .Include faz a inclusao de outro objeto tipo inner join 
                .Include(us => us.Usuario)
                .Include(ps => ps.PersonagemHabilidades)
                    .ThenInclude(h => h.Habilidade)
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(findId);

            }catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    
        /*[HttpGet("personagemId/{personagemId}")]
        public async Task<IActionResult> GetHabilidadesPersonagem(int persoId) {
            try{
                List<PersonagemHabilidade> persoLista = new List<PersonagemHabilidade>();
                persoLista = await _context.PersonagemHabilidades
                .Include(p => p.Personagem)
                .Include(p => p.Habilidade)
                .Where(p => p.PersonagemId == persoId).ToListAsync();
                return Ok(persoLista);
            }
            catch(System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> ListarHabilidades() 
        {
            try
            {
                List<Habilidade> listaHab = new List<Habilidade>();
                listaHab = await _context.Habilidade.ToListAsync();
                return Ok(listaHab);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeletarPersonagemHabilidade(PersonagemHabilidade ph) 
        {
            try
            {
                PersonagemHabilidade removePH = new PersonagemHabilidade();
                removePH = await _context.PersonagemHabilidades.FirstOrDefaultAsync(x => x.PersonagemId == ph.PersonagemId && x.HabilidadeId == ph.HabilidadeId);
                if(removePH == null)
                    throw new System.Exception("Nenhum item encontrado");
                
                _context.PersonagemHabilidades.Remove(removePH);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);  
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);
                 //Busca o usuário no banco através do Id

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
            //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName.ToLower() == login.ToLower()); //Busca o usuário no banco através do login
        
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para alteração da geolocalização
        [HttpPut("AtualizarLocalizacao")]
        public async Task<IActionResult> AtualizarLocalizacao(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do Id
                .FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Latitude = u.Latitude;
                usuario.Longitude = u.Longitude;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Latitude).IsModified = true;
                attach.Property(x => x.Longitude).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

    }
}