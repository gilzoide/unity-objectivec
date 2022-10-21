using System;

namespace Gilzoide.ObjectiveC
{
    public struct Class : IId
    {
        public IntPtr RawPtr;

        public string Name => Runtime.class_getName(this).ToString();
        public bool IsMetaClass => Runtime.class_isMetaClass(this);
        public Class MetaClass => AsId.Class;
        public Class Superclass => Runtime.class_getSuperclass(this);
        public int Version
        {
            get => Runtime.class_getVersion(this);
            set => Runtime.class_setVersion(this, value);
        } 
        public uint InstanceSize => (uint) Runtime.class_getInstanceSize(this);
        public unsafe byte* IvarLayout => Runtime.class_getIvarLayout(this);
        public unsafe byte* WeakIvarLayout => Runtime.class_getWeakIvarLayout(this);
        public string ImageName => Runtime.class_getImageName(this).ToString();

        public Class(IntPtr rawPtr)
        {
            RawPtr = rawPtr;
        }

        public Class(string name) : this(Runtime.objc_getClass(name).RawPtr)
        {
        }

        public Ivar GetInstanceVariable(string name)
        {
            return Runtime.class_getInstanceVariable(this, name);
        }

        public Ivar GetClassVariable(string name)
        {
            return Runtime.class_getClassVariable(this, name);
        }

        public Ivar[] CopyIvarList()
        {
            return Runtime.class_copyIvarList(this);
        }

        public Method GetInstanceMethod(Selector selector)
        {
            return Runtime.class_getInstanceMethod(this, selector);
        }

        public Method GetClassMethod(Selector selector)
        {
            return Runtime.class_getClassMethod(this, selector);
        }

        public IntPtr GetMethodImplementation(Selector selector)
        {
            return Runtime.class_getMethodImplementation(this, selector);
        }

        public bool RespondsToSelector(Selector selector)
        {
            return Runtime.class_respondsToSelector(MetaClass, selector);
        }

        public bool InstancesRespondToSelector(Selector selector)
        {
            return Runtime.class_respondsToSelector(this, selector);
        }

        public Method[] CopyMethodList()
        {
            return Runtime.class_copyMethodList(this);
        }

        public bool ConformsToProtocol(Protocol protocol)
        {
            return Runtime.class_conformsToProtocol(this, protocol);
        }

        public Protocol[] CopyProtocolList()
        {
            return Runtime.class_copyProtocolList(this);
        }

        public Property GetProperty(string name)
        {
            return Runtime.class_getProperty(this, name);
        }

        public Property[] CopyPropertyList()
        {
            return Runtime.class_copyPropertyList(this);
        }
        
        public override string ToString()
        {
            return Name;
        }

        #region Creating instances

        public StrongReference Alloc(Selector initSelector)
        {
            return Runtime.objc_msgSend(this, "alloc").Call<StrongReference>(initSelector);
        }

        public StrongReference Alloc(Selector initSelector, params ValueType[] args)
        {
            return Runtime.objc_msgSend(this, "alloc").Call<StrongReference>(initSelector, args);
        }

        public TId Alloc<TId>(Selector initSelector) where TId : struct, IId
        {
            return Runtime.objc_msgSend(this, "alloc").Call<TId>(initSelector);
        }

        public TId Alloc<TId>(Selector initSelector, params ValueType[] args) where TId : struct, IId
        {
            return Runtime.objc_msgSend(this, "alloc").Call<TId>(initSelector, args);
        }

        #endregion

        public Id AsId => new Id(RawPtr);

        public static implicit operator Id(Class c)
        {
            return c.AsId;
        }
    }
}