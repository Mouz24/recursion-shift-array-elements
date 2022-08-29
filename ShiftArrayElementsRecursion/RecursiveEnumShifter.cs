using System;

#pragma warning disable CA1062

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
           if (source is null)
           {
                throw new ArgumentNullException(nameof(source));
           }

           if (directions is null)
           {
                throw new ArgumentNullException(nameof(directions));
           }

           for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] != Direction.Left && directions[i] != Direction.Right)
                {
                    throw new InvalidOperationException();
                }
            }

           if (source.Length == 1)
            {
                return source;
            }

           for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == Direction.Left)
                {
                    ShiftL(source, source[0]);
                }
                else if (directions[i] == Direction.Right)
                {
                    ShiftR(source, source, source.Length);
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
