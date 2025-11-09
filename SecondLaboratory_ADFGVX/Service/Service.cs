using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondLaboratory_ADFGVX.Core
{
    public class CipherService
    {
        private readonly Random random = new Random();

        private readonly char[] letters = { 'a', 'd', 'f', 'g', 'v', 'x' };

        private readonly char[,] tableADFGVX =
        {
            { 'а', 'б', 'в', 'г', 'д', 'е' },
            { 'ё', 'ж', 'з', 'и', 'й', 'к' },
            { 'л', 'м', 'н', 'о', 'п', 'р' },
            { 'с', 'т', 'у', 'ф', 'х', 'ц' },
            { 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь' },
            { 'э', 'ю', 'я', '.', '_', ',' }
        };

        private readonly static string[] russianWords =
        {
            "автомобиль","бабушка","вода","город","дом","еж","жара","зима","игра","йогурт",
            "книга","лиса","море","ночь","облако","птица","река","солнце","тигр","улица",
            "флаг","хлеб","цветок","чай","школа","яблоко","автобус","банан","велосипед","груша",
            "друг","ежевика","животное","зуб","игрушка","йога","картина","лампа","машина","носок",
            "обезьяна","печенье","работа","собака","телефон","учебник","фрукт","хомяк","цвет",
            "шарик","яблоня","артист","буква","вино","гриб","дождь","ежик","жизнь","зебра",
            "игла","йод","картофель","лист","молоко","новость","окно","память","роман","снег",
            "трава","ученик","фен","хоккей","часы","шарф","язык","альбом","береза","вино",
            "городок","доска","единица","жук","звонок","идея","йогурт","кабан","лук","мебель",
            "ночлег","орел","палец","рука","сапог","туча","учитель","фея","химия","чайка",
            "шапка","якорь","антенна","берег","весна","гитара","дерево","ежик","журнал","золото",
            "интернет","кабинет","лента","маска","новый","олень","печь","роза","сыр","тропа",
            "улей","фонарь","холм","цирк","шоколад","ясень","авиатор","блокнот","великан","голос",
            "день","ежегодник","жена","знак","изюм","команда","лебедь","мишка","нос","ответ",
            "перо","ромашка","стол","трактор","угол","ферма","хитрость","черепаха","штука","яблонька",
            "апельсин","бархат","ваза","горка","деревня","ежевика","желание","задание","изба","конь",
            "лапша","мост","небо","оазис","письмо","роса","стекло","традиция","уверенность","флот",
            "художник","цель","чемодан","школяр","ягода","ангел","батарея","вера","голова","древо",
            "еженедельник","жемчуг","зонтик","капуста","линейка","мыло","окорок","песня","рыба","свет",
            "тур","ученость","флагман","хвост","цветник","час","щенок","экран","юбка","автоматика"
        };

        private List<char> ReplaceLetters(string text)
        {
            var result = new List<char>();
            if (string.IsNullOrEmpty(text)) return result;

            foreach (var ch in text)
            {
                bool matched = false;
                for (int i = 0; i < 6 && !matched; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (tableADFGVX[i, j] == ch)
                        {
                            result.Add(letters[j]); 
                            result.Add(letters[i]); 
                            matched = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private List<char> TransposeLetters(string key, List<char> replacedLetters)
        {
            key = key.Replace(" ", "");
            if (string.IsNullOrEmpty(key)) return new List<char>(replacedLetters);

            int numRows = (int)Math.Ceiling((double)replacedLetters.Count / key.Length);
            char[,] grid = new char[numRows, key.Length];

            int idx = 0;
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < key.Length; col++)
                {
                    grid[row, col] = idx < replacedLetters.Count ? replacedLetters[idx++] : 'x';
                }
            }

            var columnOrder = key
                .Select((ch, i) => new { ch, i })
                .OrderBy(x => x.ch)
                .Select(x => x.i)
                .ToArray();

            var result = new List<char>();
            foreach (int col in columnOrder)
            {
                for (int row = 0; row < numRows; row++)
                {
                    result.Add(grid[row, col]);
                }
            }

            return result;
        }

        public string Encrypt(string text, string key)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            var replaced = ReplaceLetters(text);
            var transposed = TransposeLetters(key, replaced);
            return string.Join("", transposed);
        }

        public string Decrypt(string text, string key)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key)) return string.Empty;

            key = key.Replace(" ", "");
            int numRows = (int)Math.Ceiling((double)text.Length / key.Length);
            char[,] grid = new char[numRows + 1, key.Length];

            var columns = new List<(char letter, int index)>();
            for (int i = 0; i < key.Length; i++)
                columns.Add((key[i], i));

            columns.Sort((a, b) =>
            {
                int cmp = a.letter.CompareTo(b.letter);
                return cmp != 0 ? cmp : a.index.CompareTo(b.index);
            });

            int index = 0;
            foreach (var column in columns)
            {
                for (int row = 1; row <= numRows; row++)
                {
                    grid[row, column.index] = index < text.Length ? text[index++] : 'x';
                }
            }

            var flat = new List<char>();
            for (int row = 1; row <= numRows; row++)
                for (int col = 0; col < key.Length; col++)
                    flat.Add(grid[row, col]);

            var decrypted = new List<char>();
            for (int i = 0; i + 1 < flat.Count; i += 2)
            {
                char first = flat[i];
                char second = flat[i + 1];

                int col = Array.IndexOf(letters, first);
                int row = Array.IndexOf(letters, second);

                if (row >= 0 && col >= 0)
                    decrypted.Add(tableADFGVX[row, col]);
            }

            return new string(decrypted.Where(c => c != 'x').ToArray());
        }

        public string GenerateKey()
        {
            string w1 = russianWords[random.Next(russianWords.Length)];
            string w2 = russianWords[random.Next(russianWords.Length)];
            string w3 = russianWords[random.Next(russianWords.Length)];
            return $"{w1} {w2} {w3}";
        }
    }
}