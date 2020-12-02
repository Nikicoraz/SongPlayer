using Panda_2;
using System;
using System.Diagnostics;

namespace SongPlayer
{
    //Classe canzoni da usare nel programma
    /// <summary>
    /// Classe modello per canzoni
    /// </summary>
    class Song : IComparable
    {
        
        public string name;
        public string author;
        public int time;
        public string link;

        public Song(string n, string a, int t, string l)
        {
            name = n;
            author = a;
            time = t;
            link = l;
        }

        //Metodo per elencare le variabili della canzone
        ///<summary>
        ///Metodo per elencare le variabili della canzone
        /// </summary>
        public static void Listen(Song i)
        {
            Console.WriteLine("Name: " + i.name);
            Console.WriteLine("Author: " + i.author);
            Console.WriteLine("Lenght (s): " + Convert.ToString(i.time) + "s");
            Console.Write("Lenght (m): "); UsefulTools.ToMinute(Convert.ToDouble(i.time));
            Console.WriteLine("Link: " + i.link);
        }

        //Metodo per aprire una finestra nel browser con il link dato
        /// <summary>
        ///Metodo per aprire una finestra nel browser con il link dato
        /// </summary>
        /// <param name="i"></param>
        public static void Play(Song i)
        {
            Process.Start(i.link);
        }
        //Metodo per organizzare un array di canzoni alfabeticamente
        public int CompareTo(object obj)
        {
            Song otherSong = (Song)obj;
            return this.name.CompareTo(otherSong.name);
        }

    }
}
