using UnityEngine;

namespace HOR.BattleSystem.Input.Model
{
    public sealed class InputKeyboard : IUserInput
    {
        public Vector3 GetDirectionMove()
        {
            return new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0, UnityEngine.Input.GetAxisRaw("Vertical"));
        }

        public Vector3 GetDirectionFacing()
        {
            return Vector3.zero; // Mouse
        }

        public bool IsInputMove()
        {
            return GetDirectionMove() != Vector3.zero;
        }

        public bool IsInputDash()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }

        public bool IsInputAttack()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);;
        }

        public bool IsInputSkill_1()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.J);
        }

        public bool IsInputSkill_2()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.K);
        }

        public bool IsInputSkill_3()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.L);
        }
    }
}