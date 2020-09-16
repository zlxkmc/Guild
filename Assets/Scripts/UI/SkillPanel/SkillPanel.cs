using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class SkillPanel : SlotManager
    {
        public override SlotManagerFlag Flag => SlotManagerFlag.SkillPanel;

        [Tooltip("槽的容器")]
        [SerializeField]
        private Transform _content;

        [Tooltip("槽")]
        [SerializeField]
        private SkillSlot _slot;

        /// <summary>
        /// 代表的角色
        /// </summary>
        public Character Character { get; set; }




        public override void Update()
        {
            base.Update();

            SkillSlot[] slots = _content.GetComponentsInChildren<SkillSlot>();
            if(slots.Length < Character.SkillCount)
            {
                for (int i = slots.Length; i < Character.SkillCount; i++)
                {
                    GameObject newSlot = Instantiate(_slot.gameObject, _content);
                    newSlot.SetActive(true);
                }
            }
            else if(slots.Length > Character.SkillCount)
            {
                for (int i = Character.SkillCount; i < slots.Length; i++)
                {
                    Destroy(slots[i].gameObject);
                }
            }
        }
    }
}