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
            Debug.Log($"Player {playerName} OnStartServer");
        }

        public override void OnStartLocalPlayer()
        {
            CmdSend($"yeeeeeeeeeeee {playerName}");
            Debug.Log($"Player {playerName} OnStartLocalPlayer");
        }
        [Command(requiresAuthority = false)]
        void CmdSend(string log)
        {
            TargetRpcReceive(connectionToClient, log);
        }
        [ClientRpc]
        void RpcReceive(string message)
        {
            Debug.Log(message);
        }
        [TargetRpc]
        void TargetRpcReceive(NetworkConnection conn, string message)
        {
            Debug.Log(message);
        }
        public void DoSomething(string log)
        {
            Debug.Log(log);
        }
    }
}