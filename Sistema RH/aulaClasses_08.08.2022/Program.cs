﻿using System;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    class Program
    {
        private const int V = 1;
        static List<Funcionario> lista = new List<Funcionario>();
        static void Main(string[] args)
        {
        
            Criarlista();
            bool opcaoValidado = false;
            while(opcaoValidado == false)
            {
                string[] frase = new string[3]{"Obter", "dado(s)","funcionario(s)"};
                Console.WriteLine("Selecione a opção:"); 
                Console.WriteLine($"1 - {frase[0]} {frase[1]} pelo tipo de funcionario");
                Console.WriteLine($"2 - {frase[0]} {frase[1]} pelo nome do funcionario");
                Console.WriteLine($"3 - {frase[0]} lista dos {frase[2]} recentes");
                Console.WriteLine($"4 - Obter estatisca dos {frase[2]}");
                Console.WriteLine($"5 - Adicionar {frase[2]}");
                    int opcaoEscolhida = int.Parse(Console.ReadLine());

                switch(opcaoEscolhida)
                {
                    case 1:
                        Console.WriteLine("Digite a opção desejada para buscar os Funcionários;");
                        Console.WriteLine("1 = CLT; \n2= Aprendiz;");
                            int busca = int.Parse(Console.ReadLine());
                        ObterPorTipo(busca);
                        opcaoValidado = true;
                    ;break;
                    case 2:
                        Console.WriteLine("Digita ai o nome :D");
                            string nomeMain = Console.ReadLine();
                        ObterPorNome(nomeMain);
                        opcaoValidado = true;
                    ;break;
                    case 3:
                        ObterFuncionariosRecentes();
                        opcaoValidado = true;
                    ;break;
                    case 4:
                        ObterEstatisticas();
                        opcaoValidado = true;
                    ;break;
                    case 5:
                        bool fAdicionando = false;

                        while(fAdicionando == false)
                        {
                            Funcionario f = new Funcionario();

                            Console.WriteLine("Digite seu nome: ");
                                f.Nome = Console.ReadLine();

                            Console.WriteLine("Digite o salário: ");
                                f.Salario = decimal.Parse(Console.ReadLine());

                            Console.WriteLine("Digite a data de admissao: ");
                                f.DataAdmissao = DateTime.Parse(Console.ReadLine());
                
                            fAdicionando = ValidarNome(f);
                            if(fAdicionando == true)
                                fAdicionando = AdicionarFuncionario(f);
                                    if(fAdicionando == true)
                                        Console.WriteLine("User adicionado com sucesso");
                        }
                        opcaoValidado = true;
                    ;break;
                    default:
                        Console.WriteLine("valor invalido!");
                    opcaoValidado = false;break;

                }

            }
        }
        public static bool AdicionarFuncionario(Funcionario fNovo)
        {
            if(fNovo.Salario == 0)
            {
                Console.WriteLine("Valor do salario nao pode ser 0");
                return false;
            }
            else
            {
                lista.Add(fNovo);
                return true;
            }
        }
        public static bool ValidarNome(Funcionario validarNome)
        {
            if(validarNome.Nome.Length < 3)
            {
                Console.WriteLine($"O nome: '{validarNome.Nome}' é invalido!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void ObterEstatisticas()
        {
            Console.WriteLine("Segue abaixo as estatisticas dos Funcionarios:");
            SomarSalario();
            ContarFuncionarios();
        }

        public static void ObterFuncionariosRecentes()
        {
            RemoverIdMenor4();
            lista = lista.OrderBy(x => x.Salario).ToList();
            ExibirLista();
        }
        public static void RemoverIdMenor4()
        {
            lista.RemoveAll(x => x.Id < 4);
            //ExibirLista();
        }
        public static void ObterPorNome(string nomeRequisitado)
        {
            AdicionarItem();
            lista = lista.FindAll(x => x.Nome.ToLower().Contains(nomeRequisitado));//Adiciona nos valores da lista os itens achados
            ExibirLista();
        }

        public static void ObterPorTipo(int buscarFuncionario)
        {
            switch(buscarFuncionario)
            {
                case 1:ExibirCLT();break;
                case 2:ExibirAprendizes();break;
                default:
                Console.WriteLine($"O valor '{buscarFuncionario}' é invalido digite um valor valido'");break;
            }
        }
        public static void ExibirAprendizes()
        {
            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            ExibirLista();
        }
        public static void ExibirCLT()
        {
            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.CLT);
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
        public static void ObterPorSalario(decimal valor)
        {
            lista = lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
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
            fnovo.Cpf = "01987654321";
            fnovo.DataAdmissao = DateTime.Parse("17/05/1997");
            fnovo.Salario = 300.000M;
            fnovo.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(fnovo);           
        }
        public static void SomarSalario()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é {0:c2}", somatorio));
        }
        public static void ObterPorId(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);
            //lista = lista.FindAll(x => x.Id == 6);
            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
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
        
        public static void BuscaPorNomeAproximado()
        {
            AdicionarItem();
            lista = lista.FindAll(x => x.Nome.ToLower().Contains("ronaldo"));//Adiciona nos valores da lista os itens achados
            ExibirLista();
        }
        public static void BuscaPorCpfRemover()
        {
            Funcionario fBusca = lista.Find( x => x.Cpf == "01987654321");
            lista.Remove(fBusca);

            Console.WriteLine($"Personagem removido {fBusca.Nome}");

            ExibirLista();
        }

    }
}