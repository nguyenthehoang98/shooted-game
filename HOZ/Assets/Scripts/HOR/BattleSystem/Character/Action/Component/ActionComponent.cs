using System.Collections.Generic;
using HOR.BattleSystem.Character.Action.Model;

namespace HOR.BattleSystem.Character.Action.Component
{
    public struct ActionComponent
    {
        public ActionModel actionModel;
        private CharacterActionHandle actionHandle;
        private List<BaseAction> baseActions;

        public void Setup(CharacterActionHandle characterAction, ActionModel action)
        {
            this.actionModel = action;
            this.actionHandle = characterAction;
            this.actionHandle.actionModel = actionModel;
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
                i.Execute(actionHandle);
            }
        }
    }
}