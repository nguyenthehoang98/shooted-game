using System.Collections;
using HOR.BattleSystem.Character.Action.Model;
using HOR.BattleSystem.Skill.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action
{
    public class CharacterActionHandle
    {
        private TypeAction typeAction;
        public ActionModel actionModel { private get; set; }
        private float timer;
        private bool isActive;

        #region Func

        public void Attack()
        {
            this.typeAction = TypeAction.Attack;
            Action(typeAction, true);
        }

        public void Skill_1()
        {
            this.typeAction = TypeAction.Skill_1;
            Action(typeAction, true);
        }
        
        public void Skill_2()
        {
            this.typeAction = TypeAction.Skill_2;
            Action(typeAction, true);
        }
        
        public void Skill_3()
        {
            this.typeAction = TypeAction.Skill_1;
            Action(typeAction, true);
        }
        
        public void ActionRelease()
        {
            // Kiem tra het hieu luc cua skill
            Action(this.typeAction, false);
        }
        
        public SkillModel GetSkill()
        {
            switch (typeAction)
            {
                case TypeAction.Skill_3:
                    if (actionModel.ActiveSkill3)
                        return actionModel.IdSkill_3;
                    return null;
                case TypeAction.Skill_2:
                    if (actionModel.ActiveSkill2)
                        return actionModel.IdSkill_2;
                    return null;
                case TypeAction.Skill_1:
                    if (actionModel.ActiveSkill1)
                        return actionModel.IdSkill_1;
                    return null;
                case TypeAction.Attack:
                    if (actionModel.Attack)
                        return actionModel.IdAttack;
                    return null;
                default: return null;
            }
        }
        
        #endregion

        private void Action(TypeAction action, bool value)
        {
            if (!value)
            {
                isActive = false;

                switch (action)
                {
                    case TypeAction.Attack:
                        actionModel.Attack = false;
                        return;
                    case TypeAction.Skill_1:
                        actionModel.ActiveSkill1 = false;
                        return;
                    case TypeAction.Skill_2:
                        actionModel.ActiveSkill2 = false;
                        return;
                    case TypeAction.Skill_3:
                        actionModel.ActiveSkill3 = false;
                        return;
                }
            }
            else
            {
                if (!isActive)
                {
                    isActive = true;
                    switch (action)
                    {
                        case TypeAction.Attack:
                            actionModel.Attack = true;
                            return;
                        case TypeAction.Skill_1:
                            actionModel.ActiveSkill1 = true;
                            return;
                        case TypeAction.Skill_2:
                            actionModel.ActiveSkill2 = true;
                            return;
                        case TypeAction.Skill_3:
                            actionModel.ActiveSkill3 = true;
                            return;
                    }
                }
            }

        }
    }
}