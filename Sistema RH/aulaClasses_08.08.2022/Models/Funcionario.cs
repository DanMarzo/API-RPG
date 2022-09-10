using Aula03Colecoes.Models.Enuns;
namespace Aula03Colecoes.Models; //NameSpace é o nome da pasta, e atravaes dos '.' se define os diretorios

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataAdmissao { get; set; }
    public decimal Salario { get; set; }

    public TipoFuncionarioEnum TipoFuncionario { get; set; }//Esse aqui é uma variavel pernalizada;

    public void ReajustarSalario() // a palavra void é porque não tem return
    {   
        Salario = Salario * 10 / 100;

    }

    public string exibirTempoDeExperiencia() //num metodo que não seja void, ele aguarda um return, fica bravinho :(
    {
        string periodoExperiencia = string.Format("Periodo de experiencia {0} até {1}", DataAdmissao, DataAdmissao.AddMonths(3));
        return periodoExperiencia;
    }

    public decimal CalcularDescontoVT(decimal percetual)
    {
        decimal desconto = this.Salario * percetual/100;//o THIS é para argumentar A propriedade para essa classe Funcionario 
        return desconto;
    }

    public int ContarCaracteres(string dado)
    {
        return dado.Length;
    }
    
    public bool ValidarCpf()
    {
        if(ContarCaracteres(Cpf) == 11) 
            return true;
        else
            return false;
    }

    internal Funcionario FindAll(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
