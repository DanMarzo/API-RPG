
using System;

namespace Aula01Variaveis
{
    class Program
    {
        static void Main(string[] args)
        {

           ConcatenarPalavras();
        }

        public static void ConcatenarPalavras()
        {
             Console.WriteLine("Digite o seu nome");
            string nome = Console.ReadLine();
            string frase1 = $"Olá {nome}, hoje é {DateTime.Now}";
            Console.WriteLine(frase1);
            Console.WriteLine("===============================");

            Console.WriteLine("Quanto custa um dólar em reais?");
            decimal valorDolarReais = decimal.Parse(Console.ReadLine());
            string frase2 =
                string.Format("Hoje é {0:dd/MM/yyyy}, o dólar está custando {1:c2}", DateTime.Now, valorDolarReais);
            Console.WriteLine(frase2);
            Console.WriteLine("===============================");

            string cabecalho = string.Format("{0:dddd}, {0:dd} de {0:MMMM} de {0:yy} - {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine(cabecalho);
        }
    }
}
