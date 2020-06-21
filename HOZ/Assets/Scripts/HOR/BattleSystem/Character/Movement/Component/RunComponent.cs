using System;
using HOR.BattleSystem.Character.Movement.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Movement.Component
{
    [Serializable]
    public struct RunComponent
    {
        public RunModel runModel;
        public CharacterMovementHandle movementHandle;

        public void Setup(CharacterMovementHandle characterMovement, RunModel runModel)
        {
            this.movementHandle = characterMovement;
            this.runModel = runModel;
        }

        #region Runtime


        public void Update()
        {
            Vector3 pos = Time.deltaTime * runModel.RunSpeed * movementHandle.Direction;
            movementHandle.UpdateRun(pos);
        }

        #endregion

        void Exit()
        {
        }

        bool Expired()
        {
            return false;
        }

    }
}