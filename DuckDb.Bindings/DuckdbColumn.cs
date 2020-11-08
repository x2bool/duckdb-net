using System;
using System.Runtime.InteropServices;
using DuckDb.Bindings.Platforms;

namespace DuckDb.Bindings
{
    /// <summary>
    /// No documentation.
    /// </summary>
    /// <unmanaged>duckdb_column</unmanaged>
    /// <unmanaged-short>duckdb_column</unmanaged-short>
    internal struct DuckdbColumn
    {
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>data</unmanaged>
        /// <unmanaged-short>data</unmanaged-short>
        public IntPtr Data;
        
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>nullmask</unmanaged>
        /// <unmanaged-short>nullmask</unmanaged-short>
        public bool Nullmask
        {
            get => IntPtr.Zero != _Nullmask;
            set => _Nullmask = (IntPtr)(value ? 1 : 0);
        }

        internal IntPtr _Nullmask;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>type</unmanaged>
        /// <unmanaged-short>type</unmanaged-short>
        public DuckdbType Type;
        /// <summary>
        /// No documentation.
        /// </summary>
        /// <unmanaged>name</unmanaged>
        /// <unmanaged-short>name</unmanaged-short>
        public String Name;
        
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Unicode)]
        internal struct __Native
        {
            public IntPtr Data;
            public IntPtr Nullmask;
            public DuckdbType Type;
            public IntPtr Name;
        }

        internal void __MarshalFree(ref __Native @ref)
        {
            Marshal.FreeHGlobal(@ref.Name);
        }

        internal void __MarshalFrom(ref __Native @ref)
        {
            Data = @ref.Data;
            _Nullmask = @ref.Nullmask;
            Type = @ref.Type;
            Name = Encoder.NativeUtf8ToManagedString(@ref.Name);
        }

        internal void __MarshalTo(ref __Native @ref)
        {
            @ref.Data = Data;
            @ref.Nullmask = _Nullmask;
            @ref.Type = Type;
            @ref.Name = Encoder.ManagedStringToNativeUtf8(Name);
        }
    }
}