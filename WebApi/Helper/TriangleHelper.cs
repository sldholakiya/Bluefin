using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace WebApi.Helper
{
    public class TriangleHelper
    {
        /// <summary>
        /// Finds the type of the specified triangle.
        /// </summary>
        /// <param name="a">The length of side 'a'.</param>
        /// <param name="b">The length of side 'b'.</param>
        /// <param name="c">The length of side 'c'.</param>
        /// <returns>The <see cref="TriangleType"/> type.</returns>
        public TriangleType ClassifyTriangleType(int a, int b, int c)
        {
            var key = string.Format("Triangle-{0},{1},{2}", a, b, c);
            var cacheItem = MemoryCache.Default.GetCacheItem(key);

            var triangle = TriangleType.Error;

            if (cacheItem != null)
            {
                triangle = (TriangleType)cacheItem.Value;
            }
            else
            {
                if (!CheckForExistentTriangle(a, b, c))
                    return TriangleType.Error;

                if (CheckForEquilateralType(a, b, c))
                {
                    triangle = TriangleType.Equilateral;
                }
                else if (CheckForScaleneType(a, b, c))
                {
                    triangle = TriangleType.Scalene;
                }
                else if (CheckForIsoscelesType(a, b, c))
                {
                    triangle = TriangleType.Isosceles;
                }

                MemoryCache.Default.Add(new CacheItem(key, triangle), new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromHours(10) });
            }

            return triangle;
        }

        #region Protected Methods

        private bool CheckForExistentTriangle(int a, int b, int c)
        {
            bool triangleFound = true;

            // All sides must have positive value.
            if (a <= 0 || b <= 0 || c <= 0)
            {
                triangleFound = false;
            }
            else if (((long)a + b) <= c)    // Sum of two sides must be greater than the third side
            {
                triangleFound = false;
            }
            else if (((long)a + c) <= b)
            {
                triangleFound = false;
            }
            else if (((long)b + c) <= a)
            {
                triangleFound = false;
            }

            return triangleFound;
        }

        // An equilateral triangle has all sides the same length. 
        private bool CheckForEquilateralType(int a, int b, int c)
        {
            return (a == b && a == c);
        }

        // A scalene triangle has all sides different lengths, or equivalently all angles are unequal.
        private bool CheckForScaleneType(int a, int b, int c)
        {
            return (a != b && a != c && b != c);
        }

        // An isosceles triangle has two sides of equal length.
        private bool CheckForIsoscelesType(int a, int b, int c)
        {
            return (a == b || a == c || b == c);
        }


        #endregion
    }

    
    public enum TriangleType
    {
        Error,
        Equilateral,
        Isosceles,
        Scalene
    }
}