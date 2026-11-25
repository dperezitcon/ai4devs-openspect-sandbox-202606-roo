using PalindromeChecker.Lib;
using Xunit;

namespace PalindromeChecker.Tests
{
    public class StringHelperTests
    {
        // ----------------------------------------------------------------
        // Casos TRUE (palíndromos)
        // ----------------------------------------------------------------

        [Theory]
        [InlineData("Amo la paloma")]               // clásico español con espacios
        [InlineData("A man a plan a canal Panama")]  // clásico inglés
        [InlineData("anilina")]                      // palabra simple
        [InlineData("a")]                            // un solo carácter
        [InlineData("Reconocer")]                    // con mayúscula inicial
        [InlineData("Yo soy")]                       // palíndromo corto español
        [InlineData("Dábale arroz a la zorra el abad")] // palíndromo con tildes
        public void IsPalindrome_ReturnsTrue_WhenInputIsPalindrome(string input)
        {
            bool result = StringHelper.IsPalindrome(input);
            Assert.True(result);
        }

        // ----------------------------------------------------------------
        // Casos FALSE (no palíndromos)
        // ----------------------------------------------------------------

        [Theory]
        [InlineData("hola")]
        [InlineData("palindromo")]
        [InlineData("inteligencia artificial")]
        [InlineData("Casi palíndromo omi dnilap isac")] // no es palíndromo
        public void IsPalindrome_ReturnsFalse_WhenInputIsNotPalindrome(string input)
        {
            bool result = StringHelper.IsPalindrome(input);
            Assert.False(result);
        }

        // ----------------------------------------------------------------
        // Casos extremos
        // ----------------------------------------------------------------

        [Fact]
        public void IsPalindrome_ReturnsFalse_WhenInputIsNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type
            bool result = StringHelper.IsPalindrome(null);
#pragma warning restore CS8625
            Assert.False(result);
        }

        [Fact]
        public void IsPalindrome_ReturnsFalse_WhenInputIsEmpty()
        {
            bool result = StringHelper.IsPalindrome("");
            Assert.False(result);
        }

        [Fact]
        public void IsPalindrome_ReturnsFalse_WhenInputContainsOnlyPunctuation()
        {
            // Tras filtrar caracteres alfanuméricos no queda nada -> false
            bool result = StringHelper.IsPalindrome("!!! ??? ...");
            Assert.False(result);
        }

        [Fact]
        public void IsPalindrome_ReturnsTrue_WhenInputIsWhitespaceAroundPalindrome()
        {
            // Los espacios se ignoran; "aba" es palíndromo
            bool result = StringHelper.IsPalindrome("  aba  ");
            Assert.True(result);
        }
    }
}
