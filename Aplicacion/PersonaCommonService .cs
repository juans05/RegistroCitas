using Domain.interfaces;
using Domain.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilitarios;

namespace Aplicacion
{
    public class PersonaCommonService : IPersonaCommonService
    {
        private readonly IClienteRepository _personaRepository;

        public PersonaCommonService(IClienteRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<bool> consultarExisteDni(string numeroDocumento)
        {
            return await _personaRepository.consultarExisteDni(numeroDocumento);
           
        }

        public async Task<DTOCliente> ConsultarIdCliente(DTOCliente entidad)
        {
            return await _personaRepository.ConsultarIdCliente(entidad);
        }

        public async Task<StatusReponse<DTOCliente>> EliminarCliente(int idCliente)
        {
            return await _personaRepository.EliminarCliente(idCliente);
        }

        public async Task<StatusReponse<List<DTOCliente>>> ListarCliente(DTOCliente entidad)
        {
            return await _personaRepository.ListarCliente(entidad);
        }

        public async Task<StatusReponse<List<Especialidad>>> listarEspecialidad()
        {
            throw new NotImplementedException();
        }

        public async Task<StatusReponse<DTOCliente>> registraCliente(DTOCliente entidad)
        {
            return await _personaRepository.registraCliente(entidad);
        }

        public async Task<StatusReponse<DTOCliente>> updateCliente(DTOCliente entidad)
        {
            return await _personaRepository.updateCliente(entidad);
        }
    }
}
