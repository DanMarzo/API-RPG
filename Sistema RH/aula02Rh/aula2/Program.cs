using Aula02Rh.Models;
using Aula02Rh.Models.Enuns;
class Program
{
    static void Main(string[] args)
    {
        Funcionario func = new Funcionario(); // é instanciar um objeto, de nome FUNC, do tipo Funcionario, esses dados sao enviado para o Funcionario.cs
        Console.WriteLine("Digite o ID do Funcionário:");
        func.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o Nome do funcionário:");
        func.Nome = Console.ReadLine();

        Console.WriteLine("Digite o CPF:");
        func.Cpf = Console.ReadLine();
        
        Console.WriteLine("Digite a data de admissão: ");
        func.DataAdmissao = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Digite o salário:");
        func.Salario = decimal.Parse(Console.ReadLine());        
        //func.Salario = 10000.000M; // esse M força o compilador a interpretar o numero como decimal

        Console.WriteLine("Digte a opção selecionado\n1 - CLT | 2 - Aprendiz");
        int opcao = int.Parse(Console.ReadLine());
        func.TipoFuncionario = opcao == 1? TipoFuncionarioEnum.CLT : TipoFuncionarioEnum.Aprendiz;
        //func.TipoFuncionario = Aula02Rh.Models.Enuns.TipoFuncionarioEnum.CLT;

        Console.WriteLine("Digite a opcao desejada");
        Console.WriteLine("1 - Exibir o Nome e ID");
        Console.WriteLine("2 - Validar CPF");
        Console.WriteLine("3 - Reajuste de salário");
        Console.WriteLine("4 - Tempo de experiencia");
        Console.WriteLine("5 - Calcular desconto do VT");
        Console.WriteLine("6 - Tipo Funcionario");
        int escolha = int.Parse(Console.ReadLine());

        switch(escolha)
        {
            case 1:
                string nome = func.Nome;
                Console.WriteLine($"Nome {nome} - ID {func.Id}");
            ;break;
            case 2:
                bool flagCpf = func.ValidarCpf();
                    string cpf = flagCpf == true?"CPF Válido" : "CPF Inválido";
                Console.WriteLine(cpf);
            ;break;
            case 3:
                func.ReajustarSalario();
                Console.WriteLine($"Valor do reajuste: {func.Salario}");
            ;break;
            case 4:
                string experiencia = func.exibirTempoDeExperiencia();
                Console.WriteLine(experiencia);
            ;break;
            case 5:
                Console.WriteLine("Digite a porcentagem do desconto");
                    decimal porcent = decimal.Parse(Console.ReadLine());
                decimal descontoVT = func.CalcularDescontoVT(porcent);
                Console.WriteLine(descontoVT);
            ;break;
            case 6:
                TipoFuncionarioEnum msgFuncio = opcao == 1?TipoFuncionarioEnum.CLT : TipoFuncionarioEnum.Aprendiz;
                Console.WriteLine("O Funcionário é {0}",msgFuncio);
            ;break;
            default:
                Console.WriteLine("Favor selecionar uma das opçoes!");break;
        }


        // string experiencia = func.exibirTempoDeExperiencia();//essa mensagem assume o valor da função, e ele pega a funcao do programa Funcionario.cs

        // Console.WriteLine(experiencia);

        // bool cpf = func.ValidarCpf();
        // Console.WriteLine(cpf);
        
        
    }
}
