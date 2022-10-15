#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System;

namespace Gilzoide.ObjectiveC
{
    public struct Protocol
    {
        public IntPtr RawPtr;

        public string Name => Runtime.protocol_getName(this).ToString();

        public Protocol(IntPtr rawPtr)
        {
            RawPtr = rawPtr;
        }

        public Protocol(string name) : this(Runtime.objc_getProtocol(name).RawPtr)
        {
        }

        public MethodDescription GetMethodDescription(Selector aSel, bool isRequiredMethod, bool isInstanceMethod)
        {
            return Runtime.protocol_getMethodDescription(this, aSel, isRequiredMethod, isInstanceMethod);
        }

        public MethodDescription[] CopyMethodDescriptionList(bool isRequiredMethod, bool isInstanceMethod)
        {
            return Runtime.protocol_copyMethodDescriptionList(this, isRequiredMethod, isInstanceMethod);
        }

        public Property GetProperty(string name, bool isRequiredProperty, bool isInstanceProperty)
        {
            return Runtime.protocol_getProperty(this, name, isRequiredProperty, isInstanceProperty);
        }

        public Property[] CopyPropertyList()
        {
            return Runtime.protocol_copyPropertyList(this);
        }

        public Property[] CopyPropertyList(bool isRequiredProperty, bool isInstanceProperty)
        {
            return Runtime.protocol_copyPropertyList2(this, isRequiredProperty, isInstanceProperty);
        }

        public Protocol[] CopyProtocolList()
        {
            return Runtime.protocol_copyProtocolList(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
#endif