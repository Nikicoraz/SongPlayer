using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using WMPLib;

namespace SongPlayer
{
    /*
        Nicola del futuro qui a dire che adesso so molte piu' robe ma non ho voglia di riscrivere tutto il codice per fare delle cose
        in modo leggermente migliore come ho fatto nell'ultima funzione edit quindi vabbe'
    */

    //Enum per rendere piu' facile la modifica di certi parametri delle canzoni
    public enum SongParameter
    {
        Name,
        Author,
        Length,
        Link
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ottenimento posizioni dove salvare le canzoni

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace(@"\Roaming", @"\LocalLow") + @"\NikiIncFaGiochiDaSchifo\Canzoni";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace(@"\Roaming", @"\LocalLow") + @"\NikiIncFaGiochiDaSchifo\Canzoni\Canzoni.txt";
            //songList = Array canzoni che vengono poi visualizzate, impostato ad una lunghezza iniziale di 1 che 
            //dopo viene cambiata nella funzione ReadSongs() (output, Song)

            Song[] songList = new Song[1];

            //Codice
            //SongsList = Lista temporanea da cancellare e riscrivere ogni volta che si legge o scrive il file (output, List<string>)

            List<string> SongsList = new List<string>();
            ReadSongs(SongsList, ref songList);
            MainMethod();

            //Metodi magici per far funzionare il programma

            //Avrei semplicemente potuto tenere main ma sono stupido
            void MainMethod()
            {
                //conf = variabile che decide cosa fare (input, string)
                //Per le definizioni dei metodi guarda sotto

                Console.Write("Play a song or details or search or consecutive play or shuffle or add or remove or edit?: (p, d, s, c, sh, a, rm, e) ");
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
                    else if (conf == "e")
                    {
                        SongEditor();
                    }
                    //Questi ultimi due i metodi erano piu' complicati e servivano delle variabili in input
                    //quindi ho dovuto scrivere fuori dal metodo

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
                        RemoveSong(SongsList, songToRemove);
                        ReadSongs(SongsList, ref songList);
                        Console.WriteLine("Removed song [" + songToRemove + "]");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        MainMethod();
                    }
                    else
                    {
                        Console.WriteLine("Wrong character entered!\n--------------------------------------------------------------------------------------------");
                        MainMethod();

                    }
                }
                //Scrittura di eventuali errori

                catch (FormatException)
                {
                    Console.WriteLine("Enter a number!\n--------------------------------------------------------------------------------------------");
                    MainMethod();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error :" + e.Message);
                    Console.ReadLine();
                }
            }

            //Metodo per far partire le canzoni
            void SongPlayer()
            {
                for (int i = 0; i < songList.Length; i++)
                {
                    Console.WriteLine("|" + i + "| " + songList[i].name);
                }

                Console.Write("Select a song: ");
                int num = int.Parse(Console.ReadLine());
                Song.Play(songList[num]);
            }

            //Metodo per vedere le variabili della canzoni es. nome
            void SongDeatailer()
            {
                for (int i = 0; i < songList.Length; i++)
                {
                    Console.WriteLine(i + ": " + songList[i].name);
                }

                Console.Write("Select a song: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Song.Listen(songList[num]);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                MainMethod();
            }

            //Metodo per organizzare e cercare le canzoni
            void SongSearcher()
            {
                Console.WriteLine("SONG SEARCHER");
                Console.WriteLine("-------------");
                Console.Write("By letter or author or lenght or alphabetical order?: (l, a, le, al) ");
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
                    int num = int.Parse(Console.ReadLine());
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
                    int num = int.Parse(Console.ReadLine());
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
                            int num = int.Parse(Console.ReadLine());
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
                else if (answ == "al")
                {
                    Array.Sort(songList);
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    MainMethod();
                }
            }

            //Metodo per far suonare le canzoni in ordini
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

            //Metodo per far suonare canzoni a caso
            void SongShuffeler()
            {
                //Scelta se usare le canzoni salvate sul pc in formato mp3 o usare i link nel file delle canzoni
                Console.Write("Internet song or fisical song? (i, f) ");
                string _ = Console.ReadLine();
                if (_ == "i")
                {
                    //Sceglie un numero a caso e prende la canzone dall'array, poi aspetta per la durata
                    //Se una canzone e' stata scelta viene aggiunta ad una array e non viene ripetuta per 10 turni
                    //Questo viene fatto solo se si ha piu' di 10 canzoni
                    int[] alradyPlayedSongs = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                    System.Random random = new System.Random();
                    for (int i = 1; i > 0; i++)
                    {
                        int y = random.Next(0, songList.Length);
                        bool alreadyPlayed = false;
                        if (songList.Length > 10)
                        {
                            int el = 0;
                            foreach (int elment in alradyPlayedSongs)
                            {
                                el += 1;
                                if (elment == y)
                                {
                                    Console.WriteLine($"Skipping song {songList[y].name} because it has already been played {(i - el) % 10} songs ago!");
                                    alreadyPlayed = true;
                                    break;
                                }
                            }
                        }
                        if (alreadyPlayed){
							i--;
							continue;
						}
						
							
                        Song.Play(songList[y]);
                        Console.WriteLine("[" + i + "] " + "Now Playing: " + songList[y].name);
                        alradyPlayedSongs[(i - 1) % 10] = y;
                        Thread.Sleep(songList[y].time * 1000 + 5000);
                    }
                }
                else if (_ == "f")
                {
                    //Istanza di un media player
                    WindowsMediaPlayer wmp = new WindowsMediaPlayer();
                    //Dizionario canzoni
                    Dictionary<int, string> songs = new Dictionary<int, string>();
                    string[] files = Directory.GetFiles(folderPath+"\\Fisiche");
                    int count = 0;
                    //Aggiunta canzoni a dizionario
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Contains(".mp3"))
                        {
                            songs.Add(count, files[i]);
                            count += 1;
                        }
                    }
                    if(count == 0)
                    {
                        Console.WriteLine("No mp3 files found in %appdata%/LocalLow/NikiIncFaGiochiDaSchifo/Canzoni/Fisiche!!!!!!!");
                        MainMethod();
                    }
                    int[] alradyPlayedSongs = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                    count = 1;
                    bool skip = false;
                    //Thread scelta random canzoni e play
                    Thread t = new Thread(new ThreadStart(() =>
                    {
                        while (true)
                        {
                            try
                            {
                                skip = false;
                                System.Random random = new System.Random();
                                int y = random.Next(0, songs.Count - 1);
                                bool alreadyPlayed = false;
                                if (songs.Count > 10)
                                {
                                    int el = 0;
                                    foreach (int elment in alradyPlayedSongs)
                                    {
                                        el += 1;
                                        if (elment == y && !alreadyPlayed)
                                        {
                                            Console.WriteLine($"Skipping song {songs[y]} because it has already been played { (count - el ) % 10} songs ago!");
                                            alreadyPlayed = true;
                                            break;
                                        }
                                    }
                                }
                                if (alreadyPlayed){
									count--;
									continue;
								}
                                wmp.URL = songs[y];
                                wmp.controls.play();
                                Console.WriteLine("[" + count + "] " + "Now Playing: " + songs[y].Replace(folderPath + "\\Fisiche", "").Replace("\\", "").Replace(".mp3", ""));
                                alradyPlayedSongs[(count - 1) % 10] = y;
                                count += 1;
                                Thread.Sleep(1000);
                                /*Dovrebbe essere una barra dei progressi ma fa abbastanza casino cosi' l'ho tolta
                                 * 
                                 * new Thread(new ThreadStart(() =>
                                {
                                    for(int i = 0; i < 100;)
                                    {
                                        UsefulTools.UsefulTools.Progressbar(i, true);
                                        Console.Write($"{wmp.controls.currentPositionString} / {wmp.currentMedia.durationString}");
                                        i = Convert.ToInt32(Math.Round((wmp.controls.currentPosition / wmp.currentMedia.duration) * 100));
                                        Thread.Sleep(1000);
                                    }

                                })).Start();
                                */
                                int __ = Convert.ToInt32(wmp.controls.currentPosition / wmp.currentMedia.duration);
                                while (__ != 100 || __ > 100)
                                {
                                    __ = Convert.ToInt32((wmp.controls.currentPosition / wmp.currentMedia.duration * 100));
                                    if (skip)
                                    {
                                        break;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"{e.Message}\nStopped Thread\n-----------------------------------------------------------------");
                            }
                        }
                    }));
                    t.Start();
                    Console.WriteLine("Enter skip to skip song or v to change the volume or pause or resume");
                    while (true)
                    {
                        try
                        {
                            _ = Console.ReadLine();
                            //Mette il bool skip a true che fa break sul loop che controlla la lunghezza della canzone
                            if (_.ToLower() == "skip")
                            {
                                Console.WriteLine("Song skipped!");
                                wmp.controls.stop();
                                skip = true;
                            }
                            //Cambia il volume
                            else if(_.ToLower() == "v")
                            {
                                Console.Write("Enter a volume: ");
                                wmp.settings.volume = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Volume set to {wmp.settings.volume}%");
                            }
                            //Mette in pausa
                            else if(_.ToLower() == "pause" || _.ToLower() == "p")
                            {
                                wmp.controls.pause();
                                Console.WriteLine("Paused!");
                            }
                            //Riprende
                            else if(_.ToLower() == "resume" || _.ToLower() == "r")
                            {
                                wmp.controls.play();
                                Console.WriteLine("Resumed!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Hmmmm");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Wrong character entered! {_} is not an option!");
                    Console.WriteLine(string.Concat(Enumerable.Repeat('-', 30)));
                    MainMethod();
                }
            }

            //Metodo per cambiare certe caratteristiche di canzoni 
            void SongEditor()
            {
                //Elenco di tutte le canzoni disponibili
                for (int i = 0; i < songList.Length; i++)
                {
                    Console.WriteLine("|" + i + "| " + songList[i].name);
                }
                //Ottenimento canzone da modificare
                Console.Write("What song would you like to edit? ");
                int song = Convert.ToInt32(Console.ReadLine());
                //Ottenimento parametro da modificare
                Console.Write("What parameter would you like to edit? (n, a, t, l) ");
                SongParameter sp;
                while (true)
                {
                    try
                    {   // Avrei dovuto mettere uno switch -_- vabbe'
                        char param = Convert.ToChar(Console.ReadLine());
                        if (param == 'n')
                        {
                            sp = SongParameter.Name;
                            break;
                        }
                        else if (param == 'a')
                        {
                            sp = SongParameter.Author;
                            break;
                        }
                        else if (param == 't')
                        {
                            sp = SongParameter.Length;
                            break;
                        }
                        else if (param == 'l')
                        {
                            sp = SongParameter.Link;
                            break;
                        }
                        else
                        {
                            throw new ArithmeticException();
                        }
                    }
                    catch (ArithmeticException e)
                    {
                        Console.Write("Enter a valid option!");
                    }
                    catch (Exception e)
                    {
                        Console.Write("Enter a single character!");
                    }
                }
            // Goto per ripetere senza mettere un while true loop come sopra e ottenimento nuovo valore parametro
            Message:
                Console.Write("What do you want to change this parameter to? ");
                string wtcit = Console.ReadLine();
                if (wtcit == string.Empty) // Se il parametro e' vuoto ripeti la domanda
                {
                    goto Message;
                }
                //Funzione per cambiare i parametri
                EditSong(SongsList, songList, song, sp, wtcit);
                //Ricarica canzoni dalla lista fisica
                ReadSongs(SongsList, ref songList);
                //Torno al hub di inizio
                MainMethod();
            }

            //Metodo per aggiungere canzoni al file in .../Appdata/LocalLow/NikiIncFaGiochiDaSchifo/Canzoni/Canzoni.txt
            void AddSong(List<string> songs, string name, string author, int length, string link)
            {
                //Conversione delle canzoni in una stringa da inserire nel file
                for (int i = 0; i < songs.Count; i++)
                {
                    songs[i] = songs[i] + "-ENDSONG-\n";
                }
                string songDetails = "" + name + "," + author + "," + length + "," + link + "-ENDSONG-\n";
                songs.Add(songDetails);
                string allSongsList = string.Join("", songs);
                File.WriteAllText(@path, allSongsList);
            }

            //Metodo per leggere le canzoni dal file in .../Appdata/LocalLow/NikiIncFaGiochiDaSchifo/Canzoni/Canzoni.txt
            //e quindi aggiornarle
            void ReadSongs(List<string> songsList, ref Song[] songArray)
            {
                //Controllo se esiste il file altrimenti lo crea
                if (File.Exists(@path))
                {
                    //Riscrive la lista e usa come divisore -ENDSONG-\n; \n usato per rendere di piu' facile lettura il file
                    songsList.Clear();
                    string[] readSongs = File.ReadAllText(@path).Split(new[] { "-ENDSONG-\n" }, StringSplitOptions.None);
                    //Nell'array c'e' sempre uno spazio vuoto da rimuovere, centra col metodo di separazione
                    Array.Resize(ref readSongs, readSongs.Length - 1);
                    foreach (string s in readSongs) //Aggiunge le canzoni dell'array alla lista
                    {
                        songsList.Add(s);
                    }
                    Song[] readSongsArray = new Song[readSongs.Length]; //Creazione di array da usare per impostare l'array principale
                    for (int i = 0; i < readSongs.Length; i++)
                    {
                        string[] tempArray = new string[4];
                        tempArray = readSongs[i].Split(',');
                        Song tempSong = new Song(tempArray[0], tempArray[1], int.Parse(tempArray[2]), tempArray[3]);
                        readSongsArray[i] = tempSong;
                    }
                    songArray = readSongsArray;
                }
                else //Creazione del file e della directory
                {
                    Console.WriteLine("Song file does not exist! Creating one...");
                    System.IO.Directory.CreateDirectory(folderPath);
                    File.WriteAllText(@path, string.Empty);
                }

            }

            //Metodo per rimuovere le canzoni dal file in .../Appdata/LocalLow/NikiIncFaGiochiDaSchifo/Canzoni/Canzoni.txt
            void RemoveSong(List<string> songs, int songToRemove)
            {
                //Rimuove la canzone dalla lista temporanea e riscrive il file con le canzoni di prima
                songs.RemoveAt(songToRemove);
                for (int i = 0; i < songs.Count; i++)
                {
                    songs[i] = songs[i] + "-ENDSONG-\n";
                }
                string allSongsList = string.Join("", songs);
                File.WriteAllText(@path, allSongsList);
            }

            //Metodo per cambiare i parametri delle canzoni in .../Appdata/LocalLow/NikiIncFaGiochiDaSchifo/Canzoni/Canzoni.txt
            void EditSong(List<string> songs, Song[] songArray, int songToChange, SongParameter sp, string whatToChangeItTo)
            {
                //Se il titolo della canzone e' uguale al titolo della canzone selezionata...
                for(int i = 0; i < songs.Count; i++)
                {
                    if (songs[i].Split(',')[0] == songArray[songToChange].name)
                    {
                        //divide la canzone nelle sue 4 parti (nome, autore, lunghezza e link)
                        string[] parts = songs[i].Split(',');
                        //cambia la parte da cambiare
                        parts[(int)sp] = whatToChangeItTo;
                        //Cambia la stringa della canzone nella lista a quella con il parametro aggiornato
                        songs[i] = string.Join(",", parts);
                        break;
                    }
                }
                //Salva il file con il parametro della lista aggiornato
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
