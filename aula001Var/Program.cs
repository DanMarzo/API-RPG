using System; //importar com em c++
 
namespace aula01Var //usar namespace sempre no mesmo nome do projeto
{
    class Program //isso é a classe do programa
    {
        static void Main (string[] args)
        {
            Console.WriteLine("\nSelecione uma das opções: \n");
            Console.WriteLine("Opção 1 - Tabuada \t");
            Console.WriteLine("Opção 2 - Concatenar Palavras\t");
            Console.WriteLine("Opção 3 - Verificar\t");
            Console.WriteLine("Opção 4 - Calcular média\t");

            int opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1: 
                    calcularTabuada();
                break;
                case 2:
                    ConcatenarPalavras();
                break;
                case 3:
                    verificarAulaEtec();
                break;
                case 4: 
                    CalcularMedia();
                break;
                
                default: Console.WriteLine("\nOpção inválida. \n");break;
            }

            // calcularTabuada();
            // ConcatenarPalavras();
            // verificarAulaEtec();
            // CalcularMedia();
        }

        public static void ConcatenarPalavras()
        {

            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();

            string frase1 = ($"Olá {nome}, hoje é {DateTime.Now}");
            Console.WriteLine(frase1);
            Console.WriteLine(" ");

            Console.WriteLine("Quanto custa um dólar em reais? ");
                decimal valorDolarReais = decimal.Parse(Console.ReadLine());
            string frase2 = string.Format("Hoje é {0:dddd}, o dolár está custando {1:c2}", DateTime.Now, valorDolarReais);
            Console.WriteLine(frase2);

            Console.WriteLine(" ");
            string cabecalho = string.Format ("{0:dddd}, {0:dd} de {0:MMMM} de {0:yyyy} - {0:HH:mm:ss}", DateTime.Now); //{0:HH:mm:ss} o 0 é posição das var a serem escritas
            Console.WriteLine(cabecalho.ToUpper());
        }
        public static void verificarAulaEtec()
        {
            Console.WriteLine("Digite o dia da semana: ");
                DateTime data = DateTime.Parse(Console.ReadLine());
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Liberdade Cantou!");
                Console.WriteLine("Hoje é {0}", data.DayOfWeek);
            }
            else
            {
                Console.WriteLine("Dia da semana bora quebra a cabeça");
                Console.WriteLine("Hoje é {0}", data.DayOfWeek);
            }
        }
        public static void CalcularMedia()
        {
            Console.WriteLine("Digite a primeira nota:");
            decimal nota1 = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a segunda nota:");
            decimal nota2 = decimal.Parse(Console.ReadLine());

            decimal media = (nota1 + nota2) /2;
            Console.WriteLine($"A média é {media}");

            if (media >= 7) {
                Console.WriteLine("Você foi aprovado\n");

            }else if ((media >= 4) && (media < 7)) {
                Console.WriteLine("Você esta de Recuperação\n");

            }else {
                Console.WriteLine("Você foi reprovado, melhoras filhão. Chora\n");
            }

        }

        public static void calcularTabuada()
        {
            Console.WriteLine("Digite A tabuada que ce deseja calcular: \n");
                int tabuada = int.Parse(Console.ReadLine());
            int count = 0;
            string texto;
            while (count < 11)
            {
                texto = string.Format("{0} X {1} = {2}", tabuada, count, tabuada * count);

                Console.WriteLine(texto);
                count++;                
            }
        }
    }
}