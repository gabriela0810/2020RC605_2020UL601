using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020RC605_2020UL601.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020RC605_2020UL601.Controllers
{
    public class DepartamentosController : ControllerBase
    {
        private readonly VentasContext _contexto;

        public DepartamentosController(VentasContext mycontext)
        {
            this._contexto=mycontext;
        }

        [HttpGet]
        [Route("api/departamentos")]
        public IActionResult Get()
        {
            var departlist = from d in _contexto.Departamentos
                            select new
                            {
                                d.id,
                                d.departamento,

                            };

            if (departlist.Count()>0)
            {
                return Ok(departlist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/departamentos/{id}")]
        public IActionResult Get(int id)
        {

            var departlist = (from d in _contexto.Departamentos
                             where d.id==id
                             select new
                             {
                                 d.id,
                                 d.departamento

                             }).FirstOrDefault();

            if (departlist!=null)
            {
                return Ok(departlist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/departamentos/")]
        public IActionResult agregarDepart([FromBody] Departamentos departNew)
        {

            _contexto.Departamentos.Add(departNew);
            _contexto.SaveChanges();

            return Ok(departNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/departamentos/")]
        public IActionResult editarDepart([FromBody] Departamentos departUpdate)
        {

            Departamentos departExist = (from d in _contexto.Departamentos
                                    where d.id==departUpdate.id
                                    select d).FirstOrDefault();

            if (departExist is null)
            {
                return NotFound();
            }

            departExist.id=departUpdate.id;
            departExist.departamento=departUpdate.departamento;


            _contexto.Entry(departExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(departExist);
        }

    }
}
