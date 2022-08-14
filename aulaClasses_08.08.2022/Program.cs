using System;
using Aula03Colecoes;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();
        static void Main(string[] args)
        {
            Criarlista();// no main importa a sequência no resto não
            // ExibirLista();
            Ordenar();
            //ObterPorId();
            ContarFuncionarios();
            ExibirLista();
            SomarSalario();
            ExibirAprendizes();
            AdicionarItem();
            ExibirLista();

        }
        public static void Ordenar()
        {
            lista = lista.OrderBy(x => x.Cpf).ToList();
            ExibirLista();
        }
        public static void ContarFuncionarios(){
            int qtd = lista.Count();
            Console.WriteLine($"Existem {qtd} funcionários");
        }
        public static void ExibirAprendizes(){
            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            ExibirLista();
        }

        public static void ExibirLista()
        {
            string dados = "";
            string tracos = "===================================================\n";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += tracos;
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0: dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);//{0:c2} O cs é para exibir em Moeda local
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += tracos;
            }
            Console.WriteLine(dados);
        } 
        public static void SomarSalario()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é {0:c2}", somatorio));
        }
        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 6);
        }
        
        public static void Criarlista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }
        public static void AdicionarItem()
        {
            Funcionario fnovo = new Funcionario();
            fnovo.Id = 9;
            fnovo.Nome = "Ronaldo";
            fnovo.Cpf = "11111111110";
            fnovo.DataAdmissao = DateTime.Parse("17/05/1997");
            fnovo.Salario = 300.000M;
            fnovo.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(fnovo);           
        }
    }
}