using Source.Systems.WindowsSystems;
using System;
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
        private framehandle BackdropbuttonExit;
        private trigger _triggerExit;
        private framehandle dungeonElementSelect;
        private framehandle BackdropdungeonElementSelect;
        private framehandle WindowSelectLabelBackrop;
        private framehandle WindowSelectSelectButtonBackrop;
        private framehandle BackdropWindowSelectSelectButtonBackrop;
        private framehandle WindowSelectDungeonIconBackrop;
        private framehandle dungeonWindowSelectNameDungeonText;
        private framehandle dungeonDescriptionText;
        private framehandle dungeonElementSelectIcon;
        private framehandle dungeonElementSelectNameText;
        private framehandle dungeonIcon;
        private framehandle labelText;
        private framehandle WindowSelectSelectButtonBackropText;

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

            BackdropbuttonExit = BlzCreateFrameByType("BACKDROP", "BACKROP", buttonExit, "", 0);
            BlzFrameSetAllPoints(BackdropbuttonExit, buttonExit);
            BlzFrameSetTexture(BackdropbuttonExit, "UI/dungeonWindowSelectExitButton.blp", 0, true);
            _triggerExit = trigger.Create();
            _triggerExit.RegisterFrameEvent(buttonExit, FRAMEEVENT_CONTROL_CLICK);
            _triggerExit.AddAction(Destroy);


            // Создание элемента выбора подземелья
            dungeonElementSelect = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectBackrop, 0, 0);
            BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.069230f, -0.051510f);
            BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.39532f, 0.35885f);

            BackdropdungeonElementSelect = BlzCreateFrameByType("BACKDROP", "BACKROP", dungeonElementSelect, "", 0);
            BlzFrameSetAllPoints(BackdropdungeonElementSelect, dungeonElementSelect);
            BlzFrameSetTexture(BackdropdungeonElementSelect, "UI/dungeonElementSelect.blp", 0, true);

            // Создание фрейма для текста метки
            WindowSelectLabelBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectBackrop, "", 1);
            BlzFrameSetPoint(WindowSelectLabelBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.19096f, 0.026160f);
            BlzFrameSetPoint(WindowSelectLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.23339f, 0.46694f);
            BlzFrameSetTexture(WindowSelectLabelBackrop, "UI/dungeonWindowSelectLabelBackrop.blp", 0, true);

            // Создание кнопки выбора
            WindowSelectSelectButtonBackrop = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectInfoBackrop, 0, 0);
            BlzFrameSetPoint(WindowSelectSelectButtonBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.018160f, -0.30763f);
            BlzFrameSetPoint(WindowSelectSelectButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.15184f, 0.019110f);

            BackdropWindowSelectSelectButtonBackrop = BlzCreateFrameByType("BACKDROP", "BACKROP", WindowSelectSelectButtonBackrop, "", 0);
            BlzFrameSetAllPoints(BackdropWindowSelectSelectButtonBackrop, WindowSelectSelectButtonBackrop);
            BlzFrameSetTexture(BackdropWindowSelectSelectButtonBackrop, "UI/dungeonWindowSelectSelectButtonBackrop.blp", 0, true);

            // Создание иконки подземелья
            WindowSelectDungeonIconBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectInfoBackrop, "", 1);
            BlzFrameSetAbsPoint(WindowSelectDungeonIconBackrop, FRAMEPOINT_TOPLEFT, 0.518050f, 0.436190f);
            BlzFrameSetAbsPoint(WindowSelectDungeonIconBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.618050f, 0.336190f);
            BlzFrameSetTexture(WindowSelectDungeonIconBackrop, "UI/dungeonWindowSelectDungeonIcon.blp", 0, true);

            // Создание текста названия подземелья
            dungeonWindowSelectNameDungeonText = BlzCreateFrameByType("TEXT", "name", dungeonWindowSelectInfoBackrop, "", 0);
            BlzFrameSetPoint(dungeonWindowSelectNameDungeonText, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.10103f, -0.14105f);
            BlzFrameSetPoint(dungeonWindowSelectNameDungeonText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.049970f, 0.20569f);
            BlzFrameSetText(dungeonWindowSelectNameDungeonText, "|cffd9dc1eКладбище Резни|r");
            BlzFrameSetEnable(dungeonWindowSelectNameDungeonText, false);
            BlzFrameSetScale(dungeonWindowSelectNameDungeonText, 1f);
            BlzFrameSetTextAlignment(dungeonWindowSelectNameDungeonText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT);

            // Создание текста описания подземелья
            dungeonDescriptionText = BlzCreateFrameByType("TEXT", "name", dungeonWindowSelectInfoBackrop, "", 0);
            BlzFrameSetPoint(dungeonDescriptionText, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.098520f, -0.19473f);
            BlzFrameSetPoint(dungeonDescriptionText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.061480f, 0.11201f);
            BlzFrameSetText(dungeonDescriptionText, "|cffffffffКогда-то это место звалось Склепом Забытого Рыцаря, но один из главарей культистов лич Закжаж Лидер осквернил его, воскресив самого Рыцаря и его мертвых стражей себе во служение. На этом злодеяния Закжажа не закончились: самую глубокую часть склепа он превратил в завод по производству мясных монстров, самым большим и опасным из которых является гомункул Луни.|r");
            BlzFrameSetEnable(dungeonDescriptionText, false);
            BlzFrameSetScale(dungeonDescriptionText, 0.98f);
            BlzFrameSetSize(dungeonDescriptionText, 0.18f, 0.11f);
            BlzFrameSetTextAlignment(dungeonDescriptionText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT);

            // Создание иконки элемента выбора подземелья
            dungeonElementSelectIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonElementSelect, "", 1);
            BlzFrameSetAbsPoint(dungeonElementSelectIcon, FRAMEPOINT_TOPLEFT, 0.110000f, 0.454800f);
            BlzFrameSetAbsPoint(dungeonElementSelectIcon, FRAMEPOINT_BOTTOMRIGHT, 0.170000f, 0.394800f);
            BlzFrameSetTexture(dungeonElementSelectIcon, "ICON_DUNGEON.blp", 0, true);

            // Создание текста названия элемента выбора подземелья
            dungeonElementSelectNameText = BlzCreateFrameByType("TEXT", "name", dungeonElementSelect, "", 0);
            BlzFrameSetPoint(dungeonElementSelectNameText, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, 0.08f, -0.013780f);
            BlzFrameSetPoint(dungeonElementSelectNameText, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, -0.036f, 0.016640f);
            BlzFrameSetText(dungeonElementSelectNameText, "|cffffffffКладбище Резни|r");
            BlzFrameSetEnable(dungeonElementSelectNameText, false);
            BlzFrameSetScale(dungeonElementSelectNameText, 1.3f);
            BlzFrameSetSize(dungeonElementSelectNameText, 0.3f, 0.2f);
            BlzFrameSetTextAlignment(dungeonElementSelectNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT);

            // Создание иконки подземелья
            dungeonIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonElementSelect, "", 1);
            BlzFrameSetPoint(dungeonIcon, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, 0.43101f, -0.047650f);
            BlzFrameSetPoint(dungeonIcon, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, 0.20594f, -0.034260f);
            BlzFrameSetTexture(dungeonIcon, "ICON_DUNGEON.blp", 0, true);

            // Создание текста метки
            labelText = BlzCreateFrameByType("TEXT", "name", WindowSelectLabelBackrop, "", 0);
            BlzFrameSetPoint(labelText, FRAMEPOINT_TOPLEFT, WindowSelectLabelBackrop, FRAMEPOINT_TOPLEFT, 0, 0);
            BlzFrameSetPoint(labelText, FRAMEPOINT_BOTTOMRIGHT, WindowSelectLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, 0f, 0);
            BlzFrameSetText(labelText, "|cffffffffРейды|r");
            BlzFrameSetEnable(labelText, false);
            BlzFrameSetScale(labelText, 2.43f);
            BlzFrameSetTextAlignment(labelText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);

            // Создание текста кнопки выбора
            WindowSelectSelectButtonBackropText = BlzCreateFrameByType("TEXT", "name", WindowSelectSelectButtonBackrop, "", 0);
            BlzFrameSetPoint(WindowSelectSelectButtonBackropText, FRAMEPOINT_TOPLEFT, WindowSelectSelectButtonBackrop, FRAMEPOINT_TOPLEFT, 0, 0);
            BlzFrameSetPoint(WindowSelectSelectButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, WindowSelectSelectButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.001f, 0);
            BlzFrameSetText(WindowSelectSelectButtonBackropText, "|cffffffffВыбрать|r");
            BlzFrameSetEnable(WindowSelectSelectButtonBackropText, false);
            BlzFrameSetScale(WindowSelectSelectButtonBackropText, 1.7f);
            BlzFrameSetTextAlignment(WindowSelectSelectButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE);
        }

        public override void Destroy()
        {
            framehandle[] frames = new framehandle[]
            {
        dungeonWindowSelectBackrop,
        dungeonWindowSelectInfoBackrop,
        buttonExit,
        BackdropbuttonExit,
        dungeonElementSelect,
        BackdropdungeonElementSelect,
        WindowSelectLabelBackrop,
        WindowSelectSelectButtonBackrop,
        BackdropWindowSelectSelectButtonBackrop,
        WindowSelectDungeonIconBackrop,
        dungeonWindowSelectNameDungeonText,
        dungeonDescriptionText,
        dungeonElementSelectIcon,
        dungeonElementSelectNameText,
        dungeonIcon,
        labelText,
        WindowSelectSelectButtonBackropText
            };

            trigger[] triggers = new trigger[]
            {
                _triggerExit,
            };

            foreach (var frame in frames)
            {
                if (frame != null) // Проверка на null, чтобы избежать ошибок
                {
                    BlzDestroyFrame(frame);
                }
            }

            foreach (var trigger in triggers)
            {
                DestroyTrigger(trigger);
            }
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
