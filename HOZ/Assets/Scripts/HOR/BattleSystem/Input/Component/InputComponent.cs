using System.Collections.Generic;
using HOR.BattleSystem.Character.Action;
using HOR.BattleSystem.Character.Movement;
using HOR.BattleSystem.Input.Model;
using UnityEngine;

namespace HOR.BattleSystem.Input.Component
{
    public struct InputComponent
    {
        private List<IUserInput> inputParameter;
        public CharacterMovementHandle movementHandle;
        public CharacterActionHandle actionHandle;
        private bool isPause;


        public void Setup(CharacterMovementHandle move, CharacterActionHandle action)
        {
            inputParameter = new List<IUserInput>()
            {
                new InputKeyboard()
            };
            this.movementHandle = move;
            this.actionHandle = action;
            this.isPause = false;
        }
        
        public void AddParameter(IUserInput input)
        {
            if (!inputParameter.Contains(input))
                inputParameter.Add(input);
        }
        
        public void Pause(bool pause) { this.isPause = pause; }
        
        public void Update()
        {
            if (isPause) return;

            bool isDash = false;
            bool isSkill_0 = false;
            bool isSkill_1 = false;
            bool isSkill_2 = false;
            bool isSkill_3 = false;
            Vector3 moveDir = Vector3.zero;
            Vector3 rotateDir = Vector3.up;

            foreach (var i in inputParameter)
            {
                if (i.IsInputDash()) isDash = true;
                if (i.IsInputAttack()) isSkill_0 = true;
                if (i.IsInputSkill_1()) isSkill_1 = true;
                if (i.IsInputSkill_2()) isSkill_2 = true;
                if (i.IsInputSkill_3()) isSkill_3 = true;
                
                moveDir += i.GetDirectionMove();
                rotateDir += i.GetDirectionFacing();
            }

            if (isDash) movementHandle.Dash();
            movementHandle.UpdateInput(moveDir.normalized, rotateDir.normalized);

            if (isSkill_0) actionHandle.Attack();
            if(isSkill_1) actionHandle.Skill_1();
            if(isSkill_2) actionHandle.Skill_2();
            if(isSkill_3) actionHandle.Skill_3();
        }
    }
}