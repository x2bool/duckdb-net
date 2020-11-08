using System;
using System.Runtime.InteropServices;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_hugeint</unmanaged>
    /// <unmanaged-short>duckdb_hugeint</unmanaged-short>
    [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Unicode)]
    internal struct DuckdbHugeInteger
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>lower</unmanaged>
        /// <unmanaged-short>lower</unmanaged-short>
        public UInt64 Lower;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>upper</unmanaged>
        /// <unmanaged-short>upper</unmanaged-short>
        public Int64 Upper;
    }
}