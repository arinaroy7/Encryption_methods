using System;
using System.Collections.Generic;
using System.Linq;

namespace CipherLab
{
    public class alphabeticCipher
    {
        private const string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private readonly Random _rand = new();
        private static readonly Dictionary<char, double> RussianLetterFrequencies = new Dictionary<char, double>
        {
            {'о', 0.10983}, {'е', 0.08483}, {'а', 0.07998}, {'и', 0.07367}, {'н', 0.06700},
            {'т', 0.06318}, {'с', 0.05473}, {'р', 0.04746}, {'в', 0.04533}, {'л', 0.04343},
            {'к', 0.03486}, {'м', 0.03203}, {'д', 0.02977}, {'п', 0.02804}, {'у', 0.02615},
            {'я', 0.02001}, {'ы', 0.01898}, {'ь', 0.01735}, {'г', 0.01687}, {'з', 0.01641},
            {'б', 0.01592}, {'ч', 0.01450}, {'й', 0.01208}, {'х', 0.00966}, {'ж', 0.00940},
            {'ш', 0.00718}, {'ю', 0.00639}, {'ц', 0.00486}, {'щ', 0.00361}, {'э', 0.00331},
            {'ф', 0.00267}, {'ъ', 0.00037}, {'ё', 0.00013}
        };
        public string CreateRandomKey()
        {
            var letters = Alphabet.ToList();
            for (int i = 0; i < letters.Count; i++)
            {
                int j = _rand.Next(i, letters.Count);
                (letters[i], letters[j]) = (letters[j], letters[i]);
            }
            return new string(letters.ToArray());
        }
        public string EncryptText(string input, string key)
        {
            if (key == null || key.Length != Alphabet.Length)
                throw new ArgumentException("Введите ключ длиной 33 символа.");

            var map = new Dictionary<char, char>();
            for (int i = 0; i < Alphabet.Length; i++)
                map[Alphabet[i]] = key[i];

            return new string(input.Select(ch =>
                map.TryGetValue(ch, out char encoded) ? encoded : ch).ToArray());
        }
        public string DecryptText(string input, string key)
        {
            if (key == null || key.Length != Alphabet.Length)
                throw new ArgumentException("Ключ некорректной длины.");

            var map = new Dictionary<char, char>();
            for (int i = 0; i < Alphabet.Length; i++)
                map[key[i]] = Alphabet[i];

            return new string(input.Select(ch =>
                map.TryGetValue(ch, out char decoded) ? decoded : ch).ToArray());
        }
        public string HackKey(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentException("Текст пустой.");

            var freqs = CalculateFrequencies(cipherText);
            var sortedCipherByFreq = freqs.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();
            var sortedRussianByFreq = RussianLetterFrequencies.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();

            var cipherToPlain = new Dictionary<char, char>();
            int pairs = Math.Min(sortedCipherByFreq.Count, sortedRussianByFreq.Count);
            for (int i = 0; i < pairs; i++)
                cipherToPlain[sortedCipherByFreq[i]] = sortedRussianByFreq[i];

            var hackedKey = new char[Alphabet.Length];
            var usedCipherChars = new HashSet<char>();

            for (int i = 0; i < Alphabet.Length; i++)
            {
                char plain = Alphabet[i];
                var found = cipherToPlain.FirstOrDefault(kvp => kvp.Value == plain);
                if (!found.Equals(default(KeyValuePair<char, char>)) && !usedCipherChars.Contains(found.Key))
                {
                    hackedKey[i] = found.Key;
                    usedCipherChars.Add(found.Key);
                }
                else
                {
                    var nextUnused = Alphabet.First(c => !usedCipherChars.Contains(c));
                    hackedKey[i] = nextUnused;
                    usedCipherChars.Add(nextUnused);
                }
            }

            return new string(hackedKey);
        }
        public (string guessedKey, string decryptedText) HackDecrypt(string cipherText)
        {
            var guessedKey = HackKey(cipherText);
            var decrypted = DecryptText(cipherText, guessedKey);
            return (guessedKey, decrypted);
        }
        private Dictionary<char, double> CalculateFrequencies(string text)
        {
            var frequencies = new Dictionary<char, double>();
            int totalLetters = 0;
            foreach (var c in text)
            {
                if (Alphabet.Contains(c))
                {
                    if (!frequencies.ContainsKey(c))
                        frequencies[c] = 0;
                    frequencies[c]++;
                    totalLetters++;
                }
            }
            if (totalLetters == 0)
                return new Dictionary<char, double>();

            var result = new Dictionary<char, double>();
            foreach (var kvp in frequencies)
                result[kvp.Key] = kvp.Value / totalLetters;

            return result;
        }
    }
}