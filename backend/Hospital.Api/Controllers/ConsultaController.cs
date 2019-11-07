using Hospital.Entity;
using Hospital.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaService consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            this.consultaService = consultaService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                consultaService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Consulta consulta)
        {
            return Ok(
                consultaService.Save(consulta)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Consulta consulta)
        {
            return Ok(
                consultaService.Update(consulta)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                consultaService.Delete(id)
            );
        }
    }
}