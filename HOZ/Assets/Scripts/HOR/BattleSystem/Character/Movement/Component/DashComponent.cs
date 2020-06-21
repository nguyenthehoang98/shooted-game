using HOR.BattleSystem.Character.Movement.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Movement.Component
{
    public struct DashComponent
    {
        public DashModel dashModel;
        public bool dashing;
        public EasingFunctions.Functions easing;
        private EasingFunctions.EasingFunc dashFunc;
        private CharacterMovementHandle moveHandle;
        private bool trigger;
        private float time;

        public void Setup(CharacterMovementHandle characterMovement, DashModel dashModel, bool trigger = false)
        {
            this.moveHandle = characterMovement;
            this.dashModel = dashModel;
            this.easing = dashModel.DashEasing;
            this.trigger = trigger;
            this.dashFunc = EasingFunctions.GetEasingFunctionDerivative(this.easing);
        }

        #region Runtime

        public void Update()
        {
            if (moveHandle.IsDash)
            {
                if (!dashing)
                {
                    time = dashModel.DashingTime;
                    dashing = true;
                }

                moveHandle.UpdateDash(GetSpeed() * Time.deltaTime, trigger);
                time -= Time.deltaTime;

                if (Expired() || Physics.Raycast(moveHandle.Position, moveHandle.Direction,
                        moveHandle.GetRadius/*, dashModel.LayerCollision*/)) // add layer
                {
                    Exit();
                }
            }
        }

        #endregion
        
        private void Exit()
        {
            if(Expired())
            {
                dashing = false;
                moveHandle.DashRelease();
                moveHandle.UpdateDash(0, false);
            }
        }

        bool Expired()
        {
            return time <= 0;
        }

        float GetSpeed()
        {
            float normalizedTime = (dashModel.DashDuration - time) / dashModel.DashDuration;
            float speed = dashFunc(0, dashModel.DashDistance, normalizedTime) / dashModel.DashDuration;
            return speed;
        }
    }
}