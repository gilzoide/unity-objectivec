using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.ObjectiveC
{
    public unsafe static class MethodInvocation
    {
        public static readonly Class NSMethodSignature = new Class("NSMethodSignature");
        public static readonly Class NSInvocation = new Class("NSInvocation");
        public static readonly Selector Selector_signatureWithObjCTypes = "signatureWithObjCTypes:";
        public static readonly Selector Selector_invocationWithMethodSignature = "invocationWithMethodSignature:";
        public static readonly Selector Selector_setSelector = "setSelector:";
        public static readonly Selector Selector_setTarget = "setTarget:";
        public static readonly Selector Selector_setArgument_atIndex = "setArgument:atIndex:";
        public static readonly Selector Selector_invokeWithTarget = "invokeWithTarget:";
        public static readonly Selector Selector_getReturnValue = "getReturnValue:";

        [DllImport("__Internal", EntryPoint = "objc_msgSend")]
        public static extern Id objc_msgSend_IntPtr(Id self, Selector _cmd, IntPtr arg1);

        [DllImport("__Internal", EntryPoint = "objc_msgSend")]
        public static extern Id objc_msgSend_IntPtr_Int(Id self, Selector _cmd, IntPtr arg1, int arg2);

        [DllImport("__Internal", EntryPoint = "objc_msgSend")]
        public static extern Id objc_msgSend_voidp(Id self, Selector _cmd, void* arg1);

        public static Id GetMethodInvocation(Id target, Selector selector)
        {
            Method method = target.IsClass
                ? new Class(target.RawPtr).GetClassMethod(selector)
                : target.Class.GetInstanceMethod(selector);
            if (method.IsNil)
            {
                if (target.IsClass)
                {
                    throw new ObjectiveCException($"Unrecognized selector '{selector}' sent to class '{new Class(target.RawPtr)}'");    
                }
                else
                {
                    throw new ObjectiveCException($"Unrecognized selector '{selector}' sent to instance of class '{target.Class}'");
                }
            }
            CString types = method.Description->Types;
            Id signature = objc_msgSend_IntPtr(NSMethodSignature, Selector_signatureWithObjCTypes, types.RawPtr);
            Id invocation = objc_msgSend_IntPtr(NSInvocation, Selector_invocationWithMethodSignature, signature.RawPtr);
            objc_msgSend_IntPtr(invocation, Selector_setTarget, target.RawPtr);
            objc_msgSend_IntPtr(invocation, Selector_setSelector, selector.RawPtr);
            return invocation;
        }

        public static Id Invoke(Id target, Selector selector)
        {
            Id invocation = GetMethodInvocation(target, selector);
            ProtectedInvoke(invocation);
            return invocation;
        }
        public static T Invoke<T>(Id target, Selector selector) where T : struct
        {
            Id invocation = Invoke(target, selector);
            T retValue = default;
            objc_msgSend_voidp(invocation, Selector_getReturnValue, UnsafeUtility.AddressOf(ref retValue));
            return retValue;
        }

        public static Id Invoke(Id target, Selector selector, params ValueType[] args)
        {
            Id invocation = GetMethodInvocation(target, selector);
            GCHandle* gcHandles = stackalloc GCHandle[args.Length];
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    GCHandle gcHandle = GCHandle.Alloc(args[i], GCHandleType.Pinned);
                    gcHandles[i] = gcHandle;
                    objc_msgSend_IntPtr_Int(invocation, Selector_setArgument_atIndex, gcHandle.AddrOfPinnedObject(), 2 + i);
                }
                ProtectedInvoke(invocation);
            }
            finally
            {
                for (int i = 0; i < args.Length; i++)
                {
                    gcHandles[i].Free();
                }
            }
            return invocation;
        }
        public static T Invoke<T>(Id target, Selector selector, params ValueType[] args) where T : struct
        {
            Id invocation = Invoke(target, selector, args);
            T retValue = default;
            objc_msgSend_voidp(invocation, Selector_getReturnValue, UnsafeUtility.AddressOf(ref retValue));
            return retValue;
        }

        private static void ProtectedInvoke(Id invocation)
        {
            Id exception = ObjectiveCNative.Gilzoide_ObjectiveC_NSInvocationProtectedInvoke(invocation);
            if (!exception.IsNil)
            {
                string name = exception.Get<NSString>("name").ToString();
                string reason = exception.Get<NSString>("reason").ToString();
                Id userInfo = exception.Get<Id>("userInfo");
                throw new ObjectiveCException(name, reason, userInfo);
            }
        }
    }
}