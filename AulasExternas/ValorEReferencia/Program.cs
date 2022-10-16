using System;
namespace ValorEReferencia {
    class ValorEReferencia {
        public static void Main(string[] args) {
            int num = 20;
            DobraNum(ref num); //USE REF PARA CRIAR ENDEREÇO NA MEMORIA RAM
            Console.WriteLine(num);
        }
        public static void DobraNum(ref int num) {
            num = num*2;
        }
    }
}