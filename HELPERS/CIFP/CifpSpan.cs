using System;
using System.Globalization;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Low-level slicing helpers shared by every CIFP parser.
    /// </summary>
    /// <remarks>
    /// Every CIFP record is exactly 132 characters and every field is a fixed column range, so the
    /// parsers slice with <see cref="ReadOnlySpan{T}"/> rather than Substring. A span slice allocates
    /// nothing; only the values a model actually keeps are turned into strings. Across the 396,430
    /// records in a cycle that is the difference between roughly 12 million throwaway strings and none.
    /// <para>Every method here treats an all-blank slice as "not present" and returns an empty string or
    /// null rather than throwing, because blank is a legitimate and common value in CIFP data.</para>
    /// </remarks>
    internal static class CifpSpan
    {
        /// <summary>Trims a slice and returns it as a string, or <see cref="string.Empty"/> when blank.</summary>
        public static string Text(ReadOnlySpan<char> value)
        {
            ReadOnlySpan<char> trimmed = value.Trim();
            return trimmed.IsEmpty ? string.Empty : trimmed.ToString();
        }

        /// <summary>Returns a single character as a string, or <see cref="string.Empty"/> when blank.</summary>
        public static string Text(char value) => value == ' ' ? string.Empty : value.ToString();

        /// <summary>
        /// Returns a slice with its internal and trailing blanks intact.
        /// </summary>
        /// <remarks>
        /// Used where blanks carry meaning. The ICAO Code (5.14) is the clearest case: "K " is a real
        /// two-character code and trimming it to "K" loses information.
        /// </remarks>
        public static string TextKeepBlanks(ReadOnlySpan<char> value)
            => value.IsWhiteSpace() ? string.Empty : value.ToString();

        /// <summary>Parses a signed integer, returning null for a blank or non-numeric slice.</summary>
        /// <remarks>
        /// CIFP integers are zero padded and may carry a leading minus sign, as elevations below sea
        /// level do. A non-numeric slice returns null rather than throwing so one malformed record
        /// cannot abort a whole parse.
        /// </remarks>
        public static int? ToInt(ReadOnlySpan<char> value)
        {
            ReadOnlySpan<char> trimmed = value.Trim();
            if (trimmed.IsEmpty)
                return null;

            return int.TryParse(trimmed, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out int result)
                ? result
                : null;
        }

        /// <summary>Parses a single digit, returning null when blank or non-numeric.</summary>
        public static int? ToInt(char value)
            => value >= '0' && value <= '9' ? value - '0' : null;

        /// <summary>Parses a double, returning null for a blank or non-numeric slice.</summary>
        public static double? ToDouble(ReadOnlySpan<char> value)
        {
            ReadOnlySpan<char> trimmed = value.Trim();
            if (trimmed.IsEmpty)
                return null;

            return double.TryParse(trimmed, NumberStyles.Float, CultureInfo.InvariantCulture, out double result)
                ? result
                : null;
        }

        /// <summary>Parses a decimal, returning null for a blank or non-numeric slice.</summary>
        public static decimal? ToDecimal(ReadOnlySpan<char> value)
        {
            ReadOnlySpan<char> trimmed = value.Trim();
            if (trimmed.IsEmpty)
                return null;

            return decimal.TryParse(trimmed, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result)
                ? result
                : null;
        }

        /// <summary>
        /// Reads a yes/no flag, returning null when the slice is blank.
        /// </summary>
        /// <remarks>
        /// Blank is deliberately kept distinct from false. On the SBAS level of service fields a blank
        /// authorization means "this record carries RNP data instead", which is not the same as
        /// "not authorized".
        /// </remarks>
        public static bool? ToFlag(ReadOnlySpan<char> value)
        {
            ReadOnlySpan<char> trimmed = value.Trim();
            if (trimmed.IsEmpty)
                return null;

            return trimmed[0] switch
            {
                'Y' or 'A' => true,
                'N' => false,
                _ => null
            };
        }

        /// <summary>Reads a single-character yes/no flag, returning null when blank.</summary>
        public static bool? ToFlag(char value) => value switch
        {
            'Y' or 'A' => true,
            'N' => false,
            _ => null
        };
    }
}
