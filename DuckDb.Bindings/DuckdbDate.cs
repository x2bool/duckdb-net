using System;
using System.Runtime.InteropServices;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_date</unmanaged>
    /// <unmanaged-short>duckdb_date</unmanaged-short>
    [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Unicode)]
    internal struct DuckdbDate
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>year</unmanaged>
        /// <unmanaged-short>year</unmanaged-short>
        public Int32 Year;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>month</unmanaged>
        /// <unmanaged-short>month</unmanaged-short>
        public Byte Month;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>day</unmanaged>
        /// <unmanaged-short>day</unmanaged-short>
        public Byte Day;
    }
}