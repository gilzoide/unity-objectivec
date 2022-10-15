namespace Gilzoide.ObjectiveC.Foundation
{
    public struct NSNumber : IConvertibleToId
    {
        public static readonly Class Class = new Class("NSNumber");

        private Id _self;

        public bool BoolValue => _self.Call<bool>("boolValue");
        public char CharValue => _self.Call<char>("charValue");
        public double DoubleValue => _self.Call<double>("doubleValue");
        public float FloatValue => _self.Call<float>("floatValue");
        public int IntValue => _self.Call<int>("intValue");
        public long LongValue => _self.Call<long>("longValue");
        public short ShortValue => _self.Call<short>("shortValue");
        public uint UnsignedIntValue => _self.Call<uint>("unsignedIntValue");
        public ulong UnsignedLongValue => _self.Call<ulong>("unsignedLongValue");
        public ushort UnsignedShortValue => _self.Call<ushort>("unsignedShortValue");

        public NSNumber(Id self)
        {
            _self = self;
        }
        public static StrongReference<NSNumber> Alloc(bool b)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithBool:", b).Target));
        }
        public static StrongReference<NSNumber> Alloc(char c)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithChar:", c).Target));
        }
        public static StrongReference<NSNumber> Alloc(double d)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithDouble:", d).Target));
        }
        public static StrongReference<NSNumber> Alloc(float f)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithFloat:", f).Target));
        }
        public static StrongReference<NSNumber> Alloc(int i)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithInt:", i).Target));
        }
        public static StrongReference<NSNumber> Alloc(long l)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithLong:", l).Target));
        }
        public static StrongReference<NSNumber> Alloc(short s)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithShort:", s).Target));
        }
        public static StrongReference<NSNumber> Alloc(uint i)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedInt:", i).Target));
        }
        public static StrongReference<NSNumber> Alloc(ulong l)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedLong:", l).Target));
        }
        public static StrongReference<NSNumber> Alloc(ushort s)
        {
            return new StrongReference<NSNumber>(new NSNumber(Class.Alloc("initWithUnsignedShort:", s).Target));
        }

        public static AutoreleasedReference<NSNumber> NumberWith(bool b)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithBool:", b));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(char c)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithChar:", c));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(double d)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithDouble:", d));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(float f)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithFloat:", f));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(int i)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithInt:", i));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(long l)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithLong:", l));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(short s)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithShort:", s));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(uint i)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithUnsignedInt:", i));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(ulong l)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithUnsignedLong:", l));
        }
        public static AutoreleasedReference<NSNumber> NumberWith(ushort s)
        {
            return new AutoreleasedReference<NSNumber>(Class.ToId().Call<NSNumber>("numberWithUnsignedShort:", s));
        }

        public Id ToId()
        {
            return _self;
        }
    }
}
