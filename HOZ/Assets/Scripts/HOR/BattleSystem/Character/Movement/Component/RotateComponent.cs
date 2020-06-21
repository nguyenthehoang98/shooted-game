using HOR.BattleSystem.Character.Movement.Model;

namespace HOR.BattleSystem.Character.Movement.Component
{
    public struct RotateComponent
    {
        public CharacterMovementHandle movementHandle;
        public RotateModel rotateModel;

        public void Setup(CharacterMovementHandle characterMovement, RotateModel rotateModel)
        {
            this.movementHandle = characterMovement;
            this.rotateModel = rotateModel;
        }

        #region RunTime

        public void Update()
        {
            movementHandle.UpdateRotate(rotateModel.RotateSpeed);
        }

        #endregion
        
        private void Exit()
        {
        }

        bool Expired()
        {
            return false;
        }

    }
}