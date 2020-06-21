using HOR.Entry.Command;
using HOR.Entry.Signal;
using HOR.Entry.Start;
using UnityEngine;

namespace HOR.Entry
{
    sealed class EntryContext : SignalContext
    {
        public EntryContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping) {
        }
        
        protected override void mapBindings()
        {
            base.mapBindings();
            injectionBinder.Bind<SignalManager>().ToSingleton().CrossContext()
                .ToName(EntryInjectionName.ENTRY_SIGNAL_MANAGER);
            injectionBinder.Bind<DefaultSystem>().ToSingleton().CrossContext()
                .ToName(EntryInjectionName.ENTRY_DEFAULT_SYSTEM);
            
            // injectionBinder..
            commandBinder.Bind<InitDefaultSystemSignal>().To<InitDefaultSystemCmd>();
            commandBinder.Bind<InitDataManagerSignal>().To<InitDataManagerCmd>();
            commandBinder.Bind<InitDataBattleSystemSignal>().To<InitDataBattleSystemCmd>();
            commandBinder.Bind<EnterBattleModeSignal>().To<EnterBattleModeCmd>();

            // commandBinder...

            // mediatorBinder...

            //new Binding
        }
    }
}