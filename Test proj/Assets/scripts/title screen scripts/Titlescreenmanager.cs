using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace SG{

    public class Titlescreenmanager : MonoBehaviour
    {
        public void StartNetworkAsHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        

        public void StartNewGame()
        {
            StartCoroutine(WorldSaveGameManager.Instance.Loadnewgame());
        }
    }
}
