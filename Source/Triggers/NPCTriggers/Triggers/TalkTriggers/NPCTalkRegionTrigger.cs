using Source.Triggers.Base;
using System.Linq;
using WCSharp.Api;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using System;
namespace Source.Triggers.NPCTriggers.Triggers.TalkTriggers
{
    public abstract class NPCTalkRegionTrigger : TriggerInstance
    {

        private Rectangle Region {  get; set; }
        protected unit Unit { get; private set; }

        protected NPCTalkRegionTrigger(Rectangle region)
        {
            Region = region;
            group group = group.Create();
            GroupEnumUnitsInRect(group, Region.Rect, null);

            Unit = group.ToList().Where(x => x.Name == GetUnitName()).First();
            DestroyGroup(group);

#if DEBUG
            Console.WriteLine($"Register talk region NPC: {Unit.Name}");
#endif


        }

        public override trigger GetTrigger()
        {
            trigger listener = trigger.Create();
            listener.RegisterEnterRegion(Region.Region, null);
            listener.AddAction(OnDetectEnterRegion);
            return listener;
        }

        private void OnDetectEnterRegion()
        {
            var unit = GetTriggerUnit();

            if (unit.Owner == player.LocalPlayer && unit.IsHero())
            {
                OnPlayerEnterRegion(unit);
            }
        }

        protected abstract void OnPlayerEnterRegion(unit enterUnit);
        protected abstract string GetUnitName();
        protected string GetUnitId()
        {
            return A2S(Unit.UnitType);
        }

        public override bool IsExeculableByCategory()
        {
            return false;
        }


    }
}
