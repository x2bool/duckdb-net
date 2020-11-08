using System.Runtime.InteropServices;
using DuckDb.Bindings.Platforms;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_result</unmanaged>
    /// <unmanaged-short>duckdb_result</unmanaged-short>
    internal struct DuckdbResult
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>column_count</unmanaged>
        /// <unmanaged-short>column_count</unmanaged-short>
        public System.UInt64 ColumnCount;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>row_count</unmanaged>
        /// <unmanaged-short>row_count</unmanaged-short>
        public System.UInt64 RowCount;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>columns</unmanaged>
        /// <unmanaged-short>columns</unmanaged-short>
        public System.IntPtr Columns;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>error_message</unmanaged>
        /// <unmanaged-short>error_message</unmanaged-short>
        public System.String ErrorMessage;
        
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Unicode)]
        internal struct __Native
        {
            public System.UInt64 ColumnCount;
            public System.UInt64 RowCount;
            public System.IntPtr Columns;
            public System.IntPtr ErrorMessage;
        }

        internal void __MarshalFree(ref __Native @ref)
        {
           Marshal.FreeHGlobal(@ref.ErrorMessage);
        }

        internal void __MarshalFrom(ref __Native @ref)
        {
            ColumnCount = @ref.ColumnCount;
            RowCount = @ref.RowCount;
            Columns = @ref.Columns;
            ErrorMessage = Encoder.NativeUtf8ToManagedString(@ref.ErrorMessage);
        }

        internal void __MarshalTo(ref __Native @ref)
        {
            @ref.ColumnCount = ColumnCount;
            @ref.RowCount = RowCount;
            @ref.Columns = Columns;
            @ref.ErrorMessage = Encoder.ManagedStringToNativeUtf8(ErrorMessage);
        }
    }
}