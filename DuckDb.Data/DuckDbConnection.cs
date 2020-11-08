using System;
using System.Data;
using System.Data.Common;
using DuckDb.Bindings.Platforms;
using DuckDb.Connections;

namespace DuckDb
{
    public class DuckDbConnection : DbConnection
    {
        private static readonly ConnectionManager ConnectionManager = new ConnectionManager();
        
        internal readonly NativeBindings Bindings;
        internal ConnectionManager.Connection Connection;
        
        private string _connectionString;

        public DuckDbConnection(string connectionString)
            : this()
        {
            _connectionString = connectionString;
        }

        public DuckDbConnection()
        {
            Bindings = NativeBindings.AutoDetected;
            
            if (Bindings == null)
            {
                throw new PlatformNotSupportedException("Platform is not supported");
            }
        }

        public override string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        
        public override void Open()
        {
            if (Connection == null)
            {
                var builder = DuckDbConnectionStringBuilder.Parse(_connectionString);

                if (builder.File != null)
                {
                    Connection = ConnectionManager.Connect(Bindings, builder.File);
                }
                else
                {
                    Connection = ConnectionManager.ConnectInMemory(Bindings, builder.InMemory);
                }
            }
        }

        public override void Close()
        {
            if (Connection != null)
            {
                ConnectionManager.Disconnect(Bindings, Connection);
                Connection = null;
            }
        }
        
        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new System.NotImplementedException();
        }
        
        protected override DbCommand CreateDbCommand()
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeDatabase(string databaseName) => throw new System.NotImplementedException();

        public override string Database => throw new System.NotImplementedException();

        public override ConnectionState State => throw new System.NotImplementedException();

        public override string DataSource => throw new System.NotImplementedException();

        public override string ServerVersion => throw new System.NotImplementedException();
    }
}