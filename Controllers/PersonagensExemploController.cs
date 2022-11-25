using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.Models.Enuns;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagemExemploController : ControllerBase //Sempre o nome do controler deve ser mencionado na barra de busca
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

// ----------------------- Atividade ----------------------
        [HttpGet("GetByName/{nomeProcurado}")]
        public IActionResult SearchByName(string nomeProcurado)
        {
            List <Personagem> searchName = personagens.FindAll(x => x.Nome.ToLower().Contains(nomeProcurado.ToLower()));

            if(searchName.Count == 0)
                return BadRequest($"O nome: {nomeProcurado} é invalido");
            return Ok(searchName);
        }

        [HttpGet("GetByClasse/{tipoClasse}")]
        public IActionResult SearchByClass(int tipoClasse)
        {
            List <Personagem> pBuscaClasse;

            switch(tipoClasse)
            {
                case 1: pBuscaClasse = personagens.FindAll(x => x.Classe == ClasseEnum.Cavaleiro);
                ;break;
                case 2: pBuscaClasse = personagens.FindAll(x => x.Classe == ClasseEnum.Mago);
                ;break;
                case 3: pBuscaClasse = personagens.FindAll(x => x.Classe == ClasseEnum.Clerigo);
                ;break;
                default:
                return BadRequest($"O item {tipoClasse}, não existe");
                
            }
            return Ok(pBuscaClasse);
        }

        [HttpPost("PostValidacao")]
        public IActionResult ValidarNovoPersonagem(Personagem atribuindoNovoPersonagem)
        {
            if(atribuindoNovoPersonagem.Defesa < 10)
                return BadRequest("Personagem não pode ter defesa menor que 10");
            if(atribuindoNovoPersonagem.Inteligencia > 30)
                return BadRequest("Personagem não pode ter inteligencia maior que 30 - (exceto magos)");
            return Ok(AddPersonagem(atribuindoNovoPersonagem));
        }
        [HttpPost("PostValidacaoMago")]
        public IActionResult MagoValidado(Personagem ValidarMago)
        {
            if(ValidarMago.Classe == ClasseEnum.Mago)
            {
                if(ValidarMago.Inteligencia < 35)
                    return BadRequest("inteligencia do mago não pode ser menor que 35 - invalido");
            }
             return(AddPersonagem(ValidarMago));
        }
        [HttpGet("GetClerigoMago")]
        public IActionResult ClerigoMago()
        {
            personagens.RemoveAll(x => x.Classe == ClasseEnum.Cavaleiro);
            return Ok(personagens);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult EstatisticasPersonagens()
        {
            int somaInteligencia = personagens.Sum(x => x.Inteligencia);
            return Ok($"Qtde de personagens: {personagens.Count()}, e a soma da inteligencia: {somaInteligencia}");
        }

// ----------------------- Atividade- Fim ----------------------

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            personagens.RemoveAll(x => x.Id == id);
            return Ok(personagens);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(personagens);
        }
        [HttpGet("{Id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }
        // Continuação metodo POST

        // [HttpPost]
        // public IActionResult AddPersonagem(Personagem novoPersonagem)
        // {
        //     personagens.Add(novoPersonagem);
        //     return Ok(personagens);
        // }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Personagem> listaFinal = personagens.OrderBy(p => p.Forca).ToList();
            return Ok(listaFinal);
        }
        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade()
        {
            return Ok($"Quantidade de personagens: {personagens.Count}");
        }
        [HttpGet("GetSomaForca")]
        public IActionResult GetSomaForca()
        {
            return Ok($"A soma total da forca é {personagens.Sum(x => x.Forca)}");
        }
        [HttpGet("GetSemCavaleiro")]
        public IActionResult GetSemCavaleiro()
        {
            List <Personagem> listaBusca = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);
            return Ok(listaBusca);
        }
        [HttpGet("GetByNameAproximado/{nome}")]
        public IActionResult GetByNameAproximado(string nome)
        {
            List <Personagem> listaBusca = personagens.FindAll(p => p.Nome.ToLower().Contains(nome.ToLower()));
            //List <Personagem> listaBusca = personagens.FindAll(p => p.Nome.Contains(nome));
            return Ok(listaBusca);
        }
        [HttpGet("GetRemovendoMago")]
        public IActionResult GetRemovendoMago()
        {
            Personagem pRemove = personagens.Find(p => p.Classe == ClasseEnum.Mago);
            personagens.Remove(pRemove);
            return Ok($"Os seguintes personagens foram removidos {pRemove.Nome}");
        }
        [HttpGet("GetByForca/{forca}")]
        public IActionResult Get(int forca) //Atentar-se pois so com o get funciona
        {
            List <Personagem> listaFinal = personagens.FindAll(p => p.Forca == forca);
            return Ok(listaFinal);
        }
        [HttpPost("novoPersonagem")]
        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            personagens.Add(novoPersonagem);
            
            if(novoPersonagem.Inteligencia == 0)
                return BadRequest("Inteligencia não pode ter o valor igual a 0");
            return Ok(personagens);
        }
        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p)
        {
            Personagem alterarPersonagem = personagens.Find(x => x.Id == p.Id);
            alterarPersonagem.Nome = p.Nome;
            alterarPersonagem.PontosVida = p.PontosVida;
            alterarPersonagem.Forca = p.Forca;
            alterarPersonagem.Defesa = p.Defesa;
            alterarPersonagem.Inteligencia = p.Inteligencia;
            alterarPersonagem.Classe = p.Classe;

            return Ok(personagens);
        }
        

    }
}