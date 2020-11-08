using System.Data;
using System.Data.Common;

namespace DuckDb
{
    public class DuckDbTransaction : DbTransaction
    {
        public override void Commit()
        {
            throw new System.NotImplementedException();
        }

        public override void Rollback()
        {
            throw new System.NotImplementedException();
        }

        protected override DbConnection DbConnection => throw new System.NotImplementedException();

        public override IsolationLevel IsolationLevel => throw new System.NotImplementedException();
    }
}