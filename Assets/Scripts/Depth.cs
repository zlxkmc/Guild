using UnityEngine;

namespace Game
{
    /// <summary>
    /// 使z坐标等于point的y坐标，用point作为测试点
    /// </summary>
    public class Depth:MonoBehaviour
    {
        [SerializeField]
        private Transform _point;

        void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _point.position.y);
        }
    }
}

