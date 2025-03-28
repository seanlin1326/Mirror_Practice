using Mirror;
using Mirror.Examples.Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MirrorTest.Chat
{
    public class ChatUI : NetworkBehaviour
    {
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

        private void OnPlayerJoined(NetworkConnection conn)
        {
            // 调用 TargetRpc 来将游戏状态信息传送给新加入的客户端
            TargetSendGameStateToClient(conn, "aaa");
        }
        // 使用 TargetRpc 来向特定客户端发送数据
        [TargetRpc]
        public void TargetSendGameStateToClient(NetworkConnection conn, string gameState)
        {
            // 向新加入的客户端发送游戏状态（界面更新）
            var playerUI = conn.identity.GetComponent<Player>();  // 假设玩家有一个 UI 控制脚本
            playerUI.DoSomething(gameState);
        }
    }
}