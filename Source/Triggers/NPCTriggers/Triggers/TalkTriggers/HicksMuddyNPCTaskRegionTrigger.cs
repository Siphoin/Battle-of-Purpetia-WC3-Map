using Source.Data.SaveableData;
using Source.Systems;
using WCSharp.Api;
using WCSharp.Shared.Data;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using Source.Data.Quests.KillQuests;
using Source.Data.Quests;
using System;
using Source.Triggers.NPCTriggers.Triggers.QuestTriggers;

namespace Source.Triggers.NPCTriggers.Triggers.TalkTriggers
{
    public class HicksMuddyNPCTaskRegionTrigger : QuestNPCRegionTrigger
    {
        
        public HicksMuddyNPCTaskRegionTrigger(Rectangle region) : base(region)
        {
        }

        protected override string GetUnitName()
        {
            return "Хикс Мутный";
        }

        protected override void OnPlayerEnterRegion(unit playerUnit)
        {
            base.OnPlayerEnterRegion(playerUnit);
            SaveData saveData = SaveContainerSystem.SaveData;
            int progress = saveData.GetAcquaintanceProgressWithNPC(Unit);
            PlayerUnit = playerUnit;
            if (progress == 0)
            {
                TurnStartDialog(playerUnit);
            }

            else if (progress == 2)
            {
                TurnQuestII();
            }

            else if (progress == 4)
            {
                TuenQuestIII();
            }
        }

        private void TuenQuestIII()
        {
                CurrentQuest.GetRewards();
                SaveData saveData = SaveContainerSystem.SaveData;
                saveData.SetAcquaintanceProgressWithNPC(Unit);
            
        }

        #region Start Dialogs
        private void TurnStartDialog(unit playerUnit)
        {
            PauseUnitWithStand(playerUnit);
            TransmissionFromUnit(Unit, "Добро пожаловать в Пурпетию, авантюрист! Меня звать Хикс. Хикс Мутный, если быть точнее. Я здесь, как и вы, на службе Короны. ", 9, StartDialogPart2);
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
            var murlocKillQuest = new Hicks_MurlocKillQuest(PlayerUnit.Owner);
            SetCurrentQuest(murlocKillQuest);
            ActionBeforeTransmissionQuestDescription = () => EndStartDialog();
            TransmissionQuestDescription();
        }

        private void EndStartDialog()
        {
            TransmissionFromUnit(Unit, "А теперь бери листовку с данными первого задания и с глаз долой! Беспокоить разрешаю только когда хоть чего-то добьешься, неудачник...", 9, TurnMurlocQuest);
        }

        private void TurnMurlocQuest()
        {
            SaveData saveData = SaveContainerSystem.SaveData;
            QuestSystem.RegisterQuest(CurrentQuest);
            saveData.SetAcquaintanceProgressWithNPC(Unit, 1);
            PauseUnit(PlayerUnit, false);
        }

        private void TurnSouthUndeadQuest()
        {
            QuestSystem.RegisterQuest(CurrentQuest);
            SaveData saveData = SaveContainerSystem.SaveData;
            saveData.SetAcquaintanceProgressWithNPC(Unit);
            PauseUnit(PlayerUnit, false);
        }

        private void EndQuestIIStart()
        {
            Hicks_SouthUndeadNPCQuest southUndeadNPCQuest = new(PlayerUnit.Owner);
            SetCurrentQuest(southUndeadNPCQuest);
            ActionBeforeTransmissionQuestDescription = () => TurnSouthUndeadQuest();
            TransmissionQuestDescription();
        }


        #endregion

        #region Dialogs | Quest II
        private void TurnQuestII ()
        {
            PauseUnitWithStand(PlayerUnit);
            TransmissionFromUnit(Unit, "Ты все еще здесь? Выполняй задани... А стоп, ты выполнил, я думал ты помер.. Ладно держи свои награды... что у нас тут.. эликсир здоровья просроченный уже как 2 года и книжка какая-то, забирай..", 15, QuestIIDialogPart2);

        }

        private void QuestIIDialogPart2()
        {
            ExecuteActionFromTime(4, () => CurrentQuest.GetRewards());
            ExecuteActionFromTime(7, QuestIIDialogPart3);

        }

        private void QuestIIDialogPart3()
        {
            TransmissionFromUnit(Unit, "М-м-м... Вы только посмотрите на эти охотничье трофеи! Я уже вижу как их разделывают, жарят и... продают на сторону! Боже, храни контробанду!", 10, QuestIIDialogPart4);
        }

        private void QuestIIDialogPart4()
        {
            TransmissionFromUnit(Unit, "Надеюсь эти вкусняшки не попадутся их бывшим хозяевам... За такой улов помимо золота вы заслужили часть этих приготовленных деликатесов. Нет, щедрость тут не причем, мы просто проверяем не принесли ли вы нам ядовитых рыболюдов. Теперь вы наши дегустаторы, салаги!", 17, EndQuestIIStart);
        }
        /*
        private void QuestIIDialogPart5()
        {
            TransmissionFromUnit(Unit, "Ой, а куда же делись гости? Неужто вы их гостеприимно выпроводили сапогом под зад? Ай-ай-ай... Впрочем, так им и надо, нечего ломится без приглашения, а горы мертвецов ни один здравомыслящий не будет приглашать. Я ж правильно говорю, салага?", 12, EndQuestIIStart);
        }

        */

        protected override void OnQuestStatusChanged(QuestInstance instance, QuestStatus status)
        {
            if (CurrentQuest == instance && status == QuestStatus.Completed)
            {
                SaveData saveData = SaveContainerSystem.SaveData;
                saveData.SetAcquaintanceProgressWithNPC(Unit);
            }

            base.OnQuestStatusChanged(instance, status);
        }



        #endregion
    }
}
