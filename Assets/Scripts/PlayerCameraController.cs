using Utils.Singleton;
using UnityEngine;

namespace Game
{
    public class PlayerCameraController : MonoSingleton<PlayerCameraController>
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private float _followSpeed = 10;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector2 pos = Vector2.Lerp(transform.position, _player.transform.position, Time.deltaTime * _followSpeed);

            transform.position = new Vector3(pos.x, pos.y, -10);
        }
    }
}





