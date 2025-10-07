using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ClientAuthentication
{
    public class SqlServerClientSourceAuthenticationHandler : IClientSourceAuthenticationHandler, IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private bool disposedValue;

        public SqlServerClientSourceAuthenticationHandler(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }



        public bool Validate(string clientSource)
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            var query = "SELECT TOP 1 1 FROM ClientSources WHERE ClientId = @ClientSource AND GETDATE() >= ValidFrom AND GETDATE() <= ValidTo AND IsEnbale = 1";
            using var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ClientSource", clientSource);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }

            _connection.Close();
            return false;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_connection.State == System.Data.ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                    _connection.Dispose();
                }
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
