using Xunit;

namespace DuckDb.Tests.Commands
{
    public class CommandTests
    {
        [Fact]
        public void ExecuteScalar_Always_ExecutesCommand()
        {
            var dbConnection = new DuckDbConnection();
            dbConnection.Open();
            
            try
            {
                using var command = new DuckDbCommand("SELECT 1;", dbConnection);
                command.ExecuteScalar();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        [Fact]
        public void ExecuteNonQuery_Always_ExecutesCommand()
        {
            var dbConnection = new DuckDbConnection();
            dbConnection.Open();
            
            try
            {
                using var command = new DuckDbCommand("SELECT 1;", dbConnection);
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}