using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HOR.BattleSystem.Character.Movement.Model
{
    [Serializable]
    public class RotateModel
    {
        [SerializeField] private float rotateSpeed;

     
        public RotateModel(float rotateSpeed)
        {
            this.rotateSpeed = rotateSpeed;
        }

        
        public float RotateSpeed => rotateSpeed;
    }
}