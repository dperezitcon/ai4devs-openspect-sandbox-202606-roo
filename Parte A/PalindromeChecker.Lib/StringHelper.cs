using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PalindromeChecker.Lib
{
    /// <summary>
    /// Colección de utilidades de cadenas de texto.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Determina si el texto proporcionado es un palíndromo.
        /// La comparación ignora espacios, signos de puntuación, diferencias
        /// entre mayúsculas/minúsculas y diacríticos (tildes, diéresis, etc.).
        /// </summary>
        /// <param name="text">El texto a evaluar.</param>
        /// <returns>
        /// <c>true</c> si <paramref name="text"/> es un palíndromo;
        /// <c>false</c> si es <c>null</c>, vacío o no es palíndromo.
        /// </returns>
        public static bool IsPalindrome(string? text)
        {
            // Casos extremos: null o vacío -> false
            if (string.IsNullOrEmpty(text))
                return false;

            // Normalizamos:
            //  1. Minúsculas
            //  2. Forma Normal D (NFD): descompone cada letra acentuada en letra
            //     base + diacrítico como codepoints separados.
            //     Ejemplo: 'á' -> 'a' + U+0301 (combining acute accent)
            //  3. Eliminamos los NonSpacingMark (diacríticos descompuestos)
            //  4. Solo letras y dígitos (descarta espacios y puntuación)
            char[] normalized = text
                .ToLowerInvariant()
                .Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark
                            && char.IsLetterOrDigit(c))
                .ToArray();

            // Si tras filtrar no queda ningún carácter alfanumérico -> false
            if (normalized.Length == 0)
                return false;

            // Comprobación palíndromo con dos punteros
            int left = 0;
            int right = normalized.Length - 1;

            while (left < right)
            {
                if (normalized[left] != normalized[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}
