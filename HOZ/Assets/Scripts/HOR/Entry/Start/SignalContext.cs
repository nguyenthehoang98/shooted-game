using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace HOR.Entry.Start
{
    class SignalContext : MVCSContext
    { 
        public SignalContext() { }
        public SignalContext(MonoBehaviour view) : base(view) { }
        public SignalContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags) { }
        public SignalContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping) { }
        
        protected override void mapBindings() {
            base.mapBindings();
            commandBinder.Bind<StartSignal>().To<StartCommand>().Once();
        }

        protected override void addCoreComponents() {
            base.addCoreComponents();

            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override void Launch() {
            injectionBinder.GetInstance<StartSignal>().Dispatch();
        }
    }
}