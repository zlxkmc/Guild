using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Character))]
    public class SkillController : MonoBehaviour
    {
        public Character Character { get => GetComponent<Character>(); }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
