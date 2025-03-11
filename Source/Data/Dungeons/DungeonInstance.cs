using Source.Triggers.Base;
using System;
using WCSharp.Api;

namespace Source.Data.Dungeons
{
    public abstract class DungeonInstance : TriggerInstance
    {

        public abstract DungeonData GetDungeonData();
    }
}
