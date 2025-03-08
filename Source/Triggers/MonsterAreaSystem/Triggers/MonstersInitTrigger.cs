using Source.Triggers.Base;
using System;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Triggers.MonsterAreaSystem.Triggers
{
    public class MonstersInitTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            var newTrigger = trigger.Create();
            newTrigger.AddAction(() =>
            {
                var monsterSlot = player.Create(11);
                monsterSlot.Color = playercolor.Brown;
                SetPlayerController(monsterSlot, MAP_CONTROL_COMPUTER);
                monsterSlot.SetState(playerstate.GivesBounty, 1);
            });
            return newTrigger;
        }
    }
}
