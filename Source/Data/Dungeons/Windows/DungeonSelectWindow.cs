﻿using Source.Systems.WindowsSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Data.Dungeons.Windows
{

    public class DungeonSelectWindow : WindowGUIBase
    {
        // Фреймы
        private framehandle dungeonWindowSelectBackrop;
        private framehandle dungeonWindowSelectInfoBackrop;
        private framehandle buttonExit;
        private framehandle dungeonElementSelect;
        private framehandle WindowSelectLabelBackrop;
        private framehandle WindowSelectSelectButtonBackrop;
        private framehandle WindowSelectDungeonIconBackrop;
        private framehandle dungeonWindowSelectNameDungeonText;
        private framehandle dungeonDescriptionText;
        private framehandle dungeonElementSelectIcon;
        private framehandle dungeonElementSelectNameText;
        private framehandle dungeonIcon;
        private framehandle dungeonElementSelectOutline;
        private framehandle labelText;
        private framehandle WindowSelectSelectButtonBackropText;

        // Триггеры
        private trigger buttonExitTrigger;
        private trigger dungeonElementSelectTrigger;
        private trigger selectButtonTrigger;

        public override void Show()
        {
            // Создание основного фрейма
            dungeonWindowSelectBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1);
            BlzFrameSetAbsPoint(dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.0236700f, 0.528970f);
            BlzFrameSetAbsPoint(dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.802020f, 0.0181900f);
            BlzFrameSetTexture(dungeonWindowSelectBackrop, "UI/dungeonWindowSelectBackrop.blp", 0, true);

            // Создание фрейма для информации
            dungeonWindowSelectInfoBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectBackrop, "", 1);
            BlzFrameSetPoint(dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.36740f, -0.038660f);
            BlzFrameSetPoint(dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.080950f, 0.055380f);
            BlzFrameSetTexture(dungeonWindowSelectInfoBackrop, "UI/dungeonWindowSelectInfoBackrop.blp", 0, true);

            // Создание кнопки выхода
            buttonExit = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectBackrop, 0, 0);
            BlzFrameSetPoint(buttonExit, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.66667f, -0.024010f);
            BlzFrameSetPoint(buttonExit, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.051380f, 0.41874f);
            BlzFrameSetTexture(buttonExit, "UI/dungeonWindowSelectExitButton.blp", 0, true);

            // Триггер для кнопки выхода
            buttonExitTrigger = CreateTrigger();
            BlzTriggerRegisterFrameEvent(buttonExitTrigger, buttonExit, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(buttonExitTrigger, ButtonExitFunc);

            // Создание элемента выбора подземелья
            dungeonElementSelect = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectBackrop, 0, 0);
            BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.069230f, -0.051510f);
            BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.39532f, 0.35885f);
            BlzFrameSetTexture(dungeonElementSelect, "UI/dungeonElementSelect.blp", 0, true);


            // Создание текста и других элементов
            WindowSelectLabelBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectBackrop, "", 1);
            BlzFrameSetPoint(WindowSelectLabelBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.19096f, 0.026160f);
            BlzFrameSetPoint(WindowSelectLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.23339f, 0.46694f);
            BlzFrameSetTexture(WindowSelectLabelBackrop, "dungeonWindowSelectLabelBackrop.png", 0, true);

            // Создание кнопки выбора
            WindowSelectSelectButtonBackrop = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectInfoBackrop, 0, 0);
            BlzFrameSetPoint(WindowSelectSelectButtonBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.018160f, -0.30763f);
            BlzFrameSetPoint(WindowSelectSelectButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.15184f, 0.019110f);
            BlzFrameSetTexture(WindowSelectSelectButtonBackrop, "UI/dungeonWindowSelectSelectButtonBackrop.blp", 0, true);

            // Триггер для кнопки выбора
            selectButtonTrigger = CreateTrigger();
            BlzTriggerRegisterFrameEvent(selectButtonTrigger, WindowSelectSelectButtonBackrop, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(selectButtonTrigger, SelectButtonFunc);

            // Другие элементы интерфейса
            // ...

            // Пример создания текста
            labelText = BlzCreateFrameByType("TEXT", "name", WindowSelectLabelBackrop, "", 0);
            BlzFrameSetPoint(labelText, FRAMEPOINT_TOPLEFT, WindowSelectLabelBackrop, FRAMEPOINT_TOPLEFT, 0.021210f, -0.0077300f);
            BlzFrameSetPoint(labelText, FRAMEPOINT_BOTTOMRIGHT, WindowSelectLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.0027900f, 0.012270f);
            BlzFrameSetText(labelText, "|cffffffffРейды|r");
            BlzFrameSetEnable(labelText, false);
            BlzFrameSetScale(labelText, 2.43f);
            BlzFrameSetTextAlignment(labelText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);
        }

        public override void Destroy()
        {
            // Уничтожение всех фреймов
            BlzDestroyFrame(dungeonWindowSelectBackrop);
            BlzDestroyFrame(dungeonWindowSelectInfoBackrop);
            BlzDestroyFrame(buttonExit);
            BlzDestroyFrame(dungeonElementSelect);
            BlzDestroyFrame(WindowSelectLabelBackrop);
            BlzDestroyFrame(WindowSelectSelectButtonBackrop);
            BlzDestroyFrame(WindowSelectDungeonIconBackrop);
            BlzDestroyFrame(dungeonWindowSelectNameDungeonText);
            BlzDestroyFrame(dungeonDescriptionText);
            BlzDestroyFrame(dungeonElementSelectIcon);
            BlzDestroyFrame(dungeonElementSelectNameText);
            BlzDestroyFrame(dungeonIcon);
            BlzDestroyFrame(dungeonElementSelectOutline);
            BlzDestroyFrame(labelText);
            BlzDestroyFrame(WindowSelectSelectButtonBackropText);

            // Уничтожение триггеров
            DestroyTrigger(buttonExitTrigger);
            DestroyTrigger(dungeonElementSelectTrigger);
            DestroyTrigger(selectButtonTrigger);
        }

        private void ButtonExitFunc()
        {
            // Логика при нажатии на кнопку выхода
            Console.WriteLine("Exit button clicked!");
        }

        private void DungeonElementSelectFunc()
        {
            // Логика при выборе элемента подземелья
            Console.WriteLine("Dungeon element selected!");
        }

        private void SelectButtonFunc()
        {
            // Логика при нажатии на кнопку выбора
            Console.WriteLine("Select button clicked!");
        }
    }

    public class DungeonElementFrame
    {
        private framehandle dungeonElementSelect;
        private framehandle dungeonWindowSelectNameDungeonText;
        private framehandle dungeonElementSelectNameText;
        private framehandle dungeonElementSelectOutline;
        private trigger dungeonElementSelectTrigger;

        public void Create (framehandle dungeonWindowSelectBackrop, Action selectDungeonAction)
        {
            // Создание элемента выбора подземелья
            dungeonElementSelect = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectBackrop, 0, 0);
            BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.069230f, -0.051510f);
            BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.39532f, 0.35885f);
            BlzFrameSetTexture(dungeonElementSelect, "UI/dungeonElementSelect.blp", 0, true);

            dungeonElementSelectNameText = BlzCreateFrameByType("TEXT", "name", dungeonElementSelect, "", 0);
            BlzFrameSetPoint(dungeonElementSelectNameText, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, 0.097100f, -0.013780f);
            BlzFrameSetPoint(dungeonElementSelectNameText, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, -0.036700f, 0.016640f);
            BlzFrameSetText(dungeonElementSelectNameText, "|cffffffffКладбище Резни|r");
            BlzFrameSetEnable(dungeonElementSelectNameText, false);
            BlzFrameSetScale(dungeonElementSelectNameText, 2.29f);
            BlzFrameSetTextAlignment(dungeonElementSelectNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT);

            dungeonElementSelectOutline = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonElementSelect, "", 1);
            BlzFrameSetPoint(dungeonElementSelectOutline, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, -0.0076100f, 0.00054000f);
            BlzFrameSetPoint(dungeonElementSelectOutline, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, -0.0014100f, 0.00059000f);
            BlzFrameSetTexture(dungeonElementSelectOutline, "UI/dungeonElementSelectOutline.blp", 0, true);

            // Триггер для элемента выбора подземелья
            dungeonElementSelectTrigger = CreateTrigger();
            BlzTriggerRegisterFrameEvent(dungeonElementSelectTrigger, dungeonElementSelect, FRAMEEVENT_CONTROL_CLICK);
            TriggerAddAction(dungeonElementSelectTrigger, selectDungeonAction);


        }
        public void Destroy ()
        {
            BlzDestroyFrame(dungeonElementSelect);
            BlzDestroyFrame(dungeonElementSelectOutline);
            BlzDestroyFrame(dungeonElementSelectNameText);
            DestroyTrigger(dungeonElementSelectTrigger);
        }
    }
}
