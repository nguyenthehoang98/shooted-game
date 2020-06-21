namespace HOR.Entry.Command
{
    public class InitDefaultSystemCmd : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {     
            DefaultSystem defaultSystem =
            injectionBinder.GetInstance<DefaultSystem>(EntryInjectionName.ENTRY_DEFAULT_SYSTEM);
            
//            defaultSystem.AddSubSystem();
            Service.Set(defaultSystem);
        }
        
        
    }
}