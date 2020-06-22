using HOR.Entry.Signal;
using UnityEngine;

namespace HOR.Entry.Start
{
    sealed class StartCommand : strange.extensions.command.impl.Command
    { 
        [Inject] public InitDataManagerSignal InitDataManagerSignal { get; set; }
        [Inject] public InitDefaultSystemSignal InitDefaultSystemSignal { get; set; }
        
        public override void Execute()
        {
            Debug.Log("StartCommand::Execute");
            InitDefaultSystemSignal.Dispatch();
            InitDataManagerSignal.Dispatch();
        }
    }
}