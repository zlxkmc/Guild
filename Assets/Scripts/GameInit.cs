
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
            GameConfig.Init();
            ResManager.Init();
            GameData.Init();
            SceneManager.LoadScene("Demo1");
        }
    }
}

