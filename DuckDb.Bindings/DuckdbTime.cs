using System;
using System.Runtime.InteropServices;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_time</unmanaged>
    /// <unmanaged-short>duckdb_time</unmanaged-short>
    [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Unicode)]
    internal struct DuckdbTime
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>hour</unmanaged>
        /// <unmanaged-short>hour</unmanaged-short>
        public Byte Hour;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>min</unmanaged>
        /// <unmanaged-short>min</unmanaged-short>
        public Byte Min;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>sec</unmanaged>
        /// <unmanaged-short>sec</unmanaged-short>
        public Byte Sec;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>msec</unmanaged>
        /// <unmanaged-short>msec</unmanaged-short>
        public Int16 Msec;
    }
}