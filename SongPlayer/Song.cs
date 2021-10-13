using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

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
        public const string YOUTUBE_EMBED_HTML = @"<!DOCTYPE html>
<html>
<head>
    <title>---TITLE---</title>
</head>
  <body>
    <!-- 1. The <iframe> (and video player) will replace this <div> tag. -->
    <div id=""player""></div>

    <script>
      // 2. This code loads the IFrame Player API code asynchronously.
      var tag = document.createElement('script');

        tag.src = ""https://www.youtube.com/iframe_api"";
      var firstScriptTag = document.getElementsByTagName('script')[0];
        firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

      // 3. This function creates an <iframe> (and YouTube player)
      //    after the API code downloads.
      var player;
        function onYouTubeIframeAPIReady()
        {
            player = new YT.Player('player', {
          height: '390',
          width: '640',
          videoId: '---VIDEO_ID---',
          playerVars: {
                'playsinline': 1
          },
          events:
            {
                'onReady': onPlayerReady
          }
        });
      }

    // 4. The API will call this function when the video player is ready.
    function onPlayerReady(event)
    {
        event.target.playVideo();
        setTimeout(() => {close();}, ---TIME--- + 8000);
    }
    </script>
  </body>
</html>
";

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
            Console.Write("Lenght (m): " + UsefulTools.UsefulTools.ToMinute(Convert.ToDouble(i.time)) + "\n");
            Console.WriteLine("Link: " + i.link);
        }

        //Metodo per aprire una finestra nel browser con il link dato
        /// <summary>
        ///Metodo per aprire una finestra nel browser con il link dato
        /// </summary>
        /// <param name="i"></param>
        public static Process Play(Song i)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace(@"\Roaming", @"\LocalLow") + @"\NikiIncFaGiochiDaSchifo\Canzoni\html\html_canzoni.html";
            File.WriteAllText(path, YOUTUBE_EMBED_HTML.Replace("---VIDEO_ID---", i.link.Split(new string[] { "/", "?" }, StringSplitOptions.None)[3]).Replace("---TITLE---", i.name).Replace(
                "---TIME---", (i.time * 1000).ToString()));
            try
            {
                string pythonDir = AppDomain.CurrentDomain.BaseDirectory + "\\py\\python.exe";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C start {pythonDir} -m http.server --directory C:\\Users\\nicol\\AppData\\LocalLow\\NikiIncFaGiochiDaSchifo\\Canzoni\\html 8080 & timeout -t 3 & taskkill /IM python.exe";
                process.StartInfo = startInfo;
                process.Start();
                Process _ = Process.Start("Firefox.exe", " -P \"Musica\" -new-tab localhost:8080/html_canzoni.html");
                return _;
            }
            catch
            {
                return Process.Start(i.link);
            }
            
            }
        //Metodo per organizzare un array di canzoni alfabeticamente
        public int CompareTo(object obj)
        {
            Song otherSong = (Song)obj;
            return this.name.CompareTo(otherSong.name);
        }

    }
}
