#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
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
            CString types = target.IsClass
                ? new Class(target.RawPtr).GetClassMethod(selector).Description->Types
                : target.Class.GetInstanceMethod(selector).Description->Types;
            Id signature = objc_msgSend_IntPtr(NSMethodSignature, Selector_signatureWithObjCTypes, types.RawPtr);
            Id invocation = objc_msgSend_IntPtr(NSInvocation, Selector_invocationWithMethodSignature, signature.RawPtr);
            objc_msgSend_IntPtr(invocation, Selector_setSelector, selector.RawPtr);
            return invocation;
        }

        public static Id Invoke(Id target, Selector selector)
        {
            Id invocation = GetMethodInvocation(target, selector);
            objc_msgSend_IntPtr(invocation, Selector_invokeWithTarget, target.RawPtr);
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
                objc_msgSend_IntPtr(invocation, Selector_invokeWithTarget, target.RawPtr);
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
    }
}
#endif