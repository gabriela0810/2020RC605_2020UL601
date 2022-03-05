using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020RC605_2020UL601.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020RC605_2020UL601.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly VentasContext _contexto;

        public ProductoController(VentasContext mycontext)
        {
            this._contexto=mycontext;
        }


        [HttpGet]
        [Route("api/productos")]
        public IActionResult Get()
        {
            var prodlist = from p in _contexto.Productos
                          select new
                          {
                              p.Id,
                              p.Producto,
                              p.Precio

                          };

            if (prodlist.Count()>0)
            {
                return Ok(prodlist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/productos/{id}")]
        public IActionResult Get(int id)
        {

            var prodlist = (from p in _contexto.Productos
                            where p.Id==id
                            select new
                            {
                                p.Id,
                                p.Producto,
                                p.Precio

                            }).FirstOrDefault();

            if (prodlist!=null)
            {
                return Ok(prodlist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/productos/")]
        public IActionResult agregarProd([FromBody] Productos pNew)
        {

            _contexto.Productos.Add(pNew);
            _contexto.SaveChanges();

            return Ok(pNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/productos/")]
        public IActionResult editarProd([FromBody] Productos pUpdate)
        {

            Productos pExist = (from p in _contexto.Productos
                                  where p.Id==pUpdate.Id
                                  select p).FirstOrDefault();

            if (pExist is null)
            {
                return NotFound();
            }

            pExist.Id=pUpdate.Id;
            pExist.Producto=pUpdate.Producto;
            pExist.Precio=pUpdate.Precio;


            _contexto.Entry(pExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(pExist);
        }

    }
}
