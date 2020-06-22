using System;
using CoReaction;
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
            if (Input.GetKey(KeyCode.Space))
            {
                reactionControl.SetTrigger(ParameterID.Forward);
            }
        }

        void CreateAction()
        {
            reactionControl = gameObject.AddComponent<ReactionController>();
            AddParameterToReactionController();
            AddMoveAction();
        }
        
        private void AddMoveAction()
        {
            var move = new BaseReaction();
            move.AddCondition(ParameterID.Forward, CompareType.Trigger);
            move.SetAction(Move);
            reactionControl.AddReaction(move);
        }

        private void AddParameterToReactionController()
        {
            reactionControl.AddParameter(ParameterID.Forward, ParameterType.Trigger);
        }

        void Move()
        {
            Debug.Log("Move");
            transform.position += 3 * Time.deltaTime * transform.forward;
        }
    }
    
    static class ParameterID
    {
        public const int Forward = 1;
    }
}