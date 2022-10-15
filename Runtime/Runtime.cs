using System;
using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC
{
    public static unsafe class Runtime
    {
        [DllImport("__Internal")]
        public extern static void free(IntPtr ptr);

        #region Gettings classes

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Class objc_getClass(string name);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Class objc_getMetaClass(string name);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Class objc_lookUpClass(string name);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Class objc_getRequiredClass(string name);
    
        [DllImport("__Internal")]
        public extern static int objc_getClassList([In, Out] Class[] buffer, int bufferCount);

        [DllImport("__Internal")]
        public extern static AutoFreePointer<Class> objc_copyClassList(out uint outCount);

        public static Class[] objc_copyClassList()
        {
            using (AutoFreePointer<Class> list = objc_copyClassList(out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }

        #endregion
    
        #region Working with Classes

        [DllImport("__Internal")]
        public extern static CString class_getName(Class cls);
    
        [DllImport("__Internal")]
        public extern static bool class_isMetaClass(Class cls);
    
        [DllImport("__Internal")]
        public extern static Class class_getSuperclass(Class cls);
    
        [DllImport("__Internal")]
        public extern static int class_getVersion(Class cls);
    
        [DllImport("__Internal")]
        public extern static void class_setVersion(Class cls, int version);
    
        [DllImport("__Internal")]
        public extern static UIntPtr class_getInstanceSize(Class cls);

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Ivar class_getInstanceVariable(Class cls, string name);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Ivar class_getClassVariable(Class cls, string name);
    
        [DllImport("__Internal")]
        public extern static AutoFreePointer<Ivar> class_copyIvarList(Class cls, out uint outCount);

        public static Ivar[] class_copyIvarList(Class cls)
        {
            using (AutoFreePointer<Ivar> list = class_copyIvarList(cls, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal")]
        public extern static Method class_getInstanceMethod(Class cls, Selector name);
    
        [DllImport("__Internal")]
        public extern static Method class_getClassMethod(Class cls, Selector name);
    
        [DllImport("__Internal")]
        public extern static IntPtr class_getMethodImplementation(Class cls, Selector name);
    
        [DllImport("__Internal"), OBJC_ARM64_UNAVAILABLE]
        public extern static IntPtr class_getMethodImplementation_stret(Class cls, Selector name);

        [DllImport("__Internal")]
        public extern static bool class_respondsToSelector(Class cls, Selector sel);
    
        [DllImport("__Internal")]
        public extern static AutoFreePointer<Method> class_copyMethodList(Class cls, out uint outCount);

        public static Method[] class_copyMethodList(Class cls)
        {
            using (AutoFreePointer<Method> list = class_copyMethodList(cls, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal")]
        public extern static bool class_conformsToProtocol(Class cls, Protocol protocol);
        
        [DllImport("__Internal")]
        public extern static AutoFreePointer<Protocol> class_copyProtocolList(Class cls, out uint outCount);

        public static Protocol[] class_copyProtocolList(Class cls)
        {
            using (AutoFreePointer<Protocol> list = class_copyProtocolList(cls, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Property class_getProperty(Class cls, string name);
    
        [DllImport("__Internal")]
        public extern static AutoFreePointer<Property> class_copyPropertyList(Class cls, out uint outCount);

        public static Property[] class_copyPropertyList(Class cls)
        {
            using (AutoFreePointer<Property> list = class_copyPropertyList(cls, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal")]
        public extern static byte* class_getIvarLayout(Class cls);
    
        [DllImport("__Internal")]
        public extern static byte* class_getWeakIvarLayout(Class cls);

        #endregion

        #region Creating Classes

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Class objc_allocateClassPair(Class superclass, string name, UIntPtr extraBytes);
    
        [DllImport("__Internal")]
        public extern static void objc_registerClassPair(Class cls);

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Class objc_duplicateClass(Class original, string name, UIntPtr extraBytes);

        [DllImport("__Internal")]
        public extern static void objc_disposeClassPair(Class cls);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static bool class_addMethod(Class cls, Selector name, IntPtr imp, string types);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static IntPtr class_replaceMethod(Class cls, Selector name, IntPtr imp, string types);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static bool class_addIvar(Class cls, string name, UIntPtr size, byte alignment, string types);
    
        [DllImport("__Internal")]
        public extern static bool class_addProtocol(Class cls, Protocol protocol);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static bool class_addProperty(Class cls, string name, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PropertyAttribute[] attributes, uint attributeCount);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static void class_replaceProperty(Class cls, string name, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PropertyAttribute[] attributes, uint attributeCount);
    
        [DllImport("__Internal")]
        public extern static void class_setIvarLayout(Class cls, byte* layout);

        [DllImport("__Internal")]
        public extern static void class_setWeakIvarLayout(Class cls, byte* layout);

        #endregion

        #region Instantiating Classes
    
        [DllImport("__Internal")]
        public extern static Id class_createInstance(Class cls, UIntPtr extraBytes);
    
        [DllImport("__Internal")]
        public extern static Id objc_constructInstance(Class cls, IntPtr bytes);
    
        [DllImport("__Internal")]
        public extern static void objc_destructInstance(Id obj);

        #endregion
    
        #region Working with Objects

        [DllImport("__Internal")]
        public extern static Id object_copy(Id obj, UIntPtr size);

        [DllImport("__Internal")]
        public extern static void object_dispose(Id obj);
    
        [DllImport("__Internal")]
        public extern static Class object_getClass(Id obj);
    
        [DllImport("__Internal")]
        public extern static Class object_setClass(Id obj, Class cls);
    
        [DllImport("__Internal")]
        public extern static bool object_isClass(Id obj);
    
        [DllImport("__Internal")]
        public extern static Id object_getIvar(Id obj, Ivar ivar);
    
        [DllImport("__Internal")]
        public extern static void object_setIvar(Id obj, Ivar ivar, Id value);
    
        [DllImport("__Internal")]
        public extern static void object_setIvarWithStrongDefault(Id obj, Ivar ivar, Id value);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Ivar object_setInstanceVariable(Id obj, string name, IntPtr value);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Ivar object_setInstanceVariableWithStrongDefault(Id obj, string name, IntPtr value);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Ivar object_getInstanceVariable(Id obj, string name, out IntPtr outValue);

        #endregion

        #region Working with Methods

        [DllImport("__Internal")]
        public extern static Selector method_getName(Method m);

        [DllImport("__Internal")]
        public extern static IntPtr method_getImplementation(Method m);

        [DllImport("__Internal")]
        public extern static CString method_getTypeEncoding(Method m);

        [DllImport("__Internal")]
        public extern static uint method_getNumberOfArguments(Method m);
    
        [DllImport("__Internal")]
        public extern static AutoFreeCString method_copyReturnType(Method m);
    
        [DllImport("__Internal")]
        public extern static AutoFreeCString method_copyArgumentType(Method m, uint index);
    
        [DllImport("__Internal")]
        public extern static void method_getReturnType(Method m, [In, Out] byte[] dst, UIntPtr dst_len);
    
        [DllImport("__Internal")]
        public extern static void method_getArgumentType(Method m, uint index, [In, Out] byte[] dst, UIntPtr dst_len);

        [DllImport("__Internal")]
        public extern static MethodDescription* method_getDescription(Method m);

        [DllImport("__Internal")]
        public extern static IntPtr method_setImplementation(Method m, IntPtr imp);
        
        [DllImport("__Internal")]
        public extern static void method_exchangeImplementations(Method m1, Method m2);

        #endregion

        #region Working with Instance Variables
        
        [DllImport("__Internal")]
        public extern static CString ivar_getName(Ivar v);
    
        [DllImport("__Internal")]
        public extern static CString ivar_getTypeEncoding(Ivar v);
    
        [DllImport("__Internal")]
        public extern static IntPtr ivar_getOffset(Ivar v);

        #endregion
    
        #region Working with Properties

        [DllImport("__Internal")]
        public extern static CString property_getName(Property property);
    

        [DllImport("__Internal")]
        public extern static CString property_getAttributes(Property property);
    

        [DllImport("__Internal")]
        public extern static AutoFreePointer<PropertyAttribute> property_copyAttributeList(Property property, out uint outCount);

        public static PropertyAttribute[] property_copyAttributeList(Property property)
        {
            using (AutoFreePointer<PropertyAttribute> list = property_copyAttributeList(property, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static AutoFreeCString property_copyAttributeValue(Property property, string attributeName);
    
        #endregion

        #region Working with Protocols
        
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Protocol objc_getProtocol(string name);

        [DllImport("__Internal")]
        public extern static AutoFreePointer<Protocol> objc_copyProtocolList(out uint outCount);

        public static Protocol[] objc_copyProtocolList()
        {
            using (AutoFreePointer<Protocol> list = objc_copyProtocolList(out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal")]
        public extern static bool protocol_conformsToProtocol(Protocol proto, Protocol other);
    
        [DllImport("__Internal")]
        public extern static bool protocol_isEqual(Protocol proto, Protocol other);
    
        [DllImport("__Internal")]
        public extern static CString protocol_getName(Protocol proto);

        [DllImport("__Internal")]
        public extern static MethodDescription protocol_getMethodDescription(Protocol proto, Selector aSel, bool isRequiredMethod, bool isInstanceMethod);

        [DllImport("__Internal")]
        public extern static AutoFreePointer<MethodDescription> protocol_copyMethodDescriptionList(Protocol proto, bool isRequiredMethod, bool isInstanceMethod, out uint outCount);
    
        public static MethodDescription[] protocol_copyMethodDescriptionList(Protocol proto, bool isRequiredMethod, bool isInstanceMethod)
        {
            using (AutoFreePointer<MethodDescription> list = protocol_copyMethodDescriptionList(proto, isRequiredMethod, isInstanceMethod, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Property protocol_getProperty(Protocol proto, string name, bool isRequiredProperty, bool isInstanceProperty);

        [DllImport("__Internal")]
        public extern static AutoFreePointer<Property> protocol_copyPropertyList(Protocol proto, out uint outCount);
    
        public static Property[] protocol_copyPropertyList(Protocol proto)
        {
            using (AutoFreePointer<Property> list = protocol_copyPropertyList(proto, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }

        [DllImport("__Internal")]
        public extern static AutoFreePointer<Property> protocol_copyPropertyList2(Protocol proto, out uint outCount, bool isRequiredProperty, bool isInstanceProperty);

        public static Property[] protocol_copyPropertyList2(Protocol proto, bool isRequiredProperty, bool isInstanceProperty)
        {
            using (AutoFreePointer<Property> list = protocol_copyPropertyList2(proto, out uint count, isRequiredProperty, isInstanceProperty))
            {
                return list.ToArrayOfSize(count);
            }
        }
    
        [DllImport("__Internal")]
        public extern static AutoFreePointer<Protocol> protocol_copyProtocolList(Protocol proto, out uint outCount);

        public static Protocol[] protocol_copyProtocolList(Protocol proto)
        {
            using (AutoFreePointer<Protocol> list = protocol_copyProtocolList(proto, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Protocol objc_allocateProtocol(string name);
    
        [DllImport("__Internal")]
        public extern static void objc_registerProtocol(Protocol proto);

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static void protocol_addMethodDescription(Protocol proto, Selector name, string types, bool isRequiredMethod, bool isInstanceMethod);
    
        [DllImport("__Internal")]
        public extern static void protocol_addProtocol(Protocol proto, Protocol addition);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static void protocol_addProperty(Protocol proto, string name, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PropertyAttribute[] attributes, uint attributeCount, bool isRequiredProperty, bool isInstanceProperty);

        #endregion

        #region Working with Libraries

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static AutoFreePointer<CString> objc_copyImageNames(out uint outCount);
    
        public static CString[] objc_copyImageNames()
        {
            using (AutoFreePointer<CString> list = objc_copyImageNames(out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }

        [DllImport("__Internal")]
        public extern static CString class_getImageName(Class cls);
    

        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static AutoFreePointer<CString> objc_copyClassNamesForImage(string image, out uint outCount);

        public static CString[] objc_copyClassNamesForImage(string image)
        {
            using (AutoFreePointer<CString> list = objc_copyClassNamesForImage(image, out uint count))
            {
                return list.ToArrayOfSize(count);
            }
        }

        #endregion
    
        #region Working with Selectors
        
        [DllImport("__Internal")]
        public extern static CString sel_getName(Selector sel);
    
        [DllImport("__Internal", CharSet = CharSet.Ansi)]
        public extern static Selector sel_registerName(string name);
    
        #endregion

        #region Associative References

        [DllImport("__Internal")]
        public extern static void objc_setAssociatedObject(Id obj, IntPtr key, Id value, AssociationPolicy policy);

        [DllImport("__Internal")]
        public extern static Id objc_getAssociatedObject(Id obj, IntPtr key);

        [DllImport("__Internal")]
        public extern static void objc_removeAssociatedObjects(Id obj);

        #endregion

        #region Messaging primitives
        
        [DllImport("__Internal")]
        public extern static Id objc_msgSend(Id obj, Selector selector);

        [DllImport("__Internal")]
        public extern static Id objc_msgSend(Id obj, Selector selector, Id arg1);

        [DllImport("__Internal")]
        public extern static Id objc_msgSend(Id obj, Selector selector, Id arg1, Id arg2);

        [DllImport("__Internal")]
        public extern static Id objc_msgSendSuper(ref Super super, Selector selector);

        #endregion

        #region Memory management

        [DllImport("__Internal")]
        public extern static StrongReference objc_retain(Id obj);

        [DllImport("__Internal")]
        public extern static void objc_release(Id obj);

        [DllImport("__Internal")]
        public extern static AutoreleasedReference objc_autorelease(Id obj);

        [DllImport("__Internal")]
        public extern static AutoreleasedReference objc_retainAutorelease(Id value);

        [DllImport("__Internal")]
        public extern static AutoreleasePool.Context objc_autoreleasePoolPush();

        [DllImport("__Internal")]
        public extern static void objc_autoreleasePoolPop(AutoreleasePool.Context context);

        [DllImport("__Internal")]
        public extern static void objc_copyWeak(ref Id dest, ref Id src);

        [DllImport("__Internal")]
        public extern static void objc_destroyWeak(ref Id obj);

        [DllImport("__Internal")]
        public extern static Id objc_initWeak(ref Id obj, Id value);

        [DllImport("__Internal")]
        public extern static Id objc_loadWeak(ref Id obj);

        [DllImport("__Internal")]
        public extern static Id objc_loadWeakRetained(ref Id obj);

        [DllImport("__Internal")]
        public extern static void objc_moveWeak(ref Id dest, ref Id src);

        [DllImport("__Internal")]
        public extern static Id objc_retainBlock(Id value);

        [DllImport("__Internal")]
        public extern static void objc_storeStrong(ref StrongReference<Id> obj, Id value);

        [DllImport("__Internal")]
        public extern static Id objc_storeWeak(ref Id obj, Id value);

        #endregion
    }
}