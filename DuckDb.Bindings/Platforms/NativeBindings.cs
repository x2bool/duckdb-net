using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("DuckDb")]
[assembly: InternalsVisibleTo("DuckDb.Data")]
[assembly: InternalsVisibleTo("DuckDb.Tests")]

namespace DuckDb.Bindings.Platforms
{
    internal abstract class NativeBindings
    {
        public static NativeBindings AutoDetected
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    //return new WindowsBindings();
                }
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    return new MacosBindings();
                }
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    //return new LinuxBindings();
                }

                return null;
            }
        }
        
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="athRef">No documentation.</param>
        /// <param name="outDatabase">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_open([In] const char* path,[In] void** out_database)</unmanaged>
        /// <unmanaged-short>duckdb_open</unmanaged-short>
        public abstract DuckdbState DuckdbOpen(String athRef, out IntPtr outDatabase);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="database">No documentation.</param>
        /// <unmanaged>void duckdb_close([In] void** database)</unmanaged>
        /// <unmanaged-short>duckdb_close</unmanaged-short>
        public abstract void DuckdbClose(ref IntPtr database);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="database">No documentation.</param>
        /// <param name="outConnection">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_connect([In] void* database,[In] void** out_connection)</unmanaged>
        /// <unmanaged-short>duckdb_connect</unmanaged-short>
        public abstract DuckdbState DuckdbConnect(IntPtr database, out IntPtr outConnection);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="connection">No documentation.</param>
        /// <unmanaged>void duckdb_disconnect([In] void** connection)</unmanaged>
        /// <unmanaged-short>duckdb_disconnect</unmanaged-short>
        public abstract void DuckdbDisconnect(ref IntPtr connection);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="connection">No documentation.</param>
        /// <param name="query">No documentation.</param>
        /// <param name="outResult">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_query([In] void* connection,[In] const char* query,[In] duckdb_result* out_result)</unmanaged>
        /// <unmanaged-short>duckdb_query</unmanaged-short>
        public abstract DuckdbState DuckdbQuery(IntPtr connection, String query, out DuckdbResult outResult);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <unmanaged>void duckdb_destroy_result([In] duckdb_result* result)</unmanaged>
        /// <unmanaged-short>duckdb_destroy_result</unmanaged-short>
        public abstract void DuckdbDestroyResult(ref DuckdbResult result);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>const char* duckdb_column_name([In] duckdb_result* result,[In] unsigned longlong col)</unmanaged>
        /// <unmanaged-short>duckdb_column_name</unmanaged-short>
        public abstract String DuckdbColumnName(ref DuckdbResult result, UInt64 col);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>bool duckdb_value_boolean([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_boolean</unmanaged-short>
        public abstract Boolean DuckdbValueBoolean(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>char duckdb_value_int8([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_int8</unmanaged-short>
        public abstract Byte DuckdbValueInt8(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>short duckdb_value_int16([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_int16</unmanaged-short>
        public abstract Int16 DuckdbValueInt16(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>int duckdb_value_int32([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_int32</unmanaged-short>
        public abstract Int32 DuckdbValueInt32(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>longlong duckdb_value_int64([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_int64</unmanaged-short>
        public abstract Int64 DuckdbValueInt64(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>float duckdb_value_float([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_float</unmanaged-short>
        public abstract Single DuckdbValueFloat(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>double duckdb_value_double([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_double</unmanaged-short>
        public abstract Double DuckdbValueDouble(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="result">No documentation.</param>
        /// <param name="col">No documentation.</param>
        /// <param name="row">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>char* duckdb_value_varchar([In] duckdb_result* result,[In] unsigned longlong col,[In] unsigned longlong row)</unmanaged>
        /// <unmanaged-short>duckdb_value_varchar</unmanaged-short>
        public abstract String DuckdbValueVarchar(ref DuckdbResult result, UInt64 col, UInt64 row);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="connection">No documentation.</param>
        /// <param name="query">No documentation.</param>
        /// <param name="outPreparedStatement">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_prepare([In] void* connection,[In] const char* query,[In] void** out_prepared_statement)</unmanaged>
        /// <unmanaged-short>duckdb_prepare</unmanaged-short>
        public abstract DuckdbState DuckdbPrepare(IntPtr connection, String query, IntPtr outPreparedStatement);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="nparamsOut">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_nparams([In] void* prepared_statement,[In] unsigned longlong* nparams_out)</unmanaged>
        /// <unmanaged-short>duckdb_nparams</unmanaged-short>
        public abstract DuckdbState DuckdbNparams(IntPtr reparedStatementRef, UInt64 nparamsOut);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_boolean([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] bool val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_boolean</unmanaged-short>
        public abstract DuckdbState DuckdbBindBoolean(IntPtr reparedStatementRef, UInt64 paramIdx, Boolean val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_int8([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] char val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_int8</unmanaged-short>
        public abstract DuckdbState DuckdbBindInt8(IntPtr reparedStatementRef, UInt64 paramIdx, Byte val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_int16([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] short val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_int16</unmanaged-short>
        public abstract DuckdbState DuckdbBindInt16(IntPtr reparedStatementRef, UInt64 paramIdx, Int16 val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_int32([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] int val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_int32</unmanaged-short>
        public abstract DuckdbState DuckdbBindInt32(IntPtr reparedStatementRef, UInt64 paramIdx, Int32 val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_int64([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] longlong val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_int64</unmanaged-short>
        public abstract DuckdbState DuckdbBindInt64(IntPtr reparedStatementRef, UInt64 paramIdx, Int64 val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_float([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] float val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_float</unmanaged-short>
        public abstract DuckdbState DuckdbBindFloat(IntPtr reparedStatementRef, UInt64 paramIdx, Single val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_double([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] double val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_double</unmanaged-short>
        public abstract DuckdbState DuckdbBindDouble(IntPtr reparedStatementRef, UInt64 paramIdx, Double val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <param name="val">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_varchar([In] void* prepared_statement,[In] unsigned longlong param_idx,[In] const char* val)</unmanaged>
        /// <unmanaged-short>duckdb_bind_varchar</unmanaged-short>
        public abstract DuckdbState DuckdbBindVarchar(IntPtr reparedStatementRef, UInt64 paramIdx, String val);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="paramIdx">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_bind_null([In] void* prepared_statement,[In] unsigned longlong param_idx)</unmanaged>
        /// <unmanaged-short>duckdb_bind_null</unmanaged-short>
        public abstract DuckdbState DuckdbBindNull(IntPtr reparedStatementRef, UInt64 paramIdx);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <param name="outResult">No documentation.</param>
        /// <returns>No documentation.</returns>
        /// <unmanaged>duckdb_state duckdb_execute_prepared([In] void* prepared_statement,[In] duckdb_result* out_result)</unmanaged>
        /// <unmanaged-short>duckdb_execute_prepared</unmanaged-short>
        public abstract DuckdbState DuckdbExecutePrepared(IntPtr reparedStatementRef, ref DuckdbResult outResult);

        /// <summary>
        /// No documentation.
        /// </summary>
        /// <param name="reparedStatementRef">No documentation.</param>
        /// <unmanaged>void duckdb_destroy_prepare([In] void** prepared_statement)</unmanaged>
        /// <unmanaged-short>duckdb_destroy_prepare</unmanaged-short>
        public abstract void DuckdbDestroyPrepare(IntPtr reparedStatementRef);
    }
}