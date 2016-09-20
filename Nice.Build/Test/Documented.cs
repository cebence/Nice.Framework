using System;

namespace Nice.Build.UnitTests
{
    /// <summary>
    /// Just a dummy class used for testing Nice.Build.
    /// </summary>
    public class Documented
    {
        /// <summary>
        /// Multiplies the specified number by two.
        /// </summary>
        /// <param name="number">The number to multiply by two.</param>
        /// <returns><paramref name="number"/> multiplied by two.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="number"/> is negative (less than zero).
        /// </exception>
        public int TimesTwo(int number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException("number", number, "Negative numbers are not allowed.");

            return number * 2;
        }
    }
}
