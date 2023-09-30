
using Aplicacion.Interfaces;

using Domain.interfaces;
using Domain.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilitarios;

namespace Aplicacion.ModuloCliente
{
    public class Cliente 
    {

        private readonly IPersonaCommonService _ClienteService;
        public Cliente(IPersonaCommonService _clienteService) {
            this._ClienteService = _clienteService;
        }

        public async Task<DTOCliente> ConsultarIdCliente(DTOCliente entidad)
        {
            return await this._ClienteService.ConsultarIdCliente(entidad);
        }

        public async Task<StatusReponse<DTOCliente>> EliminarCliente(int idCliente)
        {
            return await this._ClienteService.EliminarCliente(idCliente);
        }

        public async  Task<StatusReponse<List<DTOCliente>>> ListarCliente(DTOCliente entidad)
        {
            return await this._ClienteService.ListarCliente(entidad);
        }

        public async Task<StatusReponse<List<Especialidad>>> listarEspecialidad()
        {
            return await this._ClienteService.listarEspecialidad();
        }

        public async Task<StatusReponse<DTOCliente>> registraCliente(DTOCliente entidad)
        {
            return await this._ClienteService.registraCliente(entidad);
        }

        public async Task<StatusReponse<DTOCliente>> updateCliente(DTOCliente entidad)
        {
            return await this._ClienteService.updateCliente(entidad);
        }

       
    }
}
