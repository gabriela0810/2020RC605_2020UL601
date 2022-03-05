using Microsoft.EntityFrameworkCore;
using _2020RC605_2020UL601.Models;

namespace _2020RC605_2020UL601
{
    public class VentasContext: DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> options) : base(options)
        {
            
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<DetallePedidos> DetallePedidos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Productos> Productos { get; set; }

    }
}


