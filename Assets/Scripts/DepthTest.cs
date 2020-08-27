using UnityEngine;

namespace Game
{
    /// <summary>
    /// 使parent的z坐标等于point的y坐标，用point作为测试点，用parent作为应用点
    /// </summary>
    public class DepthTest:MonoBehaviour
    {
        public Transform point;
        public Transform parent;

        void Update()
        {
            parent.position = new Vector3(parent.position.x, parent.position.y, point.position.y);
        }
    }
}

