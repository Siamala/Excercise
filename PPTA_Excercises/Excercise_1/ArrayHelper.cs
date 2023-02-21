using System;
using System.Collections.Generic;
using System.Linq;

namespace Excercise_1
{
    public static class ArrayHelper
    {
        public static T[] Slice<T>(this T[] source, int index, int length)
        {
            T[] slice = new T[length];
            Array.Copy(source, index, slice, 0, length);
            return slice;
        }

        public static T[] SliceWithPadding<T>(this T[] source, int index, int length)
        {
            T[] slice = new T[length];

            Populate(slice, default(T));

            if (source.Length < (index + length))
            {
                T[] subsliceWithData = Slice<T>(source, index, (source.Length - index));

                for (int i = 0; i < subsliceWithData.Length; i++)
                {
                    slice[i] = subsliceWithData[i];
                }
            }
            else
            {
                slice = Slice<T>(source, index, length);
            }

            return slice;
        }

        private static void Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }

        public static string[] RemoveEmptyElements(this string[] array)
        {
            List<string> outputArray = new List<string>();

            outputArray = array.ToList();
            outputArray.RemoveAll(x => x.Length == 0);

            return outputArray.ToArray();
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] arr, int size)
        {
            for (var i = 0; i < arr.Length / size + 1; i++)
            {
                var result = arr.Skip(i * size).Take(size);
                if (result.Count() > 0)
                {
                    yield return arr.Skip(i * size).Take(size);
                }
            }
        }
    }
}
