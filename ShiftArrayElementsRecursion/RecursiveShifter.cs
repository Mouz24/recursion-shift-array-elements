using System;

#pragma warning disable CA1062

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                int temp = iterations[i];
                if ((i % 2) == 0)
                {
                    for (int j = 0; j < temp; j++)
                    {
                        ShiftL(source, source[0]);
                    }
                }
                else
                {
                    for (int j = 0; j < temp; j++)
                    {
                        ShiftR(source, source, source.Length);
                    }
                }
            }

            return source;
        }

        public static void ShiftL(int[] arr, int first, int i = 0)
        {
            int temp = first;
            if (i < arr.Length - 1)
            {
                arr[i] = arr[i + 1];
            }
            else
            {
                return;
            }

            ShiftL(arr, first, i + 1);
            arr[arr.Length - 1] = temp;
        }

        public static void ShiftR(int[] arr, int[] arr2, int length)
        {
            int temp = arr2[arr2.Length - 1];
            int i = length - 1;
            if (i > 0)
            {
                arr[i] = arr[i - 1];
            }
            else
            {
                return;
            }

            ShiftR(arr, arr2, length - 1);
            arr[0] = temp;
        }
    }
}
