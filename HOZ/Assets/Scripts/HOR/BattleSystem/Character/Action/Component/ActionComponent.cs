using System.Collections.Generic;
using HOR.BattleSystem.Character.Action.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action.Component
{
    public struct ActionComponent
    {
        public ActionModel actionModel;
        private List<BaseAction> baseActions;

        public void Setup(ActionModel action)
        {
            this.actionModel = action;
            baseActions = new List<BaseAction>();
        }
        
        public void AddAction(BaseAction action)
        {
            if (!baseActions.Contains(action))
                baseActions.Add(action);
        }
        
        public void Update()
        {
            foreach (var i in baseActions)
            {
                i.Execute();
            }
        }
    }
}