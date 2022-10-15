#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public struct CString
    {
        public IntPtr RawPtr;

        public override string ToString()
        {
            return Marshal.PtrToStringAnsi(RawPtr);
        }
    }
}
#endif