using System.ComponentModel.DataAnnotations;

namespace _2020RC605_2020UL601.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Producto { get; set; } //ew
        public double Precio { get; set; }
    }
}