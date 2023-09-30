
using Aplicacion;
using Aplicacion.Interfaces;
using Aplicacion.ModuloCliente;
using Domain.modelo;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroCitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IPersonaCommonService _personaCommonService;


        public ClienteController(IPersonaCommonService personaCommonService)
        {
            _personaCommonService = personaCommonService;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get(string nroDocumento)
        {
            DTOCliente dtCliente = new DTOCliente();
            dtCliente.NumeroDocumento = nroDocumento;
            var clientes = await _personaCommonService.ListarCliente(dtCliente);
            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOCliente>> Get(int id)
        {
            DTOCliente dtCliente = new DTOCliente();
            dtCliente.idCliente = id;
            var persona = await _personaCommonService.ConsultarIdCliente(dtCliente);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post(DTOCliente dtCliente)
        {
            var existeDNi = _personaCommonService.consultarExisteDni(dtCliente.NumeroDocumento);


            if (existeDNi.IsCompleted)
            {
               var clientes = await _personaCommonService.registraCliente(dtCliente);
                return Ok(clientes);
            }
            else {
               
                return Ok("Usuario con dni existente");
            }
            
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clientes = await _personaCommonService.EliminarCliente(id);
                return Ok(clientes);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
