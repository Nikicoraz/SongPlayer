using System;
using System.Linq;
using System.Text;

/// <summary>
/// Collezione di variabili, metodi e classi prefatte da me per velocizzare scrittura ripetitiva
/// </summary>
namespace UsefulTools
{
    /// <summary>
    /// Classe di comandi utili
    /// </summary>
    class UsefulTools
    {
        //Variabili
        private static char[] alphabetArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'y', 'z' };
        /// <summary>
        /// Array di char dell'alfabeto
        /// </summary>
        public static char[] alphabet { get { return alphabetArray; } }

        //Metodi
        public static void SayHi(string name)
        {
            Console.WriteLine("Hello " + name);
        }
        /// <summary>
        /// Trasforma i secondi in minuti
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToMinute(double s)
        {
            double m = 0;
            while (s >= 60)
            {
                s -= 60;
                m++;
            }
            double t = m + s / 100;
            return t;
        }
        /// <summary>
        /// Trasforma i minuti in secondi
        /// </summary>
        /// <param name="m"></param>
        public static void ToSecond(double m)
        {
            double s;
            s = m;
            m = Math.Floor(m);
            s = s - m;
            s *= 100;
            m *= 60;
            int t = Convert.ToInt32(s) + Convert.ToInt32(m);

            Console.WriteLine(Convert.ToString(t) + "s");
        }
        /// <summary>
        /// Controlla se il numero e' primo
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IsPrimeNumber(int num)
        {
            for (int i = 2; i <= num; i++)
            {
                if (i == num)
                {
                    return i + " is a prime number";
                }
                else if (num % i == 0)
                {
                    return num + " is not a prime number, it can be divided by: " + i;

                }
            }
            return "Error";
        }
        /// <summary>
        /// Esegue il teorema di pitagora
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Pitagora(double x, double y)
        {
            double dX = x * x;
            double dY = y * y;

            double i = Math.Sqrt(dX + dY);

            return i;
        }
        /// <summary>
        /// Dati 2 numeri e un simbolo di operazioni, esegue l'operazione
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double MakeOperation(char x, double y, double z)
        {
            double ret;
            switch (x)
            {
                case '+':
                    ret = y + z;
                    return ret;
                case '-':
                    ret = y - z;
                    return ret;
                case '*':
                    ret = y * z;
                    return ret;
                case '/':
                    ret = y / z;
                    return ret;
            }
            return 0;
        }
        /// <summary>
        /// Alterna caratteri maiuscoli con minuscoli
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string Stupidify(string x)
        {
            StringBuilder sb = new StringBuilder(x);


            for (int i = 0; i < x.Length; i++)
            {
                if (i % 2 == 0)
                {
                    string z;
                    z = Convert.ToString(sb[i]);
                    z = z.ToLowerInvariant();
                    sb[i] = Convert.ToChar(z);

                }
                else if (i % 2 == 1)
                {
                    string z;
                    z = Convert.ToString(sb[i]);
                    z = z.ToUpperInvariant();
                    sb[i] = Convert.ToChar(z);
                }
            }
            string result = sb.ToString();
            return result;
        }
        /// <summary>
        /// Prende un numero a caso tra x e y <i>escludendo</i> y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
        /// <summary>
        /// Trova la radice digitale di un numero
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double digitalRoot(double num)
        {
            return (num - 1) % 9 + 1;
        }
        /// <summary>
        /// Controlla se in una stringa ci sono caratteri uguali
        /// </summary>
        /// <param name="text"></param>
        /// <param name="displayDoubleLetter"></param>
        /// <returns></returns>
        public static bool AreCharactersUnique(string text, bool displayDoubleLetter)
        {
            StringBuilder letters = new StringBuilder(text);
            bool dejaVu = false;
            for (int i = 0; i < letters.Length; i++)
            {
                for (int y = 0; y < letters.Length; y++)
                {
                    if (y != i)
                    {
                        if (text[i] == text[y])
                        {
                            if (displayDoubleLetter) Console.WriteLine(text[i] + " is a dejavu letter!");
                            return true;
                        }
                    }
                }
            }
            if (!dejaVu)
            {
                return false;
            }
            return false;
        }
        /// <summary>
        /// Controlla se in una stringa ci sono parole doppie
        /// </summary>
        /// <remarks>
        /// Esempio: Un array di parole, le si unisce e si controlla
        /// </remarks>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <param name="DisplayDoubleWord"></param>
        /// <returns></returns>
        public static bool AreWordsUnique(string text, char[] separator, bool DisplayDoubleWord)
        {
            string[] words = text.Split(separator);
            for (int i = 0; i < words.Length; i++)
            {
                for (int y = 0; y < words.Length; y++)
                {
                    if (i != y)
                    {
                        if (words[i] == words[y])
                        {
                            if (DisplayDoubleWord) Console.WriteLine(words[i] + " is a duplicate!");
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        /// <summary>
        /// Trasforma i numeri scritti matematicamente in parole
        /// </summary>
        /// <param name="Phrase"></param>
        /// <returns></returns>
        public static string TransformNumbersToLetters(string Phrase)
        {
            Phrase = Phrase.Replace("2", "two");
            Phrase = Phrase.Replace("1", "one");
            Phrase = Phrase.Replace("0", "zero");
            Phrase = Phrase.Replace("3", "three");
            Phrase = Phrase.Replace("4", "four");
            Phrase = Phrase.Replace("5", "five");
            Phrase = Phrase.Replace("6", "six");
            Phrase = Phrase.Replace("7", "seven");
            Phrase = Phrase.Replace("8", "eight");
            Phrase = Phrase.Replace("9", "nine");
            return Phrase;
        }
        /// <summary>
        /// Trasforma le frasi in pig latin
        /// </summary>
        /// <param name="Phrase"></param>
        /// <returns></returns>
        public static string ToPigLatin(string Phrase)
        {
            string[] words = Phrase.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                char firstLetter;
                firstLetter = Convert.ToChar(words[i].Substring(0, 1));
                words[i] = words[i].Remove(0, 1);
                words[i] = words[i].Insert(words[i].Length, Convert.ToString(firstLetter));
                words[i] = words[i].Insert(words[i].Length, "ay");
            }
            string completePhrase = string.Join(" ", words);

            return completePhrase;
        }
        /// <summary>
        /// Alterna caratteri maiuscoli e minuscoli e trasforma il risultato in pig latin
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToStupidPigLatin(string phrase)
        {
            phrase = Stupidify(phrase);
            phrase = ToPigLatin(phrase);
            return phrase;
        }
        /// <summary>
        /// Fa la media
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double Media(double[] num)
        {
            double numeroAttuale = 0;
            foreach (double numero in num)
            {
                numeroAttuale += numero;
            }
            return numeroAttuale / num.Length;
        }
        /// <summary>
        /// Mette un numero decimale ad un certo numero di cifre dopo
        /// </summary>
        /// <param name="num"></param>
        /// <param name="cifre"></param>
        /// <returns></returns>
        public static double ToDecimalPlace(double num, int cifre)
        {
            double cifreDopoLaVirgola = Math.Pow(10, cifre);
            return (Math.Round(num * cifreDopoLaVirgola)) / cifreDopoLaVirgola;
        }
        /// <summary>
        /// Console write per pigri
        /// </summary>
        /// <param name="i"></param>
        public static void print(object i)
        {
            Console.Write(i);
        }
        /// <summary>
        /// Metodo per trovare l'indice della lettera nell'array <i>alphabet</i>
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static int FindLetterInTheAlphabet(char letter)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == letter)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void Progressbar(int percent, bool update = false)
        {
            const char BLOCK = '■';
            string BACK = string.Concat(Enumerable.Repeat('\b', 120));
            if (update)
            {
                Console.Write(BACK);
            }
            Console.Write('[');
            var p = (int)((percent / 1f) + .5f);
            for (int i = 0; i < 100; i++)
            {
                if (i >= p) Console.Write(' ');
                else Console.Write(BLOCK);
            }
            Console.Write("] {0, 3:###0}%", percent);
        }

        //Classi
        /// <summary>
        /// Variabile per immagazzinare 2 valori
        /// </summary>
        public class Vector2
        {
            public float x;
            public float y;
            public Vector2(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
            public static Vector2 operator +(Vector2 v1, Vector2 v2)
            {
                float x = v1.x + v2.x;
                float y = v1.y + v2.y;
                return new Vector2(x, y);
            }
            public static Vector2 operator -(Vector2 v1, Vector2 v2)
            {
                float x = v1.x - v2.x;
                float y = v1.y - v2.y;
                return new Vector2(x, y);
            }
            public static Vector2 operator *(Vector2 v1, Vector2 v2)
            {
                float x = v1.x * v2.x;
                float y = v1.y * v2.y;
                return new Vector2(x, y);
            }
            public static Vector2 operator /(Vector2 v1, Vector2 v2)
            {
                float x = v1.x / v2.x;
                float y = v1.y / v2.y;
                return new Vector2(x, y);
            }

        }
        /// <summary>
        /// Variabile per immagazzinare 3 valori
        /// </summary>
        public class Vector3 : Vector2
        {
            public float z;
            public Vector3(float x, float y, float z) : base(x, y)
            {
                this.z = z;
            }
            public Vector3(float x, float y) : base(x, y) { z = 0; }
            public static Vector3 operator +(Vector3 v1, Vector3 v2)
            {
                float x = v1.x + v2.x;
                float y = v1.y + v2.y;
                float z = v1.z + v2.z;
                return new Vector3(x, y, z);
            }
            public static Vector3 operator -(Vector3 v1, Vector3 v2)
            {
                float x = v1.x - v2.x;
                float y = v1.y - v2.y;
                float z = v1.z - v2.z;
                return new Vector3(x, y, z);
            }
            public static Vector3 operator *(Vector3 v1, Vector3 v2)
            {
                float x = v1.x * v2.x;
                float y = v1.y * v2.y;
                float z = v1.z * v2.z;
                return new Vector3(x, y, z);
            }
            public static Vector3 operator /(Vector3 v1, Vector3 v2)
            {
                float x = v1.x / v2.x;
                float y = v1.y / v2.y;
                float z;
                if (v1.z != 0 && v2.z != 0)
                {
                    z = v1.z / v2.z;
                }
                else
                {
                    z = 0;
                }
                return new Vector3(x, y, z);
            }

        }
    }
}
