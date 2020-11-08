using System;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_state</unmanaged>
    /// <unmanaged-short>duckdb_state</unmanaged-short>
    internal enum DuckdbState : Int32
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>DuckDBSuccess</unmanaged>
        /// <unmanaged-short>DuckDBSuccess</unmanaged-short>
        DuckDBSuccess = unchecked ((Int32)(0)),
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>DuckDBError</unmanaged>
        /// <unmanaged-short>DuckDBError</unmanaged-short>
        DuckDBError = unchecked ((Int32)(1))}
}