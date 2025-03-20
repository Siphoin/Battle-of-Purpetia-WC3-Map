using Source.Models;
using Source.Triggers.Base;
using WCSharp.Api;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;

namespace Source.Triggers.DebugTriggers.Triggers
{
    public class KillAllCreepsDebugTrigger : TriggerInstance
    {
        public override trigger GetTrigger()
        {
            trigger debugTrigger = trigger.Create();
            debugTrigger.RegisterPlayerChatEvent(Player(0), "KillAllCreeps", true);
            debugTrigger.AddAction(() =>
            {
                var creepGroup = group.Create();
                GroupEnumUnitsOfPlayer(creepGroup, MapConfig.MonsterPlayer, null);

                foreach (var unit in creepGroup.ToList())
                {
                    unit.Kill();
                }

                DestroyGroup(creepGroup);
            });
            return debugTrigger;
        }
    }
}
