namespace XDEV_001_FRONT.Models
{
    public class ProductoViewModel
    {

        public int CodProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public DateTime? FecCreacion { get; set; }
    }

    
}
