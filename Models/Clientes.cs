using System.ComponentModel.DataAnnotations;

namespace _2020RC605_2020UL601.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string FechaNac { get; set; }
    }
}
