namespace Muleki.Common.Extensions
{
    public static class UtilsExtensions
    {
        public static bool IsNull(this object obj)
        {
            if (obj is null)
                return true;

            return false;
        }
    }
}