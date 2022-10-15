#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
namespace Gilzoide.ObjectiveC
{
    public struct PropertyAttribute
    {
        public CString Name;
        public CString Value;
    }
}
#endif