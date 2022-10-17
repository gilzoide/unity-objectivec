using System.Runtime.InteropServices;

namespace Gilzoide.ObjectiveC.Foundation
{
    public struct NSArray : IConvertibleToId
    {
        public static readonly Class Class = new Class("NSArray");

        [DllImport("__Internal", EntryPoint = "objc_msgSend")]
        public static extern NSArray objc_msgSend_idp_ulong(Id obj, Selector selector, Id[] objectArray, ulong length);

        private Id _self;

        public NSArray(Id self)
        {
            _self = self;
        }

        public static StrongReference<NSArray> Alloc(params Id[] objects)
        {
            Id newArray = Runtime.objc_msgSend(Class, "alloc");
            return new StrongReference<NSArray>(objc_msgSend_idp_ulong(newArray, "initWithObjects:count:", objects, (ulong) objects.Length));
        }

        public static AutoreleasedReference<NSArray> ArrayWith(NSArray array)
        {
            return new AutoreleasedReference<NSArray>(new NSArray(Runtime.objc_msgSend(Class, "arrayWithArray:", array)));
        }
        public static AutoreleasedReference<NSArray> ArrayWith(params Id[] objects)
        {
            return new AutoreleasedReference<NSArray>(objc_msgSend_idp_ulong(Class, "arrayWithObjects:count:", objects, (ulong) objects.Length));
        }

        public Id ToId()
        {
            return _self;
        }

        public override string ToString()
        {
            return _self.ToString();
        }

        public static implicit operator Id(NSArray arr)
        {
            return arr._self;
        }
    }
}
