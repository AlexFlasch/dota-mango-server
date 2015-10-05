using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MangoServer
{
    class MangoSteamService : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string msg = string.Empty;
            string logMsg = string.Empty;

            // grab first part of request
            // everything before the first _ denotes what method should be called... maybe not very clean...
            List<string> parameters = e.Data.Split('_').ToList();
            string requestType = parameters[0];
            // we've already gotten the requestType, now remove it, so we don't have to work around it
            parameters.RemoveAt(0);

            switch (requestType)
            {
                
            }
        }
    }
}
