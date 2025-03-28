using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MirrorTest.Chat
{
    public class Player : NetworkBehaviour
    {
        [SyncVar]
        public string playerName;

        public override void OnStartServer()
        {
            playerName = (string)connectionToClient.authenticationData;
            Debug.Log("Player OnStartServer");
        }

        public override void OnStartLocalPlayer()
        {
            Debug.Log("Player OnStartLocalPlayer");
        }

        public void DoSomething(string log)
        {
            Debug.Log(log);
        }
    }
}