#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
namespace Gilzoide.ObjectiveC
{
    public struct Super
    {
        public Id Receiver;
        public Class SuperClass;
    }
}
#endif