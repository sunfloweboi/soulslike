using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager Instance; 
        

        [SerializeField] int worldSceneIndex = 1;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public IEnumerator Loadnewgame()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
            
            yield return null;
        }

        public int GetWorldSceneIndex()
        {
            return worldSceneIndex;
        }
    }
}
