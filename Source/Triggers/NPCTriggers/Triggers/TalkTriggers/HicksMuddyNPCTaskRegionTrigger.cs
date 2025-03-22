using Source.Data.SaveableData;
using Source.Systems;
using System;
using WCSharp.Api;
using WCSharp.SaveLoad;
using WCSharp.Shared.Data;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using Source.Data.Quests.KillQuests;
namespace Source.Triggers.NPCTriggers.Triggers.TalkTriggers
{
    public class HicksMuddyNPCTaskRegionTrigger : NPCTalkRegionTrigger
    {
        private unit PlayerUnit { get; set; }
        
        public HicksMuddyNPCTaskRegionTrigger(Rectangle region) : base(region)
        {
        }

        protected override string GetUnitName()
        {
            return "Хикс Мутный";
        }

        protected override void OnPlayerEnterRegion(unit playerUnit)
        {
            SaveData saveData = SaveContainerSystem.SaveData;
            int progress = saveData.GetAcquaintanceProgressWithNPC(Unit);
            PlayerUnit = playerUnit;
            if (progress == 0)
            {
                TurnStartDialog(playerUnit);
            }

            else if (progress == 1)
            {
                TransmissionFromUnit(Unit, "Ты все еще здесь? Выполняй задания!", 4);
            }
        }

        private void TurnStartDialog (unit playerUnit)
        {
            PauseUnitWithStand(playerUnit);
            TransmissionFromUnit(Unit, "Добро пожаловать в Пурпетию, господин авантюрист! Меня звать Хикс. Хикс Мутный, если быть точнее. Я здесь, как и вы, на службе Короны. ", 9, StartDialogPart2);
        }

        private void StartDialogPart2()
        {
            TransmissionFromUnit(Unit, "Лучшего разведчика и информатора ты нигде не найдешь, зуб даю! Хотя нет, держи свои поганые лапы подальше от моих зубов... ", 11, StartDialogPart3);
        }

        private void StartDialogPart3()
        {
            TransmissionFromUnit(Unit, "Так как наш Король тот еще жлоб, предлагаю сделку: я снабжаю вас актуальной информацией по всем проблемам Пурпетии, а ты за это будешь делиться половиной выручки что заработаешь на своих приключениях. ", 15, StartDialogPart4);
        }

        private void StartDialogPart4()
        {
            TransmissionFromUnit(Unit, "По рукам? Конечно по рукам! У тебя нет выбора! Твоя награда идет всегда через мои руки ха-ха-ха-ха!", 8, StartDialogPart5);
        }

        private void StartDialogPart5()
        {
            TransmissionFromUnit(Unit, "А теперь бери листовки с данными и с глаз долой! Беспокоить разрешаю только когда хоть чего-то добьешься, неудачник...", 9, EndStartDialog);
        }

        private void EndStartDialog()
        {
            MurlocKillQuest murlocKillQuest = new MurlocKillQuest(PlayerUnit.Owner);
            SaveData saveData = SaveContainerSystem.SaveData;
            QuestSystem.RegisterQuest(murlocKillQuest);
            saveData.SetAcquaintanceProgressWithNPC(Unit, 1);
            PauseUnit(PlayerUnit, false);
        }
    }
}
