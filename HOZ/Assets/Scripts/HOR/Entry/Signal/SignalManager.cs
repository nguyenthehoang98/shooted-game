namespace HOR.Entry.Signal
{
    public class SignalManager
    {
        [Inject] public InitDataManagerSignal InitDataManagerSignal { get; set; }
        [Inject] public InitDefaultSystemSignal InitDefaultSystemSignal { get; set; }
        [Inject] public InitDataBattleSystemSignal InitDataBattleSystemSignal { get; set; }
        [Inject] public EnterBattleModeSignal EnterBattleModeSignal { get; set; }
    }
}