
using UnityEngine;
using Utils;

namespace Game.SkillScripts
{
    public class Huikan : BaseSkill
    {
        /// <summary>
        /// 体力花费
        /// </summary>
        private int _ppCost = 1;
        /// <summary>
        /// 距离释放者的距离
        /// </summary>
        private float _dis = 0.7f;
        /// <summary>
        /// 攻击范围大小
        /// </summary>
        private float _size = 1;

        public Huikan(Character owner, Skill skill) : base(owner, skill)
        {
            
        }

        public override bool IsCanUse()
        {
            if(Owner.Pp >= _ppCost)
            {
                return true;
            }

            return false;
        }

        public override void OnUse()
        {
            base.OnUse();
            if(IsCanUse() == false) { return; }

            Owner.CostPp(_ppCost);

            Vector2 ownerPos = Owner.transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 dir = (mousePos - ownerPos).normalized;

            GameObject skillGo = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Skill/huikan"));
            skillGo.transform.localScale = new Vector2(_size, _size);
            skillGo.transform.position = ownerPos + dir * _dis;
            Util.Trans2DLookDir(skillGo.transform, dir);
        }
    }
}
