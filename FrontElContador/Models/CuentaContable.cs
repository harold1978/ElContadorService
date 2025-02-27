namespace FrontElContador.Models;
public class CuentaContable
{

    public int Id { get; set; }


    public string Codigo { get; set; }

    public string Nombre { get; set; }

    public string Tipo { get; set; }

    public decimal Saldo { get; set; }

    public virtual ICollection<DetalleAsientoContable> DetalleAsientoContables { get; set; } = new List<DetalleAsientoContable>();
}