using Microsoft.CSharp;
namespace PraticaVetores{
    class PraticaVetores
    {
        static void Main(string[] args)
        {
            int[] vetor1 = new int[5];
            int[] vetor2 = new int[5];
            int[] vetor3 = new int[5];
            int[,] vetor4 = new int[2,5]{{5, 4, 3, 2, 1},{11,22,33,44,11}};
            int[] vetor5 = new int[5]{5, 4, 33, 2, 1};
            
            Random random = new Random();
            for(int i=0;i<vetor1.Length;i++){
                vetor1[i]= random.Next(40,660);//o mesmo define como criar os numeros aleatorios
                Console.WriteLine(vetor1[i]);
            }
            //BynarySearch(array, procurar)
            int procurar = Array.BinarySearch(vetor5,33);// se ele achar ele mostra a posição, se não ele preenche com -1
            Console.WriteLine(procurar);

            //Copy(Ar_origem, Ar_Destino, qtdElementos)
            Console.WriteLine("Copy");
            Array.Copy(vetor1,vetor2,vetor1.Length);
            foreach (int n in vetor2)// o n recebe o conteudo do vetor2, USADO PARA LEITURA
            {
                Console.WriteLine(n);
            }



        }
    }
}