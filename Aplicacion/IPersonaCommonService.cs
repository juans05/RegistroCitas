using Domain.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilitarios;

namespace Aplicacion
{
    public interface IPersonaCommonService
    {
        Task<StatusReponse<DTOCliente>> registraCliente(DTOCliente entidad);

        Task<StatusReponse<DTOCliente>> updateCliente(DTOCliente entidad);

        Task<StatusReponse<DTOCliente>> EliminarCliente(int idCliente);

        Task<StatusReponse<List<DTOCliente>>> ListarCliente(DTOCliente entidad);

        Task<DTOCliente> ConsultarIdCliente(DTOCliente entidad);

        Task<StatusReponse<List<Especialidad>>> listarEspecialidad();
        Task<bool>   consultarExisteDni(string numeroDocumento);
    }
}
