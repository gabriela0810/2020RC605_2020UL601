using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020RC605_2020UL601.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020RC605_2020UL601.Controllers
{
    public class ClientesController : ControllerBase
    {
        private readonly VentasContext _contexto;

        public ClientesController(VentasContext mycontext)
        {
            this._contexto=mycontext;
        }

        [HttpGet]
        [Route("api/clientes")]
        public IActionResult Get()
        {
            var clienlist = from c in _contexto.Clientes
                            join d in _contexto.Departamentos on c.IdDepartamento equals d.id
                            select new
                            {
                                c.Id,
                                d.departamento,
                                c.Nombre,
                                c.FechaNac

                            };

            if (clienlist.Count()>0)
            {
                return Ok(clienlist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/clientes/{id}")]
        public IActionResult Get(int id)
        {

            var clienlist = (from c in _contexto.Clientes
                            join d in _contexto.Departamentos on c.IdDepartamento equals d.id
                            where c.Id==id
                            select new
                            {
                                c.Id,
                                d.departamento,
                                c.Nombre,
                                c.FechaNac

                            }).FirstOrDefault();

            if (clienlist!=null)
            {
                return Ok(clienlist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/clientes/")]
        public IActionResult agregarClient([FromBody] Clientes clientNew)
        {

            _contexto.Clientes.Add(clientNew);
            _contexto.SaveChanges();

            return Ok(clientNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/clientes/")]
        public IActionResult editarClient([FromBody] Clientes clientUpdate)
        {

            Clientes clientExist = (from c in _contexto.Clientes
                                  where c.Id==clientUpdate.Id
                                  select c).FirstOrDefault();

            if (clientExist is null)
            {
                return NotFound();
            }

            clientExist.IdDepartamento=clientUpdate.IdDepartamento;
            clientExist.Nombre=clientUpdate.Nombre;
            clientExist.FechaNac=clientUpdate.FechaNac;
            

            _contexto.Entry(clientExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(clientExist);
        }
    }
}
