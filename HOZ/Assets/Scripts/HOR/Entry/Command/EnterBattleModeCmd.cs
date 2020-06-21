using System;
using HOR.BattleSystem;
using UnityEngine;

namespace HOR.Entry.Command
{
    public class EnterBattleModeCmd : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            Service.Set(new GameObject("Battle_System").AddComponent<BattleStartup>());
        }
    }
}