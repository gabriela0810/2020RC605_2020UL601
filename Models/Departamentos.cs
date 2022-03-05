using System.ComponentModel.DataAnnotations;

namespace _2020RC605_2020UL601.Models
{
    public class Departamentos
    {
        [Key]
        public int id { get; set; }
        public int departamento { get; set; }
    }
}
