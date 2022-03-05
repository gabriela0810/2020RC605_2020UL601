
﻿using System.ComponentModel.DataAnnotations;

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

}
