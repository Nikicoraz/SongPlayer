using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SongPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dove salvare le canzoni

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace(@"\Roaming", @"\LocalLow") + @"\NikiIncFaGiochiDaSchifo\Canzoni\Canzoni.txt";

            //  Array  

            Song[] songList = new Song[1];

            //Codice

            List<string> SongsList = new List<string>();
            ReadSongs(SongsList, ref songList);
            MainMethod();



            //Methods to make the magic happen

            void MainMethod()
            {
                Console.Write("Play a song or details or search or consecutive play or shuffle or add or remove?: (p, d, s, c, sh, a, rm) ");
                string conf = Console.ReadLine();
                try
                {
                    if (conf == "p")
                    {
                        SongPlayer();

                    }
                    else if (conf == "d")
                    {
                        SongDeatailer();
                    }
                    else if (conf == "s")
                    {
                        SongSearcher();
                    }
                    else if (conf == "c")
                    {
                        ConsecutiveSongPlayer();
                    }
                    else if (conf == "sh")
                    {
                        SongShuffeler();
                    }
                    else if (conf == "a")
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        string name, autor, link;
                        int time;
                        Console.Write("Enter song name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter song author: ");
                        autor = Console.ReadLine();
                        Console.Write("Enter song length: ");
                        time = int.Parse(Console.ReadLine());
                        Console.Write("Enter song link: ");
                        link = Console.ReadLine();
                        AddSong(SongsList, name, autor, time, link);
                        ReadSongs(SongsList, ref songList);
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        MainMethod();
                    }
                    else if (conf == "rm")
                    {
                        for (int i = 0; i < songList.Length; i++)
                        {
                            Console.WriteLine("[" + i + "] " + songList[i].name);
                        }
                        Console.Write("Select a song to remove: ");
                        int songToRemove = int.Parse(Console.ReadLine());
                        RemoveSong(SongsList, ref songList, songToRemove);
                        ReadSongs(SongsList, ref songList);
                        Console.WriteLine("Removed song [" + songToRemove + "]");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        MainMethod();
                    }
                    else
                    {
                        Console.WriteLine("Wrong character entered!");
                        Console.ReadLine();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a number!");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error :" + e.Message);
                    Console.ReadLine();
                }
            }
            void SongPlayer()
            {
                for (int i = 0; i < songList.Length; i++)
                {
                    Console.WriteLine(i + ": " + songList[i].name);
                }

                Console.Write("Select a song: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Song.Play(songList[num]);
            }
            void SongDeatailer()
            {
                for (int i = 0; i < songList.Length; i++)
                {
                    Console.WriteLine(i + ": " + songList[i].name);
                }

                Console.Write("Select a song: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Song.Listen(songList[num]);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                MainMethod();
            }
            void SongSearcher()
            {

                Console.WriteLine("SONG SEARCHER");
                Console.WriteLine("-------------");
                Console.Write("By letter or author or lenght?: (l, a, le) ");
                string answ = Console.ReadLine();
                if (answ == "l")
                {
                    Console.Write("Enter a letter: ");
                    string letter = Console.ReadLine();
                    letter = letter.ToUpperInvariant();
                    for (int i = 0; i < songList.Length; i++)
                    {
                        if (songList[i].name.ToUpperInvariant().StartsWith(letter))
                        {
                            Console.WriteLine(i + ": " + songList[i].name);

                        }

                    }
                    Console.Write("Select a song: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Song.Play(songList[num]);
                }
                else if (answ == "a")
                {
                    Console.Write("Enter an Author: ");
                    string author = Console.ReadLine();
                    author = author.ToUpperInvariant();
                    for (int i = 0; i < songList.Length; i++)
                    {

                        if (songList[i].author.ToUpperInvariant() == author)
                        {
                            Console.WriteLine(i + ": " + songList[i].name);

                        }

                    }
                    Console.Write("Select a song: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Song.Play(songList[num]);
                }
                else if (answ == "le")
                {
                    int sec = 0;
                    Console.Write("Greater than or less then? (>, <): ");
                    char greaterOrLess = Convert.ToChar(Console.ReadLine());
                    switch (greaterOrLess)
                    {
                        case '>':
                            Console.Write("Input a Number (s): ");
                            sec = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < songList.Length; i++)
                            {

                                if (songList[i].time > sec)
                                {
                                    Console.WriteLine(i + ": " + songList[i].name);

                                }


                            }
                            Console.Write("Select a song: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Song.Play(songList[num]);
                            break;
                        case '<':
                            Console.Write("Input a Number (s): ");
                            sec = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < songList.Length; i++)
                            {

                                if (songList[i].time < sec)
                                {
                                    Console.WriteLine(i + ": " + songList[i].name);

                                }


                            }
                            Console.Write("Select a song: ");
                            num = Convert.ToInt32(Console.ReadLine());
                            Song.Play(songList[num]);
                            break;

                    }
                }
            }
            void ConsecutiveSongPlayer()
            {
                for (int i = 0; i < songList.Length; i++)
                {
                    Console.WriteLine(i + ": " + songList[i].name);
                }
                Console.Write("From which song would you like to start: (-if to go up) ");
                int answ = Convert.ToInt32(Console.ReadLine());
                if (answ >= 0)
                {
                    for (int i = answ; i < songList.Length; i++)
                    {
                        Song.Play(songList[i]);
                        Console.WriteLine("Now playing " + songList[i].name);
                        Thread.Sleep(songList[i].time * 1000 + 5000);
                    }
                }
                else if (answ < 0)
                {
                    for (int i = answ; i <= 0; i++)
                    {
                        Song.Play(songList[Math.Abs(i)]);
                        Console.WriteLine("Now playing " + songList[Math.Abs(i)].name);
                        Thread.Sleep(songList[Math.Abs(i)].time * 1000 + 5000);
                    }
                }
            }
            void SongShuffeler()
            {
                System.Random random = new System.Random();
                for (int i = 1; i > 0; i++)
                {
                    int y = random.Next(0, songList.Length);
                    Song.Play(songList[y]);
                    Console.WriteLine("[" + i + "] " + "Now Playing: " + songList[y].name);
                    Thread.Sleep(songList[y].time * 1000 + 5000);

                }
            }
            void AddSong(List<string> songs, string name, string author, int length, string link)
            {
                for (int i = 0; i < songs.Count; i++)
                {
                    songs[i] = songs[i] + "-ENDSONG-\n";
                }
                string songDetails = "" + name + "," + author + "," + length + "," + link + "-ENDSONG-\n";
                songs.Add(songDetails);
                string allSongsList = string.Join("", songs);
                File.WriteAllText(@path, allSongsList);

            }
            void ReadSongs(List<string> songsList, ref Song[] songArray)
            {
                if (File.Exists(@path))
                {
                    songsList.Clear();
                    string[] readSongs = File.ReadAllText(@path).Split(new[] { "-ENDSONG-\n" }, StringSplitOptions.None);
                    Array.Resize(ref readSongs, readSongs.Length - 1);
                    foreach (string s in readSongs)
                    {
                        songsList.Add(s);
                    }
                    Song[] readSongsArray = new Song[readSongs.Length];
                    for (int i = 0; i < readSongs.Length; i++)
                    {
                        string[] tempArray = new string[4];
                        tempArray = readSongs[i].Split(',');
                        Song tempSong = new Song(tempArray[0], tempArray[1], int.Parse(tempArray[2]), tempArray[3]);
                        readSongsArray[i] = tempSong;
                    }
                    songArray = readSongsArray;
                }
                else
                {
                    Console.WriteLine("Song file does not exist! Creating one...");
                    File.WriteAllText(@path, string.Empty);
                }

            }
            void RemoveSong(List<string> songs, ref Song[] songArray, int songToRemove)
            {
                songs.RemoveAt(songToRemove);
                for (int i = 0; i < songs.Count; i++)
                {
                    songs[i] = songs[i] + "-ENDSONG-\n";
                }
                string allSongsList = string.Join("", songs);
                File.WriteAllText(@path, allSongsList);
            }
        }
    }
}
