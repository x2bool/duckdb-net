using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DuckDb.Bindings.Platforms
{
    internal static class Encoder
    {
        public static unsafe IntPtr ManagedStringToNativeUtf8(string input)
        {
            if (input == null)
            {
                return IntPtr.Zero;
            }
            
            fixed (char* pInput = input)
            {
                var len = Encoding.UTF8.GetByteCount(pInput, input.Length);
                var pResult = (byte*)Marshal.AllocHGlobal(len + 1).ToPointer();
                Encoding.UTF8.GetBytes(pInput, input.Length, pResult, len);
                pResult[len] = 0;
                return (IntPtr)pResult;
            }
        }

        public static unsafe string NativeUtf8ToManagedString(IntPtr pStringUtf8)
        {
            if (pStringUtf8 == IntPtr.Zero)
            {
                return null;
            }
            
            return NativeUtf8ToManagedString((byte*)pStringUtf8);
        }

        private static unsafe string NativeUtf8ToManagedString(byte* pStringUtf8)
        {
            var len = 0;
            while (pStringUtf8[len] != 0) len++;
            return Encoding.UTF8.GetString(pStringUtf8, len);
        }
    }
}