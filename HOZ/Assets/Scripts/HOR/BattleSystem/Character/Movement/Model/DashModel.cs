using System;
using UnityEngine;

namespace HOR.BattleSystem.Character.Movement.Model
{
    [Serializable]
    public class DashModel
    {
        [SerializeField] private float dashDistance;
        [SerializeField] private float dashDuration;
        [SerializeField] private float dashingTime;
        [SerializeField] private EasingFunctions.Functions dashEasing;
        [SerializeField] private LayerMask layerCollision;
        

        public DashModel(float distance, float duration, float time, LayerMask layer,
            EasingFunctions.Functions func)
        {
            this.dashDistance = distance;
            this.dashDuration = duration;
            this.dashingTime = time;
/*            this.layerCollision = layer; */
            this.dashEasing = func;
        }
    
        
        public LayerMask LayerCollision => layerCollision;
        public EasingFunctions.Functions DashEasing => dashEasing;
        public float DashDistance => dashDistance;
        public float DashDuration => dashDuration;
        public float DashingTime => dashingTime;
    }
}