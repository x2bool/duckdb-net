using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DuckDb.Bindings;
using DuckDb.Bindings.Platforms;

namespace DuckDb.Connections
{
    internal class ConnectionManager
    {
        private readonly object _locker = new object();
        
        private readonly Dictionary<string, Database> _filesToDatabases = new Dictionary<string, Database>();
        private readonly Dictionary<string, Database> _namesToDatabases = new Dictionary<string, Database>();
        private readonly Dictionary<Connection, Database> _connectionsToDatabases = new Dictionary<Connection, Database>();
        
        public Connection Connect(NativeBindings bindings, string filename)
        {
            lock (_locker)
            {
                var file = Path.GetFullPath(filename);
            
                // check if there is already opened database for this file
                if (!_filesToDatabases.TryGetValue(file, out var database))
                {
                    // open database if there are none opened
                    var databaseState = bindings.DuckdbOpen(filename, out var databasePtr);
                    database = new Database(databasePtr);
                    
                    switch (databaseState)
                    {
                        case DuckdbState.DuckDBSuccess:
                            _filesToDatabases.Add(file, database);
                            break;
                    
                        case DuckdbState.DuckDBError:
                            throw new DuckDbException($"Could not open database at: {filename}");
                    }
                }
            
                // create new connection to the database
                var connectionState = bindings.DuckdbConnect(database.Pointer, out var connectionPtr);
                var connection = new Connection(connectionPtr);
                switch (connectionState)
                {
                    case DuckdbState.DuckDBSuccess:
                        _connectionsToDatabases.Add(connection, database);
                        break;
                    
                    case DuckdbState.DuckDBError:
                        throw new DuckDbException($"Could not connect to database at: {filename}");
                }

                return connection;
            }
        }

        public Connection ConnectInMemory(NativeBindings bindings, string name = null)
        {
            lock (_locker)
            {
                if (name == null)
                {
                    name = "";
                }
                
                // check if there is already opened database for this file
                if (!_namesToDatabases.TryGetValue(name, out var database))
                {
                    // open database if there are none opened
                    var databaseState = bindings.DuckdbOpen(null, out var databasePtr);
                    database = new Database(databasePtr);
                    
                    switch (databaseState)
                    {
                        case DuckdbState.DuckDBSuccess:
                            _namesToDatabases.Add(name, database);
                            break;
                    
                        case DuckdbState.DuckDBError:
                            throw new DuckDbException($"Could not open in-memory database");
                    }
                }
                
                // create new connection to the database
                var connectionState = bindings.DuckdbConnect(database.Pointer, out var connectionPtr);
                var connection = new Connection(connectionPtr);
                switch (connectionState)
                {
                    case DuckdbState.DuckDBSuccess:
                        _connectionsToDatabases.Add(connection, database);
                        break;
                    
                    case DuckdbState.DuckDBError:
                        throw new DuckDbException($"Could not connect to in-memory database");
                }

                return connection;
            }
        }

        public void Disconnect(NativeBindings bindings, Connection connection)
        {
            lock (_locker)
            {
                // close connection itself
                var connectionPtr = connection.Pointer;
                bindings.DuckdbDisconnect(ref connectionPtr);

                var database = _connectionsToDatabases[connection];
                _connectionsToDatabases.Remove(connection);

                if (!_connectionsToDatabases.ContainsValue(database))
                {
                    // close database if there are no connections to it
                    var databasePtr = database.Pointer;
                    bindings.DuckdbClose(ref databasePtr);

                    var file = _filesToDatabases.FirstOrDefault(pair => pair.Value == database).Key;
                    if (file != null)
                    {
                        _filesToDatabases.Remove(file);
                    }

                    var name = _namesToDatabases.FirstOrDefault(pair => pair.Value == database).Key;
                    if (name != null)
                    {
                        _namesToDatabases.Remove(name);
                    }
                }
            }
        }
        
        public class Connection
        {
            public IntPtr Pointer { get; }

            public Connection(IntPtr pointer)
            {
                Pointer = pointer;
            }
        }
        
        public class Database
        {
            public IntPtr Pointer { get; }

            public Database(IntPtr pointer)
            {
                Pointer = pointer;
            }
        }
    }
}