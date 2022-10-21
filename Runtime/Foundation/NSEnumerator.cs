namespace Gilzoide.ObjectiveC
{
    public struct NSEnumerator : IId
    {
        public static Class Class = new Class("NSEnumerator");

        private Id _self;

        public Id AsId => _self;

        public NSEnumerator(Id self)
        {
            _self = self;
        }

        public Id NextObject()
        {
            return _self.Call<Id>("nextObject");
        }

        public override string ToString()
        {
            return _self.ToString();
        }

        public static explicit operator NSEnumerator(Id id)
        {
            return new NSEnumerator(id);
        }
        public static implicit operator Id(NSEnumerator enumerator)
        {
            return enumerator._self;
        }
    }
}
