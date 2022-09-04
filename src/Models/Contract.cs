namespace src.Models;

public class Contract
{
    public Contract()
    {
            this.DateCreation = DateTime.Now;
            this.Valor = 0;
            this.TokenId = "000000";
            this.Paid = false;
    }

    public Contract(string TokenId, double Valor)
    {
        this.DateCreation = DateTime.Now;
        this.TokenId = TokenId ;
        this.Valor = Valor;
        this.Paid = false;
        
    }


    public int Id { get; set; }
    public DateTime DateCreation  { get; set; }

    public string TokenId { get; set; }

    public double Valor { get; set; }

    public bool Paid { get; set; }


    public int PersonId { get; set; }
}