#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
namespace Gilzoide.ObjectiveC
{
    public enum AssociationPolicy : ulong
    {
        Assign = 0,           /**< Specifies a weak reference to the associated object. */
        RetainNonatomic = 1, /**< Specifies a strong reference to the associated object. 
                              *   The association is not made atomically. */
        CopyNonatomic = 3,   /**< Specifies that the associated object is copied. 
                              *   The association is not made atomically. */
        Retain = 01401,       /**< Specifies a strong reference to the associated object.
                               *   The association is made atomically. */
        Copy = 01403          /**< Specifies that the associated object is copied.
                               *   The association is made atomically. */
    }
}
#endif