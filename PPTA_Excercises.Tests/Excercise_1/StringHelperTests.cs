using Excercise_1;
using FluentAssertions;
using System;
using Xunit;

namespace PPTA_Excercises.Tests.Excercise_1
{
    public class StringHelperTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var fileName = "calc.exe";

            // Act
            var result = StringHelper.AddDirectoryToPathFile(fileName, string.Empty);

            // Assert
            result.Should().Be("calc.exe");
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var name = string.Empty;

            // Act
            var result = StringHelper.AddDirectoryToPathFile(name, name);

            // Assert
            result.Length.Should().Be(0);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            string input = "abcdefghijklmnopqrstuvwxyz";
            int limit = 5;

            // Act
            var chunks = input.SplitLimit(limit);

            // Assert
            string[] expectedChunks = { "abcde", "fghij", "klmno", "pqrst", "uvwxy", "z" };
            Assert.Equal(expectedChunks, chunks);
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            string fileName = "good_filename.txt";

            // Act
            string sanitizedFileName = fileName.RemoveInvalidFileNameCharacters();

            // Assert
            Assert.Equal(fileName, sanitizedFileName);
        }

        [Fact]
        public void Test5()
        {
            // Arrange
            string input = "0A-1B-2C-GF";
            char separator = '-';

            // Act
            bool result = input.TryParseHexStringWithSeparatorToByteArray(separator, out byte[] byteArray);

            // Assert
            Assert.False(result);
            Assert.Null(byteArray);
        }

        [Fact]
        public void Test6()
        {
            // Arrange
            string hexString = "GHIJKL";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => StringHelper.HexStringToByteArray(hexString));
        }

        [Fact]
        public void Test7()
        {
            // Arrange
            string hexString = "0x1A2B3C4D";
            byte[] expectedBytes = new byte[] { 0x1A, 0x2B, 0x3C, 0x4D };

            // Act
            byte[] result = StringHelper.HexStringToByteArray(hexString);

            // Assert
            Assert.Equal(expectedBytes, result);
        }
    }
}
