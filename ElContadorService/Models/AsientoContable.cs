﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElContadorService.Models;

[Table("AsientoContable")]
public partial class AsientoContable
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Detalle { get; set; }

    public int NroAsiento { get; set; }

    [InverseProperty("AsientoContable")]
    public virtual ICollection<DetalleAsientoContable> DetalleAsientoContables { get; set; } = new List<DetalleAsientoContable>();
}