using System;
using UnityEngine;

namespace HOR.BattleSystem.Character.Movement.Model
{
    [Serializable]
    public class RunModel
    {
        [SerializeField] private float runSpeed;
     
        
        public RunModel(float run)
        {
            this.runSpeed = run;
        }

        
        public float RunSpeed => runSpeed;
    }
}