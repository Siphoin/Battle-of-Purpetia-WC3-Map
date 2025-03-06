using Source.Triggers.Base;
using WCSharp.Api;
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
                monsterSlot.Controller = mapcontrol.Computer;
                monsterSlot.Name = "Monsters";
                monsterSlot.SetState(playerstate.GivesBounty, 1);
            });
            return newTrigger;
        }
    }
}
