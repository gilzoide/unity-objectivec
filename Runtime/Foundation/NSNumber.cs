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
        public static StrongReference<NSNumber> Alloc(bool b)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithBool:", b)));
        }
        public static StrongReference<NSNumber> Alloc(char c)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithChar:", c)));
        }
        public static StrongReference<NSNumber> Alloc(double d)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithDouble:", d)));
        }
        public static StrongReference<NSNumber> Alloc(float f)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithFloat:", f)));
        }
        public static StrongReference<NSNumber> Alloc(int i)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithInt:", i)));
        }
        public static StrongReference<NSNumber> Alloc(long l)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithLong:", l)));
        }
        public static StrongReference<NSNumber> Alloc(short s)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithShort:", s)));
        }
        public static StrongReference<NSNumber> Alloc(uint i)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedInt:", i)));
        }
        public static StrongReference<NSNumber> Alloc(ulong l)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedLong:", l)));
        }
        public static StrongReference<NSNumber> Alloc(ushort s)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedShort:", s)));
        }

        public static AutoreleasedReference<NSNumber> NumberWith(bool b)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithBool:", b));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(char c)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithChar:", c));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(double d)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithDouble:", d));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(float f)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithFloat:", f));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(int i)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithInt:", i));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(long l)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithLong:", l));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(short s)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithShort:", s));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(uint i)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithUnsignedInt:", i));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(ulong l)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithUnsignedLong:", l));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(ushort s)
        {
            return new AutoreleasedReference<NSNumber>(Class.AsId.Call<NSNumber>("numberWithUnsignedShort:", s));
        }

        public Id AsId => _self;

        public override string ToString()
        {
            return _self.ToString();
        }

        public static implicit operator Id(NSNumber n)
        {
            return n._self;
        }
    }
}
