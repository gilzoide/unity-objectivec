using System;

namespace Gilzoide.ObjectiveC
{
    public class ObjectiveCException : Exception
    {
        public Id UserInfo { get; private set; } = Id.Nil;

        public ObjectiveCException(string message) : base(message)
        {
        }

        public ObjectiveCException(string name, string reason, Id userInfo) : base($"{name}: {reason}")
        {
            UserInfo = userInfo;
        }
    }
}
