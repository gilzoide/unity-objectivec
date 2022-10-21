using System.Collections;
using System.Collections.Generic;

namespace Gilzoide.ObjectiveC.Foundation
{
    public class NSEnumeratorIEnumerable : IEnumerable<Id>
    {
        private Id _object;
        private Selector _selector;

        public NSEnumeratorIEnumerable(Id obj, Selector getEnumeratorSelector)
        {
            _object = obj;
            _selector = getEnumeratorSelector;
        }

        public IEnumerator<Id> GetEnumerator()
        {
            return new NSEnumeratorIEnumerator(_object.Call<NSEnumerator>(_selector));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
