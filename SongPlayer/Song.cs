using Panda_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongPlayer
{
    class Song
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
    }

}
