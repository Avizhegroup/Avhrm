namespace System;

public static class StringTools
{
    public static bool HasValue(this string s)
    {
        if (!string.IsNullOrEmpty(s))
        { 
            return true; 
        }

        return false;
    }

    public static bool HasNoValue(this string s)
    => !HasValue(s);

    public static bool NotEquals(this string s, string compareString)
    => !s.Equals(compareString);
}
