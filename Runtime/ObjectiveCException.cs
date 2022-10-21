using System;
using Gilzoide.ObjectiveC.Foundation;

namespace Gilzoide.ObjectiveC
{
    public class ObjectiveCException : Exception
    {
        public NSDictionary UserInfo { get; private set; }

        public ObjectiveCException(string message) : base(message)
        {
        }

        public ObjectiveCException(string name, string reason, NSDictionary userInfo) : base($"{name}: {reason}")
        {
            UserInfo = userInfo;
        }
    }
}
