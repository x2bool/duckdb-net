using System.Data.Common;

namespace DuckDb
{
    public class DuckDbException : DbException
    {
        public DuckDbException(string message)
            : base(message)
        {
        }
    }
}