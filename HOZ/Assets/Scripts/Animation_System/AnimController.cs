using System;
using CoReaction;
using HOR.BattleSystem.Character.Action.Model;
using UnityEngine;

namespace Animation_System
{
    public class AnimController : MonoBehaviour
    {
        private ReactionController reactionControl;
        
        private void Awake()
        {
          
        }

        private void Start()
        {
            CreateAction();
        }

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            reactionControl.SetFloat(ParameterID.H, input.x);
            reactionControl.SetFloat(ParameterID.V, input.z);
            reactionControl.SetBool(ParameterID.Input, input != Vector3.zero);
        }

        void CreateAction()
        {
            reactionControl = gameObject.AddComponent<ReactionController>();
            AddParameterToReactionController();
            Forward();
            Backward();
            Right();
            Left();
        }

        void Forward()
        {
            var f = new BaseReaction();
            f.AddCondition(ParameterID.H, CompareType.FloatLess, 0.1f);
            f.AddCondition(ParameterID.H, CompareType.FloatGreater, -0.1f);
            f.AddCondition(ParameterID.V, CompareType.FloatGreater, 0.9f);
            f.SetAction(() =>
            {
                Debug.Log("F");
            });
            reactionControl.AddReaction(f);
        }

        void Backward()
        {
            var b = new BaseReaction();
            b.AddCondition(ParameterID.H, CompareType.FloatLess, 0.1f);
            b.AddCondition(ParameterID.H, CompareType.FloatGreater, -0.1f);
            b.AddCondition(ParameterID.V, CompareType.FloatLess, -0.9f);
            b.SetAction(() =>
            {
                Debug.Log("B");
            });
            reactionControl.AddReaction(b);
        }

        void Right()
        {
            var r = new BaseReaction();
            r.AddCondition(ParameterID.V, CompareType.FloatLess, 0.1f);
            r.AddCondition(ParameterID.V, CompareType.FloatGreater, -0.1f);
            r.AddCondition(ParameterID.H, CompareType.FloatGreater, 0.9f);
            r.SetAction(() =>
            {
                Debug.Log("R");
            });
            reactionControl.AddReaction(r);
        }

        void Left()
        {
            var l = new BaseReaction();
            l.AddCondition(ParameterID.V, CompareType.FloatLess, 0.1f);
            l.AddCondition(ParameterID.V, CompareType.FloatGreater, -0.1f);
            l.AddCondition(ParameterID.H, CompareType.FloatLess, -0.9f);
            l.SetAction(() =>
            {
                Debug.Log("L");
            });
            reactionControl.AddReaction(l);
        }
        
        private void AddParameterToReactionController()
        {
            reactionControl.AddParameter(ParameterID.H, ParameterType.Float);
            reactionControl.AddParameter(ParameterID.V, ParameterType.Float);
            reactionControl.AddParameter(ParameterID.Input, ParameterType.Boolean);
        }
    }
    
    static class ParameterID
    {
        public const int H = 1;
        public const int V = 2;
        public const int Input = 3;
    }
}