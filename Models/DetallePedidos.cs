<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 11815107b67b7d0560da4e0ae295dad04b7ab9c8

namespace _2020RC605_2020UL601.Models
{
    public class DetallePedidos
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 11815107b67b7d0560da4e0ae295dad04b7ab9c8
