<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 11815107b67b7d0560da4e0ae295dad04b7ab9c8

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
