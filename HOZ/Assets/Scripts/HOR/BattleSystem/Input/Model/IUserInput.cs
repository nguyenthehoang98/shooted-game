

using UnityEngine;

namespace HOR.BattleSystem.Input.Model
{
    public interface IUserInput
    {
        Vector3 GetDirectionMove();
        Vector3 GetDirectionFacing();
       
        bool IsInputMove();
        bool IsInputDash();
        bool IsInputAttack();
        bool IsInputSkill_1();
        bool IsInputSkill_2();
        bool IsInputSkill_3();
    }
}