
using Game.SkillEntity;
using UnityEngine;
using Utils;

namespace Game.SkillScripts
{
    public class Slash : SkillScript
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

        public Slash(Character owner, CharacterSkill skill) : base(owner, skill)
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

            GameObject skillGo = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/SkillEntity/KnifeLight"), Owner.transform);
            skillGo.transform.localScale = new Vector2(_size, _size);
            skillGo.transform.position = ownerPos + dir * _dis;
            skillGo.GetComponent<KnifeLight>().onAttack.AddListener(OnAttack);
            Util.Trans2DLookDir(skillGo.transform, dir);
        }

        private void OnAttack(Unit target)
        {
            if(target.TeamType != Owner.TeamType)
            {
                target.TakeDamage(Owner, Owner.Str, CharacterSkill.Id);
            }
        }
    }
}
