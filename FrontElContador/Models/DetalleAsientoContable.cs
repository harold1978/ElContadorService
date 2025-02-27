

namespace FrontElContador.Models;


public  class DetalleAsientoContable
{

    public int Id { get; set; }

    public int AsientoContableId { get; set; }

    public int CuentaContableId { get; set; }

    public string Cargo { get; set; }

    public decimal Monto { get; set; }

    public virtual AsientoContable AsientoContable { get; set; }

    public virtual CuentaContable CuentaContable { get; set; }
}