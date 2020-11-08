using Xunit;

namespace DuckDb.Tests.Connections
{
    public class InMemoryConnectionTests
    {
        [Fact]
        public void Open_WhenConnectionStringNotProvided_OpensInMemoryDatabase()
        {
            var dbConnection = new DuckDbConnection();
            dbConnection.Open();
        }
        
        [Fact]
        public void Close_WhenConnectionStringNotProvided_ClosesInMemoryDatabase()
        {
            var dbConnection = new DuckDbConnection();
            dbConnection.Open();
            dbConnection.Close();
        }

        [Fact]
        public void Open_WhenOtherInMemoryConnectionOpened_OpensInMemoryDatabase()
        {
            var dbConnection1 = new DuckDbConnection();
            var dbConnection2 = new DuckDbConnection();
            dbConnection1.Open();
            dbConnection2.Open();
        }

        [Fact]
        public void Close_WhenOtherInMemoryConnectionOpened_ClosesInMemoryDatabase()
        {
            var dbConnection1 = new DuckDbConnection();
            var dbConnection2 = new DuckDbConnection();
            dbConnection1.Open();
            dbConnection2.Open();
            dbConnection1.Close();
            dbConnection2.Close();
        }
    }
}