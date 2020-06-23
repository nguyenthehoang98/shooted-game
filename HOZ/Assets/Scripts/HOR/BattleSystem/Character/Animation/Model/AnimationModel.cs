using System;
using UnityEngine;

namespace HOR.BattleSystem.Character.Animation.Model
{
    [Serializable]
    public class AnimationModel
    {
        [SerializeField] private StructAnimationCharacter structAnim;

        public AnimationModel(StructAnimationCharacter _struct)
        {
            this.structAnim = _struct;
        }

        public StructAnimationCharacter StructAnim => structAnim;
    }

    [Serializable]
    public class StructAnimationCharacter
    {
       public StructAnimation idle_1;
       public StructAnimation walk_right;
       public StructAnimation walk_left;
       public StructAnimation walk_forward;
       public StructAnimation walk_backward;
    }

    [Serializable]
    public class StructAnimation
    {
        public bool canOverride = true;
        public AnimationClip anim;
        public float speed = 1;
    }
}