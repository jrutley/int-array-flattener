using System;
using Xunit;

namespace ArrayFlattener.Tests
{
    public class FlattenerTest
    {
        [Fact]
        public void EmptyArray()
        {
            var array = new int[0];
            var expected = new int[0];

            var sut = new Flattener();
            var result = sut.Flatten(array);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SingleElementsOnly()
        {
            var array = new int[]{ 1, 2, 3, 4, 5 };
            var expected = new int[] { 1, 2, 3, 4, 5 };

            var sut = new Flattener();
            var result = sut.Flatten(array);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SingleAndMultiElements()
        {
            var array = new dynamic[]{ 1, 2, new[]{3, 6}, 4, 5 };
            var expected = new[] {1,2,3,6,4,5};

            var sut = new Flattener();
            var result = sut.Flatten(array);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void EmptyArrayElementsInMiddle()
        {
            var array = new dynamic[]{ 1, 2, new string[]{}, 4, 5 };
            var expected = new[] {1,2,4,5};

            var sut = new Flattener();
            var result = sut.Flatten(array);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NestedElements()
        {
            var array = new dynamic[] { 1, 2, new dynamic[] { 3, 6, new[] { 7,7,7} }, 4, 5 };
            var expected = new[] { 1, 2, 3, 6, 7, 7, 7, 4, 5 };

            var sut = new Flattener();
            var result = sut.Flatten(array);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NonIntElementsThrow()
        {
            var array = new dynamic[]{ 1, "2" };

            var sut = new Flattener();
            Assert.Throws<InvalidOperationException>(() => sut.Flatten(array));
        }

        [Fact]
        // We don't want to run this one often since it adds an extra 7-8 seconds to the test run
        public void LargeNumberOfElementsGetsProcessed()
        {
            var expected = new int[10000000];

            var sut = new Flattener();
            var result = sut.Flatten(expected);

            Assert.Equal(expected, result);
        }
    }
}