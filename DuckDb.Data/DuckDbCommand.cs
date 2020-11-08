using System.Data;
using System.Data.Common;
using DuckDb.Bindings;

namespace DuckDb
{
    public class DuckDbCommand : DbCommand
    {
        private string _commandText;
        private DuckDbConnection _connection;
        private DuckDbTransaction _transaction;

        public DuckDbCommand(string commandText, DuckDbConnection connection)
        {
            _commandText = commandText;
            _connection = connection;
        }

        public sealed override string CommandText
        {
            get => _commandText;
            set => _commandText = value;
        }

        protected sealed override DbConnection DbConnection
        {
            get => _connection;
            set => _connection = (DuckDbConnection)value;
        }
        
        protected override DbTransaction DbTransaction
        {
            get => _transaction;
            set => _transaction = (DuckDbTransaction)value;
        }

        public override int ExecuteNonQuery()
        {
            using (var reader = ExecuteDbDataReader(CommandBehavior.Default))
            {
                return -1;
            }
        }

        public override object ExecuteScalar()
        {
            using (var reader = ExecuteDbDataReader(CommandBehavior.Default))
            {
                return -1;
            }
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            var state = _connection.Bindings.DuckdbQuery(_connection.Connection.Pointer, _commandText, out var result);
            if (state == DuckdbState.DuckDBError)
            {
                throw new DuckDbException("Failed to execute command");
            }
            
            var reader = new DuckDbDataReader();

            return reader;
        }

        public override void Prepare()
        {
            throw new System.NotImplementedException();
        }

        public override int CommandTimeout
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override CommandType CommandType
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        protected override DbParameterCollection DbParameterCollection => throw new System.NotImplementedException();

        public override bool DesignTimeVisible
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        protected override DbParameter CreateDbParameter()
        {
            throw new System.NotImplementedException();
        }
        
        public override void Cancel()
        {
            throw new System.NotImplementedException();
        }
    }
}