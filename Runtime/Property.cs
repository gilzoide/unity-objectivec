using System;

namespace Gilzoide.ObjectiveC
{
    public struct Property
    {
        public IntPtr RawPtr;

        public string Name => Runtime.property_getName(this).ToString();
        public string Attributes => Runtime.property_getAttributes(this).ToString();

        public PropertyAttribute[] CopyAttributeList()
        {
            return Runtime.property_copyAttributeList(this);
        }

        public string CopyAttributeValue(string attributeName)
        {
            using (AutoFreeCString str = Runtime.property_copyAttributeValue(this, attributeName))
            {
                return str.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}