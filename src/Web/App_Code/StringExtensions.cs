
public static class StringExtensions
{
    public static string FormatWith(this string @this, params object[] args)
    {
        return string.Format(@this, args);
    }
}
