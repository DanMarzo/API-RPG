using System;
namespace Out {
    class Out{
        public static void Main(string[] args) {
            int div = 10, divisor = 8, quoc, resto;
            

            quoc = Dividir(div, divisor, out resto);

            Console.WriteLine("{0}/{1} = {2} resto {3}", div, divisor,quoc, resto);
        }
        public static int Dividir(int div, int divisor, out int resto) {
            //Ao usar OUT o return não deixa sair ate ele tbm ser declarado no escopo e receber algum valor
            int quoc = div/divisor;
            resto = div%divisor;
            return quoc;
        }

    }
}