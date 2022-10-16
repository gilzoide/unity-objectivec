using System;

namespace Gilzoide.ObjectiveC
{
    public struct Id : IConvertibleToId
    {
        public static readonly Id Nil = new Id { RawPtr = IntPtr.Zero };

        public IntPtr RawPtr;

        public Class Class => Runtime.object_getClass(this);
        public bool IsClass => Class.IsMetaClass;
        public bool IsNil => this == Nil;

        public Id(IntPtr rawPtr)
        {
            RawPtr = rawPtr;
        }

        public bool RespondsToSelector(Selector selector)
        {
            return Runtime.class_respondsToSelector(Class, selector);
        }

        #region Accessing properties

        public T Get<T>(string propertyName) where T : struct
        {
            Selector getSelector = propertyName;
            return Call<T>(getSelector);
        }

        public void Set<T>(string propertyName, T value) where T : struct
        {
            Selector setSelector = $"set{char.ToUpper(propertyName[0])}{propertyName.Substring(1)}:";
            Call(setSelector, value);
        }

        #endregion

        #region Call methods

        public void Call(Selector selector)
        {
            MethodInvocation.Invoke(this, selector);
        }
        public T Call<T>(Selector selector) where T : struct
        {
            return MethodInvocation.Invoke<T>(this, selector);
        }
        public void Call(Selector selector, params ValueType[] args)
        {
            MethodInvocation.Invoke(this, selector, args);
        }
        public T Call<T>(Selector selector, params ValueType[] args) where T : struct
        {
            return MethodInvocation.Invoke<T>(this, selector, args);
        }

        #endregion

        #region Memory management

        public StrongReference Retain()
        {
            return Runtime.objc_retain(this);
        }

        public void Release()
        {
            Runtime.objc_release(this);
        }

        public AutoreleasedReference Autorelease()
        {
            return Runtime.objc_autorelease(this);
        }

        public AutoreleasedReference RetainAutorelease()
        {
            return Runtime.objc_retainAutorelease(this);
        }

        #endregion

        #region Object overloads

        public override string ToString()
        {
            return Call<NSString>("description").ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Id other && this == other;
        }

        public override int GetHashCode()
        {
            return RawPtr.GetHashCode();
        }

        #endregion

        public Id ToId()
        {
            return this;
        }

        public static bool operator==(Id self, Id other)
        {
            return self.RawPtr == other.RawPtr;
        }

        public static bool operator!=(Id self, Id other)
        {
            return self.RawPtr != other.RawPtr;
        }
    }
}