namespace Gilzoide.ObjectiveC.Foundation
{
    public struct NSNumber : IId
    {
        public static readonly Class Class = new Class("NSNumber");

        private Id _self;

        public bool BoolValue => _self.Get<bool>("boolValue");
        public char CharValue => _self.Get<char>("charValue");
        public double DoubleValue => _self.Get<double>("doubleValue");
        public float FloatValue => _self.Get<float>("floatValue");
        public int IntValue => _self.Get<int>("intValue");
        public long LongValue => _self.Get<long>("longValue");
        public short ShortValue => _self.Get<short>("shortValue");
        public uint UnsignedIntValue => _self.Get<uint>("unsignedIntValue");
        public ulong UnsignedLongValue => _self.Get<ulong>("unsignedLongValue");
        public ushort UnsignedShortValue => _self.Get<ushort>("unsignedShortValue");

        public NSNumber(Id self)
        {
            _self = self;
        }
        public static StrongReference<NSNumber> Alloc(bool value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithBool:", value)));
        }
        public static StrongReference<NSNumber> Alloc(char value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithChar:", value)));
        }
        public static StrongReference<NSNumber> Alloc(double value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithDouble:", value)));
        }
        public static StrongReference<NSNumber> Alloc(float value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithFloat:", value)));
        }
        public static StrongReference<NSNumber> Alloc(int value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithInt:", value)));
        }
        public static StrongReference<NSNumber> Alloc(long value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithLong:", value)));
        }
        public static StrongReference<NSNumber> Alloc(short value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithShort:", value)));
        }
        public static StrongReference<NSNumber> Alloc(uint value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedInt:", value)));
        }
        public static StrongReference<NSNumber> Alloc(ulong value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedLong:", value)));
        }
        public static StrongReference<NSNumber> Alloc(ushort value)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedShort:", value)));
        }

        public static AutoreleasedReference<NSNumber> NumberWith(bool value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithBool:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(char value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithChar:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(double value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithDouble:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(float value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithFloat:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(int value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithInt:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(long value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithLong:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(short value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithShort:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(uint value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithUnsignedInt:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(ulong value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithUnsignedLong:", value);
        }
        public static AutoreleasedReference<NSNumber> NumberWith(ushort value)
        {
            return Class.AsId.Call<AutoreleasedReference<NSNumber>>("numberWithUnsignedShort:", value);
        }

        public Id AsId => _self;

        public override string ToString()
        {
            return _self.ToString();
        }

        public static explicit operator NSNumber(bool value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(char value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(double value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(float value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(int value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(long value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(short value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(uint value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(ulong value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(ushort value)
        {
            return NSNumber.NumberWith(value);
        }
        public static explicit operator NSNumber(Id obj)
        {
            return new NSNumber(obj);
        }
        public static implicit operator Id(NSNumber n)
        {
            return n._self;
        }
    }
}
