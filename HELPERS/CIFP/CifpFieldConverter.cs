using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Provides helper methods for converting CIFP fixed-width field values.
    /// Methods are named using the field number without the decimal, such as Field52 for field 5.2.
    /// </summary>
    internal class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.2 "Record Type"
        /// </summary>
        /// <remarks>
        /// Record types are divided into "standard" (S) and "tailored" (T) groups based on the first column; standard records precede tailored records in the file.
        /// </remarks>
        /// <returns>The converted Record Type value.</returns>
        public static string Field52(string? aspan)
        {
            return aspan switch
            {
                "S" => "Standard (S)",
                "T" => "Tailored (T)",

                // If the value is not recognized, return the original value or an empty string if it's null
                _ => aspan ?? string.Empty
            };
        }
    }
}
