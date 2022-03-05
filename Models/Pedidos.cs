
﻿using System.ComponentModel.DataAnnotations;

namespace _2020RC605_2020UL601.Models
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string FechaPedido { get; set; }
    }
}
