using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraticasCSharp.Models
{
    public class CadastroPessoa
    {
        public string Nome { get; set; }
        public decimal LimiteSalario { get; set; }      
        public TipoRefeicaoEnum TipoRefeicao { get; set; }
    }
}