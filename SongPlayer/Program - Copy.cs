using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SongPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Canzoni

            //  Lista canzoni
            Song CarnivalPhantasmOp = new Song("Carnival Phantasm OP", "Unknown", 212, "https://youtu.be/4iXenMW9nHA");
            Song AnotherHeaven = new Song("Another Heaven", "Earthmind", 303, "https://youtu.be/5iG5R66LIrk");
            Song IBegYou = new Song("I beg you", "Aimer", 270, "https://youtu.be/SVP8te7nvOo");
            Song Emiya = new Song("Emiya", "Fate Stay/Night VN", 184, "https://youtu.be/cUs8FEsDUZ4");
            Song SevenNationArmy = new Song("Seven Nation Army", "The White Stripes", 239, "https://youtu.be/0J2QdDbelmY");
            Song Rasputin = new Song("Rasputin", "Boney M.", 238, "https://youtu.be/YgGzAKP_HuM");
            Song ThisIllusion = new Song("This Illusion", "LiSA", 243, "https://youtu.be/Ag7W4SSl3fc");
            Song AldnoahZero = new Song("aLIEz Aldnoah.Zero", "Sawano Hiroyuki", 268, "https://youtu.be/wtW529XbOyU");
            Song MoreOneNight = new Song("More one night", "Lynn", 177, "https://youtu.be/UhMrJ6CncOk");
            Song TheChase = new Song("The Chase", "Static-P", 212, "https://youtu.be/FfuhNa4Bvls");
            Song ItsNotLikeILikeYou = new Song("It's Not Like I Like You", "Static-P", 286, "https://youtu.be/tOzOD-82mW0");
            Song ThePheonix = new Song("The Pheonix", "Fall Out Boy", 248, "https://youtu.be/5JqY-6q-RNA");
            Song InTheEnd = new Song("In The End", "Linkin Park", 218, "https://youtu.be/eVTXPUF4Oz4");
            Song Hero = new Song("Hero", "Skillet", 196, "https://youtu.be/uGcsIdGOuZY");
            Song INeedAHero = new Song("I Need A Hero", "Shrek", 240, "https://youtu.be/EasWdq7Njgo");
            Song Bangarang = new Song("Bangarang", "Skrillex", 216, "https://youtu.be/cR2XilcGYOo");
            Song PumpIt = new Song("Pump it", "The Black Eyed Peas", 213, "https://youtu.be/d77gTBvX0K8");
            Song Realize = new Song("Realize", "Konomi Suzuki", 243, "https://youtu.be/AwHapidVQlI");
            Song DaddyDaddyDo = new Song("Daddy Daddy Do", "Masayuki Suzuki", 254, "https://youtu.be/sNuG1Csfmgg");
            Song StayCalm = new Song("Stay Calm", "Static-P", 268, "https://youtu.be/f4H4WPE0Uuw");
            Song BubbleTea = new Song("Bubble Tea", "dark cat", 243, "https://youtu.be/7PYe57MwxPI");
            Song WhenTheDarknessComes = new Song("When The Darkness Comes", "Static-P", 148, "https://youtu.be/iNUse4EPLQY");
            Song DetectiveDetective = new Song("Detective Detective", "Static-P", 255, "https://youtu.be/us0KKywnakk");
            Song BlackRover = new Song("Black Rover", "Unknoun", 246, "https://youtu.be/AmWsVoF_vDo");
            Song ThisIsWar = new Song("This Is War", "Thirty Seconds to Mars", 329, "https://youtu.be/hMAVLXk9QWA");
            Song ATOSTYAAN = new Song("A Tale Of Six Trillion Years and a Night", "IA", 220, "https://youtu.be/EAgk-t2zzqw");
            Song ShadowIsTheLight = new Song("Shadow is the light", "THE SIXTH LIGHT", 250, "https://youtu.be/OplYMNAv0LA");
            Song ShareTheLight = new Song("Share The Light", "Run Girls Run!", 240, "https://youtu.be/X4n3vMXv_9k?t=9");
            Song MrBlueSky = new Song("Mr. Blue Sky", "ELO", 302, "https://youtu.be/wuJIqmha2Hk");
            Song TheOnlyThingTheyFearIsYou = new Song("The Only Thing They Fear Is You", "Mick Gordon", 305, "https://youtu.be/T12ygsp9Mvg");
            Song CounterAttack = new Song("Counterattack", "Unknoun", 154, "https://youtu.be/hkKjfTWBWhc");
            Song ARealLife = new Song("A Real Life", "Greek Fire", 242, "https://youtu.be/VgRoxf0b8UQ");
            Song WhoKilledUNOwen = new Song("Who Killed U.N. Owen", "Kororo Yakoh", 331, "https://youtu.be/wEwnEeq23SY");
            Song HiiroGekkaKyousainoZetsu = new Song("Hiiro Gekka Kyousai no Zetsu", "FalKKonE", 366, "https://youtu.be/yzf3fOLkD-Y");
            Song SeeVisionS = new Song("See visionS", "Toaru", 325, "https://youtu.be/4EMhgk8beT0");
            Song NoButs = new Song("No Buts!", "Toaru", 217, "https://youtu.be/JKBgncvXx0c");
            Song EmiyaIllya = new Song("Emiya Illya Theme", "Fate/Kaleid Liner Prisma Illya", 233, "https://youtu.be/jiRdixLq38o");
            Song UNOwenWasHer = new Song("UN Owen Was Her", "Touhou", 320, "https://youtu.be/8jJZA-O_B78");
            Song Zonnestraal = new Song("Zonnestraal", "MOWE", 330, "https://youtu.be/OAJR5WByEBA");

            #endregion
            //  Array  

            Song[] songList = {
                CarnivalPhantasmOp, AnotherHeaven, IBegYou, Emiya, SevenNationArmy, Rasputin, ThisIllusion, AldnoahZero, MoreOneNight, TheChase, ItsNotLikeILikeYou, ThePheonix, InTheEnd, Hero, INeedAHero,
                Bangarang, PumpIt, Realize, DaddyDaddyDo, StayCalm, BubbleTea, WhenTheDarknessComes, DetectiveDetective, BlackRover, ThisIsWar, ATOSTYAAN, ShadowIsTheLight, ShareTheLight, MrBlueSky, TheOnlyThingTheyFearIsYou,
                CounterAttack, ARealLife, WhoKilledUNOwen, HiiroGekkaKyousainoZetsu, SeeVisionS, NoButs, EmiyaIllya, UNOwenWasHer, Zonnestraal
                                };

            //Codice

            Console.Write("Play a song or details or search or consecutive play or shuffle?: (p, d, s, c, sh) ");
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
                }else if(conf == "s")
                {
                    SongSearcher();
                } else if(conf == "c")
                {
                    ConsecutiveSongPlayer();
                }else if(conf == "sh")
                {
                    SongShuffeler();
                }
                else
                {
                    Console.WriteLine("Wrong character entered!");
                    Console.ReadLine();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Enter a number!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                Console.ReadLine();
            }


            //Methods to make the magic happen

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
                Console.ReadLine();
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
            void SongShuffeler(){
                System.Random random = new System.Random();
                for(int i = -1; i < 0; )
                {
                    int y = random.Next(0, songList.Length);
                    Song.Play(songList[y]);
                    Console.WriteLine("Now Playing: " + songList[y].name);
                    Thread.Sleep(songList[y].time * 1000 + 5000);
                    
                }
            }
            
        }
    }
}
