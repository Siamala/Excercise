using Excercise_1;
using FluentAssertions;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace PPTA_Excercises.Tests.Excercise_1
{
    public class ArrayHelperTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            string[] array = { "jabłko", "masło", "kurczak", "witamina" };

            // Act
            var result = ArrayHelper.RemoveEmptyElements(array);

            // Assert
            result.Length.Should().Be(4);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            string[] array = { };

            // Act
            var result = ArrayHelper.RemoveEmptyElements(array);

            // Assert
            result.Length.Should().Be(0);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int size = 3;

            // Act
            var result = arr.Split(size).ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new[] { 1, 2, 3 }, result[0]);
            Assert.Equal(new[] { 4, 5, 6 }, result[1]);
            Assert.Equal(new[] { 7 }, result[2]);
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            int[] arr = new int[0];
            int size = 2;

            // Act
            var result = arr.Split(size).ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Test5()
        {
            // Arrange
            int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            int[] slicedArray = myArray.Slice(2, 4); // Zwróci tablicę { 3, 4, 5, 6 }

            // Assert
            slicedArray.Should().BeEquivalentTo(new[] { 3, 4, 5, 6 });
        }


        [Fact]
        public void Test6()
        {
            // Arrange
            int[] source = { 1, 2, 3, 4, 5 };

            // Act
            int[] slice = source.Slice(2, 0);

            // Assert
            Assert.Empty(slice);
        }

        [Fact]
        public void Test7()
        {
            // Arrange
            int[] source = { 1, 2, 3, 4, 5 };

            // Act
            int[] slice = source.SliceWithPadding(2, 0);

            // Assert
            Assert.Empty(slice);
        }
    }
}