﻿using Source.Data;
using Source.Triggers.Base;
using Source.Triggers.MonsterAreaSystem.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;
using static WCSharp.Api.Common;
namespace Source.Triggers.HeroTriggers.Triggers
{
    public class AIHeroTrigger : TriggerInstance
    {
        private const int LOW_HEALTH_TO_FOUNTAIN = 75;
        private group _groupFountainsLifes;
        private bool _coomandsEnabled = true;
        private bool _onTown = true;
        private AICommandType _currentCommand;

        private static List<AIHeroTrigger> _aiList = new();
        #region Ability

        private Dictionary<string, string[]> _abilityList = new()
        {
            {"Мечник", new string[] {
                "AHds",
                "AHad",
                "AHhb",
                "AHre"
            }  },

               {"Магистр", new string[] {
                "AHbz",
                "AHwe",
                "AHhab",
                "AHmt"
            }  },

               {"Вампир", new string[] {
                "AUavl",
                "AUcs",
                "AUs",
                "AUin"
            }  },

               {"Самурай", new string[] {
                "ABlm:Ablo",
                "AOwk",
                "AOcr",
                "AOww"
            }  },
        };


        #endregion


        private unit Hero { get; set; }
        private trigger AiTrigger { get; set; }
        public timer MainTimer { get; private set; }

        public timer TimerCheckHealth { get; private set; }
        public bool CoomandsEnabled { get => _coomandsEnabled; set => _coomandsEnabled = value; }

        public override trigger GetTrigger()
        {
            trigger newTrigger = trigger.Create();

            newTrigger.AddAction(() =>
            {
                AiTrigger = trigger.Create();
                AiTrigger.AddAction(() =>
                {
                    MainTimer = timer.Create();
                    MainTimer.Start(7, true, AICommand);

                    TimerCheckHealth = timer.Create();
                    TimerCheckHealth.Start(1, true, CheckHealth);

                    PlayerUnitEvents.Register(HeroEvent.Levels, LearnSpell, Hero);
                    SetupControlCommands();

                    LearnSpell();

                    Hero.Owner.Name = NickNameGenerator.GenerateNickName();
                    Hero.HeroName = Hero.Owner.Name;
                    FindFountainsLifes();
                    _aiList.Add(this);



                });
                AiTrigger.Execute();
                DestroyTrigger(newTrigger);
            });

            return newTrigger;
        }

        private void SetupControlCommands()
        {
            trigger enterTownTrigger = trigger.Create();

            enterTownTrigger.RegisterEnterRegion(Regions.NoViolanceAreaTown1.Region);

            enterTownTrigger.AddAction(() =>
            {
                _onTown = true;
                _coomandsEnabled = true;
            });

            trigger exitTownTrigger = trigger.Create();

            exitTownTrigger.RegisterLeaveRegion(Regions.NoViolanceAreaTown1.Region);

            exitTownTrigger.AddAction(() =>
            {
                _onTown = false;
                _coomandsEnabled = true;
            });

            trigger enterArenaTrigger = trigger.Create();

            enterArenaTrigger.RegisterEnterRegion(Regions.ArenaRegion.Region);

            enterArenaTrigger.AddAction(() =>
            {
                _coomandsEnabled = false;
                TimerCheckHealth.Pause();
            });

            trigger exitArenaTrigger = trigger.Create();

            exitArenaTrigger.RegisterLeaveRegion(Regions.ArenaRegion.Region);

            exitArenaTrigger.AddAction(() =>
            {
                _coomandsEnabled = true;
                TimerCheckHealth.Resume();
            });
        }

        private void CheckHealth()
        {
            _coomandsEnabled = Hero.Life > LOW_HEALTH_TO_FOUNTAIN;
            var currentOrder = GetUnitCurrentOrder(Hero);
            if (Hero.Life <= LOW_HEALTH_TO_FOUNTAIN && currentOrder != Constants.ORDER_MOVE)
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
                ability ability = BlzGetUnitAbility(Hero, FourCC(targetSpeel));
                if (ability.RequiredLevel > Hero.HeroLevel)
                {
                    LearnSpell();
                    return;
                }
                SelectHeroSkill(Hero, FourCC(targetSpeel));
#if DEBUG
                Console.WriteLine($"Hero of AI {GetPlayerId(Hero.Owner)} learned spell {targetSpeel}");
#endif
            }
            catch
            {
            }

        }

        private void AICommand()
        {
            if (_coomandsEnabled)
            {
                var commands = (AICommandType[])Enum.GetValues(typeof(AICommandType));

                int indexCommand = GetRandomInt(0, commands.Length - 1);

                switch (indexCommand)
                {
                    case 0:
                        AttackMonsters();
                        break;
                }

                _currentCommand = commands[indexCommand];

#if DEBUG
                Console.WriteLine($"AI {Hero.Owner.Id} set command {_currentCommand}");
#endif
            }
        }

        private void AttackMonsters()
        {
            var currentOrder = GetUnitCurrentOrder(Hero);
            if (currentOrder != Constants.ORDER_ATTACK && currentOrder != Constants.ORDER_MOVE && currentOrder != Constants.ORDER_STAND_DOWN)
            {
                AttackRandomMonster();
            }
        }
        private void AttackRandomMonster()
        {
            var areas = MonsterAreaSpawningDataContainer.GetData().Where(x => x.Level <= Hero.Level).ToArray();
            var indexPoint = GetRandomInt(0, areas.Length - 1);
            var area = areas[indexPoint];
            var point = area.Region.GetRandomPoint();
            IssuePointOrder(Hero, "attack", point.X, point.Y);
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

        public static AIHeroTrigger GetAI(unit hero)
        {
            AIHeroTrigger trigger = null;
            for (int i = 0; i < _aiList.Count; i++)
            {
                var targetTrrigger = _aiList[i];
                if (targetTrrigger.Hero == hero)
                {
                    trigger = targetTrrigger;
                    break;
                }
            }

            return trigger;
        }

        public static bool ContainsHero(unit hero)
        {
            return _aiList.Any(ai => ai.Hero == hero);
        }
    }

    public enum AICommandType
    {
        MonsterAttack,
    }
}
