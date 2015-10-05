using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortableSteam;
using WebSocketSharp.Server;

namespace MangoServer
{
    class Server
    {
        private const string ADDRESS = "127.0.0.1";
        private const int PORT = 80;

        public static void Main(string[] args)
        {
            SteamWebAPI.SetGlobalKey("17205AAF215CAD06C29BA302971AD4F0");
            var server = new WebSocketServer("ws://" + ADDRESS);

            // Add all services here
            server.AddWebSocketService<MangoMatchService>("/match");

            server.Start();
            Console.WriteLine("Server Listening...");
            Console.ReadKey(true);
            server.Stop();
            Console.WriteLine("Server stopping...");
        }
    }
}
