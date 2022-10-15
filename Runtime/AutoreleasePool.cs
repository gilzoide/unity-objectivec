using System;

namespace Gilzoide.ObjectiveC
{
    public unsafe class AutoreleasePool : IDisposable
    {
        public struct Context
        {        
            private IntPtr _context;
        }

        private Context _context;

        public AutoreleasePool()
        {
            _context = Runtime.objc_autoreleasePoolPush();
        }

        public void Dispose()
        {
            Runtime.objc_autoreleasePoolPop(_context);
        }
    }
}