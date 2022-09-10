/*Console.WriteLine("Digite seu nome: ^^");
string nome = Console.ReadLine();

string frase1 = $"Ola {nome} tudo bem?^^, hoje é {DateTime.Now}";
Console.WriteLine(frase1);
Console.WriteLine("");

Console.WriteLine("Eai? quanto está o dolár hoje? ^^");
decimal valDolar = decimal.Parse(Console.ReadLine()); //Linha para conversão para decimal
string frase2 = string.Format($"Hoje {0:dddd}, o dolár esta custando {1:c2}^^", DateTime.Now, valDolar); //{1:c2} para uma casa inteira e 2 decimais

Console.WriteLine(frase2);
Console.WriteLine("");

string cabecalhoPrinc = string.Format($"{0:dddd}, {0:dd} de {0:MMMM} de {0:yyyy} -- {0:HH:mm:ss}", DateTime.Now);
Console.WriteLine(cabecalhoPrinc.ToUpper());*/

internal class Program
{
    private static void Main(string[] args)
    {
        concatenarPalavras();
    }

    private static void concatenarPalavras()
    {
        Console.WriteLine("Digite seu nome:");
        Console.ReadLine();
    }
}