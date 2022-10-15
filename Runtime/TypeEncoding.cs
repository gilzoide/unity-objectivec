#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
namespace Gilzoide.ObjectiveC
{
    public static class TypeEncoding
    {
        public const char C_ID          = '@';
        public const char C_CLASS       = '#';
        public const char C_SEL         = ':';
        public const char C_CHR         = 'c';
        public const char C_UCHR        = 'C';
        public const char C_SHT         = 's';
        public const char C_USHT        = 'S';
        public const char C_INT         = 'i';
        public const char C_UINT        = 'I';
        public const char C_LNG         = 'l';
        public const char C_ULNG        = 'L';
        public const char C_LNG_LNG     = 'q';
        public const char C_ULNG_LNG    = 'Q';
        public const char C_INT128      = 't';
        public const char C_UINT128     = 'T';
        public const char C_FLT         = 'f';
        public const char C_DBL         = 'd';
        public const char C_LNG_DBL     = 'D';
        public const char C_BFLD        = 'b';
        public const char C_BOOL        = 'B';
        public const char C_VOID        = 'v';
        public const char C_UNDEF       = '?';
        public const char C_PTR         = '^';
        public const char C_CHARPTR     = '*';
        public const char C_ATOM        = '%';
        public const char C_ARY_B       = '[';
        public const char C_ARY_E       = ']';
        public const char C_UNION_B     = '(';
        public const char C_UNION_E     = ')';
        public const char C_STRUCT_B    = '{';
        public const char C_STRUCT_E    = '}';
        public const char C_VECTOR      = '!';

        public const char C_COMPLEX     = 'j';
        public const char C_ATOMIC      = 'A';
        public const char C_CONST       = 'r';
        public const char C_IN          = 'n';
        public const char C_INOUT       = 'N';
        public const char C_OUT         = 'o';
        public const char C_BYCOPY      = 'O';
        public const char C_BYREF       = 'R';
        public const char C_ONEWAY      = 'V';
        public const char C_GNUREGISTER = '+';
    }
}
#endif