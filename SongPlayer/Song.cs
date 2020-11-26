using Panda_2;
using System;
using System.Diagnostics;

namespace SongPlayer
{
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

        public static void Listen(Song i)
        {
            Console.WriteLine("Name: " + i.name);
            Console.WriteLine("Author: " + i.author);
            Console.WriteLine("Lenght (s): " + Convert.ToString(i.time) + "s");
            Console.Write("Lenght (m): "); UsefulTools.ToMinute(Convert.ToDouble(i.time));
            Console.WriteLine("Link: " + i.link);
        }
        public static void Play(Song i)
        {
            Process.Start(i.link);
        }
        public int CompareTo(object obj)
        {
            Song otherSong = (Song)obj;

            return this.name.CompareTo(otherSong.name);
        }

    }
}
