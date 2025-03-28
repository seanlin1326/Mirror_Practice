using Mirror;
using Mirror.Examples.Basic;
using Mirror.Examples.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MirrorTest.Chat
{
    public class ChatUI : NetworkBehaviour
    {
        [SerializeField] private ChatNetworkManager chatNetworkManager;
       private static string localPlayerName;
       // Server-only cross-reference of connections to player names
       internal static readonly Dictionary<NetworkConnectionToClient, string> connNames = new Dictionary<NetworkConnectionToClient, string>();
        public override void OnStartServer()
        {
           
            connNames.Clear();
        }
       
        public override void OnStartClient()
        {
            Debug.Log("On Start Client");
           
            //chatHistory.text = "";
        }

      
    }
}