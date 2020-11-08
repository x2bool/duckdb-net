using System;

namespace DuckDb.Bindings.Platforms
{
    internal class LinuxBindings : NativeBindings
    {
        public override DuckdbState DuckdbOpen(string athRef, out IntPtr outDatabase)
        {
            throw new NotImplementedException();
        }

        public override void DuckdbClose(ref IntPtr database)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbConnect(IntPtr database, out IntPtr outConnection)
        {
            throw new NotImplementedException();
        }

        public override void DuckdbDisconnect(ref IntPtr connection)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbQuery(IntPtr connection, string query, out DuckdbResult outResult)
        {
            throw new NotImplementedException();
        }

        public override void DuckdbDestroyResult(ref DuckdbResult result)
        {
            throw new NotImplementedException();
        }

        public override string DuckdbColumnName(ref DuckdbResult result, ulong col)
        {
            throw new NotImplementedException();
        }

        public override bool DuckdbValueBoolean(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override byte DuckdbValueInt8(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override short DuckdbValueInt16(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override int DuckdbValueInt32(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override long DuckdbValueInt64(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override float DuckdbValueFloat(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override double DuckdbValueDouble(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override string DuckdbValueVarchar(ref DuckdbResult result, ulong col, ulong row)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbPrepare(IntPtr connection, string query, IntPtr outPreparedStatement)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbNparams(IntPtr reparedStatementRef, ulong nparamsOut)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindBoolean(IntPtr reparedStatementRef, ulong paramIdx, bool val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindInt8(IntPtr reparedStatementRef, ulong paramIdx, byte val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindInt16(IntPtr reparedStatementRef, ulong paramIdx, short val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindInt32(IntPtr reparedStatementRef, ulong paramIdx, int val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindInt64(IntPtr reparedStatementRef, ulong paramIdx, long val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindFloat(IntPtr reparedStatementRef, ulong paramIdx, float val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindDouble(IntPtr reparedStatementRef, ulong paramIdx, double val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindVarchar(IntPtr reparedStatementRef, ulong paramIdx, string val)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbBindNull(IntPtr reparedStatementRef, ulong paramIdx)
        {
            throw new NotImplementedException();
        }

        public override DuckdbState DuckdbExecutePrepared(IntPtr reparedStatementRef, ref DuckdbResult outResult)
        {
            throw new NotImplementedException();
        }

        public override void DuckdbDestroyPrepare(IntPtr reparedStatementRef)
        {
            throw new NotImplementedException();
        }
    }
}