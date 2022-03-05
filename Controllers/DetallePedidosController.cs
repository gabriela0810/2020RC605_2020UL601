using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020RC605_2020UL601.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020RC605_2020UL601.Controllers
{
    public class DetallePedidosController : ControllerBase
    {
        private readonly VentasContext _contexto;

        public DetallePedidosController(VentasContext mycontext)
        {
            this._contexto=mycontext;
        }


        [HttpGet]
        [Route("api/detallepedidos")]
        public IActionResult Get()
        {
            var detlist = from d in _contexto.DetallePedidos
                          join p in _contexto.Pedidos on d.IdPedido equals p.Id
                          join pt in _contexto.Productos on d.IdProducto equals pt.Id
                          select new
                             {
                                 d.Id,
                                 p.FechaPedido,
                                 pt.Producto,
                                 d.Cantidad

                             };

            if (detlist.Count()>0)
            {
                return Ok(detlist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/detallepedidos/{id}")]
        public IActionResult Get(int id)
        {

            var detalist = (from d in _contexto.DetallePedidos
                            join p in _contexto.Pedidos on d.IdPedido equals p.Id
                            join pt in _contexto.Productos on d.IdProducto equals pt.Id
                            where d.Id==id
                            select new
                            {
                                d.Id,
                                p.FechaPedido,
                                pt.Producto,
                                d.Cantidad

                            }).FirstOrDefault();

            if (detalist!=null)
            {
                return Ok(detalist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/detallepedidos/")]
        public IActionResult agregarDetall([FromBody] DetallePedidos detallNew)
        {

            _contexto.DetallePedidos.Add(detallNew);
            _contexto.SaveChanges();

            return Ok(detallNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/detallepedidos/")]
        public IActionResult editarDetall([FromBody] DetallePedidos detallUpdate)
        {

            DetallePedidos detallExist = (from d in _contexto.DetallePedidos
                                         where d.Id==detallUpdate.Id
                                         select d).FirstOrDefault();

            if (detallExist is null)
            {
                return NotFound();
            }

            detallExist.Id=detallUpdate.Id;
            detallExist.IdPedido=detallUpdate.IdPedido;
            detallExist.IdProducto=detallUpdate.IdProducto;
            detallExist.Cantidad=detallUpdate.Cantidad;


            _contexto.Entry(detallExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(detallExist);
        }
    }
}
