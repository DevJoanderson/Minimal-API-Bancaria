namespace ApiBancaria.Models;

public class Conta
{
    public int Id { get; set; }

    public string Numero { get; set; } = string.Empty;

    public string Agencia { get; set; } = string.Empty;

    public string Digito { get; set; } = string.Empty;

    public string Titular { get; set; } = string.Empty;

    public decimal Saldo { get; set; }

    public decimal LimiteChequeEspecial { get; set; }


    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            return;
        }

        Saldo += valor;
    }

}