using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Newtonsoft.Json;
namespace Shrine_Tutorial
{
    public class MyNetworkManager : NetworkManager
    {
        public override void OnStartServer()
        {
            Debug.Log("Server Start");
        }
        public override void OnStopServer()
        {
            Debug.Log("Server Stop");
        }
        public override void OnClientConnect()
        {
            base.OnClientConnect();
            Debug.Log("Connected To Server");
        }
        public override void OnClientDisconnect()
        {
            Debug.Log("Disconnected from Server");
        }
    }
}