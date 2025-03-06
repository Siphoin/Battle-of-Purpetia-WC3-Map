using Source.Models;
using Source.Triggers.Base;
using Source.Triggers.MonsterAreaSystem.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Triggers.HeroTriggers
{
    public class AIHeroTrigger : TriggerInstance
    {
        private const int _LOW_HEALTH_TO_FOUNTAIN = 150;
        private unit _attackTarget;
        private group _groupFountainsLifes;
        private bool _coomandsEnabled = true;

        #region Ability

        private Dictionary<string, string[]> _abilityList = new()
        {
            {"Мечник", new string[] {
                "Ahds",
                "AHad",
                "AHhb",
                "AHre"
            }  }
        };


        #endregion
        private unit Hero {  get; set; }
        private trigger AiTrigger { get; set; }
        private timer MainTimer { get; set; }

        private timer TimerCheckHealth { get; set; }
        public override trigger GetTrigger()
        {
            trigger newTrigger = trigger.Create();

            newTrigger.AddAction(() =>
            {
                AiTrigger = trigger.Create();
                AiTrigger.AddAction(() =>
                {
                    MainTimer = timer.Create();
                    MainTimer.Start(4, true, AICommand);

                    TimerCheckHealth = timer.Create();
                    TimerCheckHealth.Start(0.5f, true, CheckHealth);

                    PlayerUnitEvents.Register(HeroEvent.Levels, LearnSpell, Hero);

                    FindFountainsLifes();
                });
                AiTrigger.Execute();
                newTrigger.Dispose();
            });

            return newTrigger;
        }

        private void CheckHealth()
        {
            _coomandsEnabled = Hero.Life > _LOW_HEALTH_TO_FOUNTAIN;
            var currentOrder = GetUnitCurrentOrder(Hero);
            if (Hero.Life <= _LOW_HEALTH_TO_FOUNTAIN && currentOrder != Constants.ORDER_MOVE)
            {
                var fountains = _groupFountainsLifes.ToList();

                int indexTargetFountains = GetRandomInt(0, fountains.Count - 1);
                var target = fountains[indexTargetFountains];
                IssuePointOrder(Hero, "move", target.X, target.Y);
            }
        }

        private void FindFountainsLifes()
        {
            var neutralsUnits = group.Create();
            GroupEnumUnitsOfPlayer(neutralsUnits, player.NeutralPassive, null);

            _groupFountainsLifes = group.Create();

            foreach (var item in neutralsUnits.ToList())
            {
                if (GetUnitTypeId(item) == FourCC("nfoh"))
                {
                    _groupFountainsLifes.Add(item);

                    Console.WriteLine(item.Name);
                }
            }

            DestroyGroup(neutralsUnits);
        }

        private void LearnSpell()
        {
            try
            {
                var speelList = _abilityList[Hero.Name];
                int indexSpell = GetRandomInt(0, Hero.HeroLevel - 1);

                if (indexSpell > speelList.Length - 1)
                {
                    indexSpell = speelList.Length - 1;
                }


                var targetSpeel = speelList[indexSpell];
                SelectHeroSkill(Hero, FourCC(targetSpeel));
#if DEBUG
                Console.WriteLine($"Hero of AI {GetPlayerId(Hero.Owner)} learned spell {targetSpeel}");
#endif
            }
            catch
            {
            }

        }

        private void AICommand ()
        {
            if (_coomandsEnabled)
            {
                var commands = Enum.GetValues(typeof(AICommandType));

                int indexCommand = GetRandomInt(0, commands.Length - 1);

                switch (indexCommand)
                {
                    case 0:
                        AttackMonsters();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AttackMonsters()
        {
            var currentOrder = GetUnitCurrentOrder(Hero);
            if (currentOrder != Constants.ORDER_ATTACK && currentOrder != Constants.ORDER_MOVE && currentOrder != Constants.ORDER_STAND_DOWN)
            {
                var monsters = group.Create();
                GroupEnumUnitsOfPlayer(monsters, MapConfig.MonsterPlayer, null);
                var monstersList = monsters.ToList();
                int indexMonster = GetRandomInt(0, monstersList.Count - 1);
                var monster = monstersList[indexMonster];
                IssuePointOrder(Hero, "attack", monster.X, monster.Y);

                DestroyGroup(monsters);
                _attackTarget = monster;
            }
        }

        public AIHeroTrigger(unit hero)
        {
            if (hero == null)
            {
                throw new Exception("hero ai is null");
            }

            else
            {
#if DEBUG
                Console.WriteLine($"AI Setup");
#endif
            }
            Hero = hero;
            MonsterAreaSpawnTrigger.OnDropItem += MonsterAreaSpawnTrigger_OnDropItem;
        }

        private void MonsterAreaSpawnTrigger_OnDropItem(unit killer, unit unit, item item)
        {
            if (killer == Hero)
            {
#if DEBUG
                Console.WriteLine("AI Get Item");
#endif
                UnitAddItem(Hero, item);
            }
        }
    }

    public enum AICommandType
    {
        MonsterAttack,
    }
}
