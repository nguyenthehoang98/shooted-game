using HOR.Entry.Signal;
using UnityEngine;

namespace HOR.Entry.Command
{
    public class InitDataManagerCmd : strange.extensions.command.impl.Command
    {
        [Inject(EntryInjectionName.ENTRY_SIGNAL_MANAGER)] 
        public SignalManager SignalManager { get; set; }
        
        
        public override void Execute()
        {
            Debug.Log("Init Data CMd");
            Service.Set(SignalManager);
            SignalManager.InitDataBattleSystemSignal.Dispatch();
        }
    }
}