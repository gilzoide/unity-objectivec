using System;
using System.Collections;
using System.Collections.Generic;

namespace Gilzoide.ObjectiveC.Foundation
{
    public class NSEnumeratorIEnumerator : IEnumerator<Id>
    {
        private NSEnumerator _enumerator;
        private Id _current;

        public Id Current => _current;

        object IEnumerator.Current => Current;

        public NSEnumeratorIEnumerator(NSEnumerator enumerator)
        {
            _enumerator = enumerator;
        }

        public void Dispose()
        {
            _enumerator = new NSEnumerator();
            _current = Id.Nil;
        }

        public bool MoveNext()
        {
            _current = _enumerator.NextObject();
            return !_current.IsNil;
        }

        public void Reset()
        {
            throw new InvalidOperationException("NSEnumerator cannot be reset");
        }
    }
}
