using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class titlescreenmanager : MonoBehaviour
{
    public void StartNetworkAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }
}
