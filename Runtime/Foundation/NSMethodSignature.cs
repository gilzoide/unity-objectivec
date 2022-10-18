namespace Gilzoide.ObjectiveC
{
    public struct NSMethodSignature : IId
    {
        public static readonly Class Class = new Class("NSMethodSignature");

        private Id _self;

        public NSMethodSignature(Id self)
        {
            _self = self;
        }

        public static unsafe AutoreleasedReference<NSMethodSignature> SignatureWith(Id target, Selector selector)
        {
            Id signature = Runtime.objc_msgSend(target, "methodSignatureForSelector:", selector.RawPtr);
            if (signature.IsNil)
            {
                if (target.IsClass)
                {
                    throw new ObjectiveCException($"Unrecognized selector '{selector}' in class '{new Class(target.RawPtr)}'");    
                }
                else
                {
                    throw new ObjectiveCException($"Unrecognized selector '{selector}' in instance of class '{target.Class}'");
                }
            }
            return new AutoreleasedReference<NSMethodSignature>(new NSMethodSignature(signature));
        }

        public Id AsId => _self;

        public override string ToString()
        {
            return _self.ToString();
        }

        public static implicit operator Id(NSMethodSignature signature)
        {
            return signature._self;
        }
    }
}
