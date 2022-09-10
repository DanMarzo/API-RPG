using System;
using PraticasCSharp.Models;

namespace PraticasCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            TipoRefeicaoEnum nome = TipoRefeicaoEnum.Almoço;
            Console.WriteLine($"{nome}");
        }
    }
}