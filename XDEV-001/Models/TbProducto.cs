using System;
using System.Collections.Generic;

namespace XDEV_001.Models;

public partial class TbProducto
{
    public int CodProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public DateTime? FecCreacion { get; set; }
}
