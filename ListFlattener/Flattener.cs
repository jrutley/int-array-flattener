using System;
using System.Collections.Generic;
using System.Linq;

namespace ListFlattener
{
    public class Flattener
    {
        /// <summary>
        /// Flatten takes a nested array of integers and flattens them out into a single flat array of integers
        /// Any non-integer values present in the array will cause an InvalidOperationException to be thrown
        /// </summary>
        /// <param name="arrayOfInts"></param>
        /// <returns>Array of flattened ints</returns>
        public int[] Flatten(dynamic arrayOfInts)
        {
            var result = new List<int>();
            foreach(var el in arrayOfInts)
            {
                if (el is int)
                {
                    result.Add((int)el);
                }
                else if(el is Array)
                {
                    result.AddRange(Flatten(el));
                }
                else
                {
                    throw new InvalidOperationException($"\"{el}\" should be either an integer or array of integer");
                }
            }
            return result.ToArray();
        }
    }
}
