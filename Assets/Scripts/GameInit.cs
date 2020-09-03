
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameInit : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Init());
        }

        IEnumerator Init()
        {
            GameConfig.Init();
            GameData.Init();
            AsyncOperation async = SceneManager.LoadSceneAsync("Demo1", LoadSceneMode.Single);
            yield return async;
        }
    }

}

