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
    /// <returns>The converted Record Type values.
    /// Usually, if the field is empty or whitespace, return an empty string "" instead of null or whitespace and if the value is not recognized, returns it as-is.
    /// </returns>
    internal static partial class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.2 "Record Type"
        /// </summary>
        /// <remarks>
        /// Record types are divided into "standard" (S) and "tailored" (T) groups based on the first column; standard records precede tailored records in the file.
        /// </remarks>
        /// <returns>Ex: "Standard (S)", "Tailored (T)"</returns>
        public static string Field52(char fieldValue)
        {
            // A char cannot be empty, but it can be whitespace or null.
            if (fieldValue == ' ')
                return string.Empty;
        
            return fieldValue switch
            {
                'S' => "(S) Standard",
                'T' => "(T) Tailored",
        
                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }
    }
}