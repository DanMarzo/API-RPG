using System;

namespace Metodos {
    class Metodos {
        static void Main(string[] args) {
            Console.WriteLine("Digite um numero");
                int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite outro numero");
                int n2 = int.Parse(Console.ReadLine());

            int soma   = FazConta(n1, n2);
            string msg = soma.ToString();
            
            ExibirMsg(msg);
        }

        public static int FazConta(int n1, int n2) {

            int saida = n1 + n2;

            return saida;
        } 
        public static void ExibirMsg(string exibirMsg) {
            Console.WriteLine($"{exibirMsg} => é o resultado da conta");
        }
    }
}