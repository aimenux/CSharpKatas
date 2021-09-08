using FluentAssertions;
using Lib;
using Xunit;

namespace Tests
{
    public class Kata01Tests
    {
        [Fact]
        public void Should_Get_Valid_Index_For_Null_Array()
        {
            // arrange
            var array = default(int[]);

            // act
            var index = Kata01.FindStartingIndex(array);

            // assert
            index.Should().Be(-1);
        }

        [Fact]
        public void Should_Get_Valid_Index_For_Empty_Array()
        {
            // arrange
            var array = new int[] {};

            // act
            var index = Kata01.FindStartingIndex(array);

            // assert
            index.Should().Be(-1);
        }

        [Theory]
        [InlineData(new[] { 3 }, 0)]
        [InlineData(new[] { 3, 3 }, 0)]
        [InlineData(new[] { 5, 7 }, 0)]
        [InlineData(new[] { 5, 5, 7 }, 0)]
        [InlineData(new[] { 5, 7, 7 }, 1)]
        [InlineData(new[] { 5, 5, 7, 7 }, 0)]
        [InlineData(new[] { 5, 7, 7, 5, 5, 5 }, 3)]
        [InlineData(new[] { 5, 7, 5, 5, 5, 5, 4 }, 2)]
        [InlineData(new[] { 1, 7, 1, 1, 7, 2, 2, 2, 7 }, 5)]
        [InlineData(new[] { 1, 0, 1, 1, 1, 0, 0, 1, 0, 0 }, 2)]
        public void Should_Get_Valid_Index_For_Not_Empty_Array(int[] array, int expectedIndex)
        {
            // arrange
            // act
            var index = Kata01.FindStartingIndex(array);

            // assert
            index.Should().Be(expectedIndex);
        }
    }
}
