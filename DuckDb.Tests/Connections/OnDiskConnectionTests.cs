using System;
using System.IO;
using Xunit;

namespace DuckDb.Tests.Connections
{
    public class OnDiskConnectionTests
    {
        [Fact]
        public void Open_Always_OpensConnection()
        {
            var dbConnection = CreateConnection();

            try
            {
                dbConnection.Open();
            }
            finally
            {
                CleanupConnection(dbConnection);
            }
        }

        [Fact]
        public void Close_Always_ClosesConnection()
        {
            var dbConnection = CreateConnection();

            try
            {
                dbConnection.Open();
                dbConnection.Close();
            }
            finally
            {
                CleanupConnection(dbConnection);
            }
        }

        [Fact]
        public void Open_WhenOtherConnectionAlreadyOpened_OpensConnection()
        {
            var dbConnection1 = CreateConnection();
            var dbConnection2 = DuplicateConnection(dbConnection1);

            try
            {
                dbConnection1.Open();
                dbConnection2.Open();
            }
            finally
            {
                CleanupConnection(dbConnection1);
                CleanupConnection(dbConnection2);
            }
        }

        [Fact]
        public void Close_WhenOtherConnectionAlreadyOpened_ClosesConnection()
        {
            var dbConnection1 = CreateConnection();
            var dbConnection2 = DuplicateConnection(dbConnection1);

            try
            {
                dbConnection1.Open();
                dbConnection2.Open();
                
                dbConnection1.Close();
                dbConnection2.Close();
            }
            finally
            {
                CleanupConnection(dbConnection1);
                CleanupConnection(dbConnection2);
            }
        }

        private DuckDbConnection CreateConnection()
        {
            var filename = $"test-{Guid.NewGuid():N}.db";
            return new DuckDbConnection($"File={filename}");
        }

        private DuckDbConnection DuplicateConnection(DuckDbConnection connection)
        {
            var builder = DuckDbConnectionStringBuilder.Parse(connection.ConnectionString);
            return new DuckDbConnection($"File={builder.File}");
        }

        private void CleanupConnection(DuckDbConnection connection)
        {
            var builder = DuckDbConnectionStringBuilder.Parse(connection.ConnectionString);
            File.Delete(builder.File);
            File.Delete(builder.File + ".wal");
        }
    }
}