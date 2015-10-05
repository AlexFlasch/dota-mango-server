using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using PortableSteam;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MangoServer
{
    class MangoMatchService : WebSocketBehavior
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
                case "getMatchHistory":
                    Console.WriteLine("Received match history request for: " + parameters[0]);
                    msg = GetMatchHistory(parameters[0]);
                    logMsg = "Sent match history response.";
                    break;

                default:
                    Console.WriteLine("An unknown request was made.");
                    break;
            }

            Send(msg);
            Console.WriteLine(logMsg);
        }

        /// <summary>
        ///     Gets the match history of a player.
        /// </summary>
        /// <param name="playerName">
        ///     Name of the player to get matches for.
        /// </param>
        /// <param name="heroId">
        ///     ID of the hero to filter matches for.
        /// </param>
        /// <param name="gameMode">
        ///     Game mode to filter matches for.
        /// </param>
        /// <returns>
        ///     Returns a JSON object serialized as a string.
        /// </returns>
        protected string GetMatchHistory(string playerName, int? heroId = null, Dota2GameMode? gameMode = null)
        {
            var matchHistoryResponse =
                SteamWebAPI.Game().Dota2()
                    .IDOTA2Match()
                    .GetMatchHistory()
                    .PlayerName(playerName)
                    .GetResponse();

            string json = JsonConvert.SerializeObject(matchHistoryResponse);

            return json;
        }
    }
}
