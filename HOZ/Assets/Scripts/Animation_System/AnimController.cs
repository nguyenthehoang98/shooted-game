using System;
using Animancer;
using CoReaction;
using UnityEngine;

namespace Animation_System
{
    [RequireComponent(typeof(AnimancerComponent))]
    public class AnimController : MonoBehaviour
    {
        public ReactionController reactionControl;
        public Vector3 input;
        [SerializeField] private AnimancerComponent animancer;
        [SerializeField] private ClipState.Transition idle;
        [SerializeField] private ClipState.Transition runF;
        [SerializeField] private ClipState.Transition runB;
        [SerializeField] private ClipState.Transition runR;
        [SerializeField] private ClipState.Transition runL;
        

        private void Start()
        {
            animancer.Play(idle);
            CreateAction();
        }

        private void Update()
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            reactionControl.SetInt(ParameterID.H, (int)input.z);
            reactionControl.SetInt(ParameterID.V, (int)input.x);
        }

        void CreateAction()
        {
            reactionControl = gameObject.AddComponent<ReactionController>();
            AddParameterToReactionController();
            Forward();
            Backward();
            Right();
            Left();
            Idle();
        }

        void Forward()
        {
            var f = new BaseReaction();
            f.AddCondition(ParameterID.H, CompareType.IntegerEqual, 1);
            f.AddCondition(ParameterID.V, CompareType.IntegerEqual, 0);
            f.SetAction(() =>
            {
                animancer.Play(runF);
                Debug.Log("F");
            });
            reactionControl.AddReaction(f);
        }

        void Backward()
        {
            var b = new BaseReaction();
            b.AddCondition(ParameterID.H, CompareType.IntegerEqual, -1);
            b.AddCondition(ParameterID.V, CompareType.IntegerEqual, 0);
            b.SetAction(() =>
            {
                animancer.Play(runB);
                Debug.Log("B");
            });
            reactionControl.AddReaction(b);
        }

        void Right()
        {
            var r = new BaseReaction();
            r.AddCondition(ParameterID.H, CompareType.IntegerEqual, 0);
            r.AddCondition(ParameterID.V, CompareType.IntegerEqual, 1);
            r.SetAction(() =>
            {
                animancer.Play(runR);
                Debug.Log("R");
            });
            reactionControl.AddReaction(r);
        }

        void Left()
        {
            var l = new BaseReaction();
            l.AddCondition(ParameterID.H, CompareType.IntegerEqual,0);
            l.AddCondition(ParameterID.V, CompareType.IntegerEqual, -1);
            l.SetAction(() =>
            {
                animancer.Play(runL);
                Debug.Log("L");
            });
            reactionControl.AddReaction(l);
        }

        void Idle()
        {
            var _idle = new BaseReaction();
            _idle.AddCondition(ParameterID.V, CompareType.IntegerEqual,0);
            _idle.AddCondition(ParameterID.H, CompareType.IntegerEqual, 0);
            _idle.SetAction(() =>
            {
                animancer.Play(idle);
            });
            reactionControl.AddReaction(_idle);
        }
        
        private void AddParameterToReactionController()
        {
            reactionControl.AddParameter(ParameterID.H, ParameterType.Integer);
            reactionControl.AddParameter(ParameterID.V, ParameterType.Integer);
        }
    }
    
    static class ParameterID
    {
        public const int H = 1;
        public const int V = 2;
    }
}