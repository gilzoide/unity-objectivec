#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System;

namespace Gilzoide.ObjectiveC
{
    public struct Method
    {
        public IntPtr RawPtr;

        public Selector Selector => Runtime.method_getName(this);
        public string Name => Selector.ToString();
        public IntPtr Implementation => Runtime.method_getImplementation(this);
        public string TypeEncoding => Runtime.method_getTypeEncoding(this).ToString();
        public uint NumberOfArguments => Runtime.method_getNumberOfArguments(this);
        public unsafe MethodDescription* Description => Runtime.method_getDescription(this);
        
        public string GetReturnType()
        {
            using (AutoFreeCString str = Runtime.method_copyReturnType(this))
            {
                return str.ToString();
            }
        }

        public string GetArgumentType(uint index)
        {
            using (AutoFreeCString str = Runtime.method_copyArgumentType(this, index))
            {
                return str.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
#endif