using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.ObjectiveC.Foundation
{
    public unsafe struct NSInvocation : IId
    {
        public static readonly Class Class = new Class("NSInvocation");

        private Id _self;

        public NSInvocation(Id self)
        {
            _self = self;
        }

        public static AutoreleasedReference<NSInvocation> InvocationWith(Id target, Selector selector)
        {
            Id invocation = Runtime.objc_msgSend(Class, "invocationWithMethodSignature:", NSMethodSignature.SignatureWith(target, selector));
            Runtime.objc_msgSend(invocation, "setTarget:", target);
            Runtime.objc_msgSend(invocation, "setSelector:", selector.RawPtr);
            return new AutoreleasedReference<NSInvocation>(new NSInvocation(invocation));
        }

        public T GetReturnValue<T>() where T : struct
        {
            T retValue = default;
            Runtime.objc_msgSend(_self, "getReturnValue:", (IntPtr) UnsafeUtility.AddressOf(ref retValue));
            return retValue;
        }

        public void Invoke()
        {
            ProtectedInvoke();
        }
        public T Invoke<T>() where T : struct
        {
            ProtectedInvoke();
            return GetReturnValue<T>();
        }

        public void Invoke(params ValueType[] args)
        {
            using (DisposablePinnedObjectList pin = new DisposablePinnedObjectList(args))
            {
                for (int i = 0; i < pin.Count; i++)
                {
                    Runtime.objc_msgSend(_self, "setArgument:atIndex:", pin[i], 2 + i);
                }
                ProtectedInvoke();
            }
        }
        public T Invoke<T>(params ValueType[] args) where T : struct
        {
            Invoke(args);
            return GetReturnValue<T>();
        }

        private void ProtectedInvoke()
        {
            Id exception = ObjectiveCNative.Gilzoide_ObjectiveC_NSInvocationProtectedInvoke(this);
            if (!exception.IsNil)
            {
                string name = exception.Get<NSString>("name").ToString();
                string reason = exception.Get<NSString>("reason").ToString();
                NSDictionary userInfo = exception.Get<NSDictionary>("userInfo");
                throw new ObjectiveCException(name, reason, userInfo);
            }
        }

        public Id AsId => _self;

        public override string ToString()
        {
            return _self.ToString();
        }

        public static explicit operator NSInvocation(Id obj)
        {
            return new NSInvocation(obj);
        }
        public static implicit operator Id(NSInvocation invocation)
        {
            return invocation._self;
        }
    }
}
