using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class SkillSlot : Slot
    {
        [Tooltip("技能图片")]
        [SerializeField]
        private Image _skillImage;

        [Tooltip("按键文本")]
        [SerializeField]
        private Text _keyText;

        [Tooltip("可以用来拖拽的整体")]
        [SerializeField]
        private GameObject _skillGo;

        /// <summary>
        /// 这个格子的技能
        /// </summary>
        public CharacterSkill Skill { get => Manager.Character.GetSkill(Index); }

        /// <summary>
        /// 可以用来拖拽的整体
        /// </summary>
        public GameObject SkillGo { get => _skillGo; }

        /// <summary>
        /// 槽位
        /// </summary>
        public int Index { get => transform.GetSiblingIndex(); }

        /// <summary>
        /// 所属的管理者
        /// </summary>
        public new SkillPanel Manager { get => (SkillPanel)base.Manager; }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();

            if (Skill == null)
            {
                _skillImage.sprite = null;
                _skillGo.SetActive(false);
            }
            else
            {
                _skillGo.SetActive(true);

                Sprite icon = Resources.Load<Sprite>(Skill.IconPath);
                _skillImage.sprite = icon;
            }
        }
    }
}