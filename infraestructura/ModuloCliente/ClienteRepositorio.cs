using Dapper;
using Domain.interfaces;
using Domain.modelo;
using infraestructura.conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilitarios;
using static Dapper.SqlMapper;

namespace infraestructura.ModuloCliente
{
    public class ClienteRepositorio : IClienteRepository
    {
        protected IConexion mConexion;
      

        public ClienteRepositorio(IConexion _connection)
        {
            this.mConexion = _connection;

        }

        public async Task<DTOCliente> ConsultarIdCliente(DTOCliente entidad)
        {
            DTOCliente entity = new DTOCliente();
            using (var scope = await mConexion.BeginConnection())
            {
                try
                {
                    var items = await scope.QueryAsync<DTOCliente>("SP_consultarCliente",
                    new
                    {
                        @idCliente = entidad.idCliente
                    }, commandType: CommandType.StoredProcedure); ;

                    entity = (DTOCliente)items.FirstOrDefault();

                }
                catch (Exception ex)
                {

                }
            }
            return entity;
        }
        public async Task<StatusReponse<List<DTOCliente>>> ListarCliente(DTOCliente entidad)
        {
            StatusReponse<List<DTOCliente>> entity = new StatusReponse<List<DTOCliente>>();
            using (var scope = await mConexion.BeginConnection())
            {
                try
                {
                    var items = await scope.QueryAsync<DTOCliente>("Sp_listarCliente",
                    new
                    {
                        @nroDocumento = entidad.NumeroDocumento
                    }, commandType: CommandType.StoredProcedure);

                    entity.Data = (List<DTOCliente>)items;
                    entity.Success = true;
                    
                }
                catch (Exception ex)
                {

                }
            }
            return entity;
        }
    
        public async Task<StatusReponse<List<Especialidad>>> listarEspecialidad()
        {
            StatusReponse<List<Especialidad>> entity = new StatusReponse<List<Especialidad>>();
            using (var scope = await mConexion.BeginConnection())
            {
                try
                {
                    var items = await scope.QueryAsync<Especialidad>("Sp_ConsultarEventoCategoria",
                    new
                    {
                    }, commandType: CommandType.StoredProcedure);

                    entity.Data = (List<Especialidad>)items;
                    entity.Success = true;

                }
                catch (Exception ex)
                {

                }
            }
            return entity;
        }
        public async Task<StatusReponse<DTOCliente>> EliminarCliente(int idCliente)
        {
            StatusReponse<DTOCliente> status = new StatusReponse<DTOCliente>() { Success = false, Title = "Error al Eliminar Categoria del evento" };
            using (var scope = await mConexion.BeginConnection())
            {
                try
                {
                    var items = await scope.QueryAsync<DTOCliente>("Sp_EliminarCliente",
                    new
                    {
                        @idCliente = idCliente

                    }, commandType: CommandType.StoredProcedure);
                    status.Success = true;
                    status.Title = "Se elimino el cliente";
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return status;
        }
             

        public async Task<StatusReponse<DTOCliente>> registraCliente(DTOCliente entidad)
        {
            StatusReponse<DTOCliente> _cliente = new StatusReponse<DTOCliente>() { Success = false, Title ="" };
            using (var scope  =  await mConexion.BeginConnection())
            {
                try
                {
                    var resultado = await scope.QueryAsync<DTOCliente>("Sp_CreateCliente", new
                    {

                        @idespecialidad = entidad.id_Especialidad,
                        @nombreCompleto = entidad.nombreCompleto,
                        @id_Tipodocumento = entidad.id_Tipodocumento,
                        @nroDocumento = entidad.NumeroDocumento
                    }, commandType:CommandType.StoredProcedure);
                    _cliente.Data = (DTOCliente)resultado.FirstOrDefault();
                    _cliente.Success = true;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return _cliente;
        }

        public async Task<StatusReponse<DTOCliente>> updateCliente(DTOCliente entidad)
        {
            StatusReponse<DTOCliente> status = new StatusReponse<DTOCliente>() { Success = false, Title = "Error en la Actualizacón" };
            using (var scope = await mConexion.BeginConnection())
            {
                try
                {
                    var items = await scope.QueryAsync<DTOCliente>("Sp_udpateCliente",
                    new
                    {
                        @idespecialidad = entidad.id_Especialidad,
                        @nombreCompleto = entidad.nombreCompleto,
                        @id_Tipodocumento = entidad.id_Tipodocumento,
                        @nroDocumento = entidad.NumeroDocumento,
                        @idCliente = entidad.idCliente,
                    }, commandType: CommandType.StoredProcedure);
                    status.Success = true;
                    status.Title = "Se actualizo el cliente";
                }
                catch (Exception e)
                {
                  
                }
            }
            return status;
        }

        public async Task<bool> consultarExisteDni(string numeroDocumento)
        {
            DTOCliente entity = new DTOCliente();
            Boolean resultado = false;
            
            using (var scope = await mConexion.BeginConnection())
            {
                try
                {
                    var items = await scope.QueryAsync<DTOCliente>("SP_existePersonaConDocumento",
                    new
                    {
                        @nroDocumento = numeroDocumento
                    }, commandType: CommandType.StoredProcedure); ;

                    entity = (DTOCliente)items.FirstOrDefault();
                    if (entity.existeUusario>0)
                    {
                        resultado = true;

                    }
                    else { resultado = false; }
                }
                catch (Exception ex)
                {
                   
                }
            }
            return resultado;
        }
    }
}
