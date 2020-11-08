using System;
using System.Runtime.InteropServices;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_interval</unmanaged>
    /// <unmanaged-short>duckdb_interval</unmanaged-short>
    [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Unicode)]
    internal struct DuckdbInterval
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>months</unmanaged>
        /// <unmanaged-short>months</unmanaged-short>
        public Int32 Months;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>days</unmanaged>
        /// <unmanaged-short>days</unmanaged-short>
        public Int32 Days;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>msecs</unmanaged>
        /// <unmanaged-short>msecs</unmanaged-short>
        public Int64 Msecs;
    }
}