

namespace FrontElContador.Models;


public  class AsientoContable
{

    public int Id { get; set; }


    public DateTime Fecha { get; set; }

    public string Detalle { get; set; }

    public int NroAsiento { get; set; }

    public virtual ICollection<DetalleAsientoContable> DetalleAsientoContables { get; set; } = new List<DetalleAsientoContable>();
}