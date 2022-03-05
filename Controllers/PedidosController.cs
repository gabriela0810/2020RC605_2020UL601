using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020RC605_2020UL601.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020RC605_2020UL601.Controllers
{
    public class PedidosController : ControllerBase
    {
        private readonly VentasContext _contexto;

        public PedidosController(VentasContext mycontext)
        {
            this._contexto=mycontext;
        }


        [HttpGet]
        [Route("api/pedidos")]
        public IActionResult Get()
        {
            var pedlist = from p in _contexto.Pedidos
                          join c in _contexto.Clientes on p.IdCliente equals c.Id
                          select new
                          {
                              p.Id,
                              c.Nombre,
                              p.FechaPedido

                          };

            if (pedlist.Count()>0)
            {
                return Ok(pedlist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/pedidos/{id}")]
        public IActionResult Get(int id)
        {

            var detalist = (from p in _contexto.Pedidos
                            join c in _contexto.Clientes on p.IdCliente equals c.Id
                            where p.Id==id
                            select new
                            {
                                p.Id,
                                c.Nombre,
                                p.FechaPedido

                            }).FirstOrDefault();

            if (detalist!=null)
            {
                return Ok(detalist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/pedidos/")]
        public IActionResult agregarPedid([FromBody] Pedidos pedidNew)
        {

            _contexto.Pedidos.Add(pedidNew);
            _contexto.SaveChanges();

            return Ok(pedidNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/pedidos/")]
        public IActionResult editarPedid([FromBody] Pedidos pedidUpdate)
        {

            Pedidos pedidExist = (from p in _contexto.Pedidos
                                          where p.Id==pedidUpdate.Id
                                          select p).FirstOrDefault();

            if (pedidExist is null)
            {
                return NotFound();
            }

            pedidExist.Id=pedidUpdate.Id;
            pedidExist.IdCliente=pedidUpdate.IdCliente;
            pedidExist.FechaPedido=pedidUpdate.FechaPedido;


            _contexto.Entry(pedidExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(pedidExist);
        }

    }
}
