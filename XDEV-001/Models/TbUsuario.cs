using System;
using System.Collections.Generic;

namespace XDEV_001.Models;

public partial class TbUsuario
{
    public int CodUsuario { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? AccessToken { get; set; }

    public string? Designation { get; set; }

    public string? UserMessage { get; set; }

    public DateTime? FecCreacion { get; set; }
}
