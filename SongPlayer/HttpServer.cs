using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace SongPlayer
{
    class HttpServer
    {
        public static HttpListener listener;
        public string pageData;
        public bool serverRunning = false;

        public HttpServer(string pageData){
            this.pageData = pageData;
        }
        public HttpServer() { }
        public void ChangeHtml(string html)
        {
            this.pageData = html;
        }
        public async Task HandleIncomingConnections(int limit)
        {
            int currentViews = 0;
            while (serverRunning)
            {
                HttpListenerContext ctx = await listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse res = ctx.Response;
                
                if(req.Url.AbsolutePath != "/favicon.ico")
                {
                    currentViews++;
                }
                if(currentViews >= limit && limit != 0)
                {
                    serverRunning = false;
                }

                byte[] data = Encoding.UTF8.GetBytes(pageData);
                res.ContentType = "text/html";
                res.ContentEncoding = Encoding.UTF8;
                res.ContentLength64 = data.LongLength;

                await res.OutputStream.WriteAsync(data, 0, data.Length);
                res.Close();
            }
        }

        public void StartServer(string url, int limit = 0)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url + "/");
            listener.Start();

            serverRunning = true;

            Task listenTask = HandleIncomingConnections(limit);
            listenTask.GetAwaiter().GetResult();

            listener.Close();
        }

        ~HttpServer()
        {
            serverRunning = false;
        }
    }
}
