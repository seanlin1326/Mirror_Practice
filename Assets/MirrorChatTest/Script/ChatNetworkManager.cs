using Mirror;
using Mirror.Examples.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MirrorTest.Chat
{
    public class ChatNetworkManager : NetworkManager
    {
        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }
        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            // remove player name from the HashSet
            //if (conn.authenticationData != null)
            //    ChatAuthenticator.playerNames.Remove((string)conn.authenticationData);

            // remove connection from Dictionary of conn > names
            //ChatUI.connNames.Remove(conn);

            base.OnServerDisconnect(conn);
        }
        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
            //LoginUI.instance.gameObject.SetActive(true);
            //LoginUI.instance.usernameInput.text = "";
            //LoginUI.instance.usernameInput.ActivateInputField();
        }
    }
}