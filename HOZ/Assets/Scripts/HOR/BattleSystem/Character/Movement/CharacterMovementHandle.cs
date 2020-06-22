using System.Collections.Generic;
using HOR.BattleSystem.Character.Movement.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Movement
{
    public class CharacterMovementHandle
    {
        public CharacterController controller;
        private Vector3 moveDir;
        private Vector3 oldMoveDir;
        private Vector3 rotateDir;
        private bool isLockFacing;
        private bool isDash;
        private bool isRun;
        private List<Collider> colls = new List<Collider>();

        public CharacterMovementHandle(CharacterController controller)
        {
            this.controller = controller;
        }

        #region Runtime

        public void UpdateInput(Vector3 moveDir, Vector3 facingDir)
        {
            if (isDash)
                return;
            
            this.moveDir = moveDir;
            this.isRun = this.moveDir.magnitude > 0;
            this.oldMoveDir = moveDir != Vector3.zero ? moveDir : oldMoveDir;

            if (facingDir == Vector3.up)
            {
                this.rotateDir = Vector3.up;
                this.isLockFacing = false;
            }
            else
            {
                this.rotateDir = facingDir;
                this.isLockFacing = true;
            }
        }

        public void UpdateRotate(float speed)
        {
            if (isLockFacing || moveDir == Vector3.zero)
                return;

            Quaternion q = Quaternion.LookRotation(moveDir, Vector3.up);
            controller.transform.rotation =
                Quaternion.RotateTowards(controller.transform.rotation, q, speed * Time.deltaTime);
        }

        public void UpdateRun(Vector3 pos)
        {
            if (!isDash && isRun)
                controller.Move(pos);
        }

        public void UpdateDash(float vel, bool trigger)
        {
            if (isDash)
            {
                if (trigger)
                {
                    Collider[] colls = Physics.OverlapSphere(controller.transform.position, controller.radius);
                    foreach (var c in colls)
                        if (c.GetComponent<Collider>() != null)
                            c.GetComponent<Collider>().isTrigger = true;

                    this.colls.AddRange(colls);
                }

                controller.Move(oldMoveDir * vel);
            }
        }

        #endregion

        #region Function

        public void Dash()
        {
            this.isDash = true;
/*            this.controller.GetComponent<MeshRenderer>().enabled = false;*/
        }

        public void DashRelease()
        {
            this.isDash = false;
            foreach (var c in colls)
            {
                if (c.GetComponent<Collider>() != null)
                    c.GetComponent<Collider>().isTrigger = false;
            }

/*            this.controller.GetComponent<MeshRenderer>().enabled = true;*/
            colls.Clear();
        }

        #endregion

        #region Getters

        public Vector3 Facing => rotateDir;
        public Vector3 Direction => moveDir;
        public Vector3 Position => controller.transform.position;
        public float GetRadius => controller.radius;
        public bool IsDash => isDash;
        public bool IsRun => isRun;
        public bool IsLockFacing => isLockFacing;

        #endregion
    }
}