using System;
using System.Text;
using System.Collections.Generic;

public static class EnumFlags32Extensions
{
    private const int LENGTH = 32;
    private static readonly StringBuilder NAME_BUILDER = new StringBuilder(32);

    /// <summary>
    /// Get iterator for each flag (It occurs GC Allocation for iterator)
    /// </summary>
    public static IEnumerable<T> GetFlags<T>(this T flags) where T : unmanaged, Enum
    {
        int flagsValue = ToInt32(flags);

        for (int i = 0; i < LENGTH; i++)
        {
            int targetValue = 1 << i;

            if ((targetValue & flagsValue) == targetValue)
            {
                yield return ToEnum<T>(targetValue);
            }
        }
    }

    /// <summary>
    /// Get iterator for each flagged index (It occurs GC Allocation for iterator)
    /// </summary>
    public static IEnumerable<int> GetIndexes<T>(this T flags) where T : unmanaged, Enum
    {
        int flagsValue = ToInt32(flags);

        for (int i = 0; i < LENGTH; i++)
        {
            int targetValue = 1 << i;

            if ((targetValue & flagsValue) == targetValue)
            {
                yield return i;
            }
        }
    }

    /// <summary>
    /// Invoke action on each flag (No GC Allocation occurs)
    /// </summary>
    public static void For<T>(this T flags, Action<T> action) where T : unmanaged, Enum
    {
        int flagsValue = ToInt32(flags);

        for (int i = 0; i < LENGTH; i++)
        {
            int targetValue = 1 << i;

            if ((targetValue & flagsValue) == targetValue)
            {
                action(ToEnum<T>(targetValue));
            }
        }
    }

    /// <summary>
    /// Invoke action on each flagged index (No GC Allocation occurs)
    /// </summary>
    public static void For<T>(this T flags, Action<int> action) where T : unmanaged, Enum
    {
        int flagsValue = ToInt32(flags);

        for (int i = 0; i < LENGTH; i++)
        {
            int targetValue = 1 << i;

            if ((targetValue & flagsValue) == targetValue)
            {
                action.Invoke(i);
            }
        }
    }

    /// <summary>
    /// Get index of flagged bit
    /// </summary>
    public static int GetBitIndex<T>(this T nonFlagsValue) where T : unmanaged, Enum
    {
        int value = ToInt32(nonFlagsValue);

        for (int i = 0; i < LENGTH; i++)
        {
            int targetValue = 1 << i;

            if ((targetValue & value) == targetValue)
            {
                return i;
            }
        }

        return 0;
    }

    /// <summary>
    /// Return true if value is included in flags
    /// </summary>
    public static bool Contains<T>(this T flags, T nonFlagsValue) where T : unmanaged, Enum
    {
        int flagsValue = ToInt32(flags);
        int targetValue = ToInt32(nonFlagsValue);

        return (flagsValue & targetValue) == targetValue;
    }

    /// <summary>
    /// Convert enum to int (No GC Allocation occurs)
    /// </summary>
    public static unsafe int ToInt32<T>(this T flags) where T : unmanaged, Enum
    {
        return *(int*)&flags;
    }

    /// <summary>
    /// Convert int to enum (No GC Allocation occurs)
    /// </summary>
    public unsafe static T ToEnum<T>(this int value) where T : unmanaged, Enum
    {
        return *(T*)&value;
    }

    /// <summary>
    /// Convert to string with display name
    /// </summary>
    public static string ToDisplayName<T>(this T nonFlagsValue) where T : unmanaged, Enum
    {
        NAME_BUILDER.Append(nonFlagsValue.ToString());
        char firstChar = NAME_BUILDER[0];

        if (firstChar >= 97 && firstChar <= 122)
        {
            //Set first char to upper case
            NAME_BUILDER[0] = (char)(firstChar - 32);
        }

        for (int i = NAME_BUILDER.Length - 1; i >= 1; i--)
        {
            char c = NAME_BUILDER[i];
            char nextChar = NAME_BUILDER[i - 1];

            if (nextChar >= 65 && nextChar <= 90)
            {
                //Continue if next char is uppercase
                continue;
            }

            if (c >= 65 && c <= 90)
            {
                //Add empty space to next if it's upper case
                NAME_BUILDER.Insert(i, ' ');
            }
        }

        string result = NAME_BUILDER.ToString();
        NAME_BUILDER.Clear();
        return result;
    }
}