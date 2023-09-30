using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructura.conexion
{
    public  interface IConexion
    {
        Task<IDbConnection> BeginConnection(bool useTransaction = false);

        Task Complete();

        Task Rollback();

        Task CloseConnection();

        IDbTransaction GetTransaction();

        Task ExecuteCommandAsync(string commandText, params DbParameter[] values);

        Task ExecuteCommandAsync(string commandText, string name, object value);

        //IDataReader ExecuteReader(string commandText, params DbParameter[] values);

        //IDataReader ExecuteReader(string commandText, string name, object value);

        Task<IDataReader> ExecuteReaderAsync(string commandText, params DbParameter[] values);

        Task<IDataReader> ExecuteReaderAsync(string commandText, string name, object value);
    }
}
