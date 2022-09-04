using System.Collections.Generic;

namespace src.Models;

public class Person
{

    public Person()
    
    {

        this.Nome = "template";
        this.Idade = 0; //toda vez q for criado um objeto do tipo "pessoa", ele terá esses "elementos" e "valores"
        this.Cpf = "template";
        this.Contracts = new List<Contract>();
        this.Ativado = true;
    }
   
   public Person(string Nome, int Idade, string Cpf){
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf = Cpf;
        this.Contracts = new List<Contract>();
        this.Ativado = true;
   }

   
    //nome,idade,cpf,ativa



    public int Id { get; set; }
    public string Nome{ get; set; }
    public int Idade { get; set; }
    public string Cpf { get; set; }
    public bool Ativado { get; set; }

    public List<Contract>  Contracts {get; set;}

}