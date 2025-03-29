using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shrine_Tutorial
{
    public class Player : NetworkBehaviour
    {
        [SyncVar(hook = "OnHloaCountChange")]
        int holaCount = 0;

        void OnHloaCountChange(int oldValue,int newValue)
        {
            Debug.Log($"OnHloaCountChange old:{oldValue} new:{newValue}");
        }
        private void Update()
        {
            HandleMovement();
            if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Send Hola To Server");
                Hoda();
               
            }
            
        }
        
        void HandleMovement()
        {
            if (isLocalPlayer)
            {
                float moveHorizontal = Input.GetAxis("Horizontal") ;
                float moveVertical = Input.GetAxis("Vertical");
                Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical *0.1f,0);
                transform.position = transform.position + movement;
            }
        }
        [Command]

        void Hoda()
        {
            holaCount += 1;
            Debug.Log("Receive Hola from Client");
            ReplyHola();
            ReplyHolaToAll();
        }

        [TargetRpc]
        void ReplyHola()
        {
            Debug.Log("Receive From Server ReplyHola");
        }
        [ClientRpc]
        void ReplyHolaToAll()
        {
            Debug.Log("Receive From Server ReplyHolaToAll");
        }
    }
}