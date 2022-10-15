#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
using System;

namespace Gilzoide.ObjectiveC
{
    public struct MethodDescription
    {
        public Selector Name;
        public CString Types;
    }
}
#endif