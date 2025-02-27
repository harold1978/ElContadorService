

namespace FrontElContador.Models;


public  class BalanceGeneral
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal TotalActivos { get; set; }

    public decimal TotalPasivos { get; set; }

    public decimal TotalPatrimonio { get; set; }
}