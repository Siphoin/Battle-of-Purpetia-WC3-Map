dungeonWindowSelectBackrop = nil 
TriggerdungeonWindowSelectBackrop = nil 
dungeonWindowSelectInfoBackrop = nil 
TriggerdungeonWindowSelectInfoBackrop = nil 
buttonExit = nil 
BackdropbuttonExit = nil 
TriggerbuttonExit = nil 
dungeonElementSelect = nil 
BackdropdungeonElementSelect = nil 
TriggerdungeonElementSelect = nil 
WindowSelectLabelBackrop = nil 
TriggerWindowSelectLabelBackrop = nil 
WindowSelectSelectButtonBackrop = nil 
BackdropWindowSelectSelectButtonBackrop = nil 
TriggerWindowSelectSelectButtonBackrop = nil 
WindowSelectDungeonIconBackrop = nil 
TriggerWindowSelectDungeonIconBackrop = nil 
dungeonWindowSelectNameDungeonText = nil 
TriggerdungeonWindowSelectNameDungeonText = nil 
dungeonDescriptionText = nil 
TriggerdungeonDescriptionText = nil 
dungeonElementSelectIcon = nil 
TriggerdungeonElementSelectIcon = nil 
dungeonElementSelectNameText = nil 
TriggerdungeonElementSelectNameText = nil 
dungeonIcon = nil 
TriggerdungeonIcon = nil 
dungeonElementSelectOutline = nil 
TriggerdungeonElementSelectOutline = nil 
labelText = nil 
TriggerlabelText = nil 
WindowSelectSelectButtonBackropText = nil 
TriggerWindowSelectSelectButtonBackropText = nil 
REFORGEDUIMAKER = {}
REFORGEDUIMAKER.buttonExitFunc = function() 
BlzFrameSetEnable(buttonExit, false) 
BlzFrameSetEnable(buttonExit, true) 
end 
 
REFORGEDUIMAKER.dungeonElementSelectFunc = function() 
BlzFrameSetEnable(dungeonElementSelect, false) 
BlzFrameSetEnable(dungeonElementSelect, true) 
end 
 
REFORGEDUIMAKER.WindowSelectSelectButtonBackropFunc = function() 
BlzFrameSetEnable(WindowSelectSelectButtonBackrop, false) 
BlzFrameSetEnable(WindowSelectSelectButtonBackrop, true) 
end 
 
REFORGEDUIMAKER.Initialize = function()


dungeonWindowSelectBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1)
BlzFrameSetAbsPoint(dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.0236700, 0.528970)
BlzFrameSetAbsPoint(dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.802020, 0.0181900)
BlzFrameSetTexture(dungeonWindowSelectBackrop, "UI/dungeonWindowSelectBackrop.blp", 0, true)

dungeonWindowSelectInfoBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectBackrop, "", 1)
BlzFrameSetPoint(dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.36740, -0.038660)
BlzFrameSetPoint(dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.080950, 0.055380)
BlzFrameSetTexture(dungeonWindowSelectInfoBackrop, "UI/dungeonWindowSelectInfoBackrop.blp", 0, true)

buttonExit = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectBackrop, 0, 0)
BlzFrameSetPoint(buttonExit, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.66667, -0.024010)
BlzFrameSetPoint(buttonExit, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.051380, 0.41874)

BackdropbuttonExit = BlzCreateFrameByType("BACKDROP", "BackdropbuttonExit", buttonExit, "", 0)
BlzFrameSetAllPoints(BackdropbuttonExit, buttonExit)
BlzFrameSetTexture(BackdropbuttonExit, "UI/dungeonWindowSelectExitButton.blp", 0, true)
TriggerbuttonExit = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerbuttonExit, buttonExit, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerbuttonExit, REFORGEDUIMAKER.buttonExitFunc) 

dungeonElementSelect = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectBackrop, 0, 0)
BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.069230, -0.051510)
BlzFrameSetPoint(dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.39532, 0.35885)

BackdropdungeonElementSelect = BlzCreateFrameByType("BACKDROP", "BackdropdungeonElementSelect", dungeonElementSelect, "", 0)
BlzFrameSetAllPoints(BackdropdungeonElementSelect, dungeonElementSelect)
BlzFrameSetTexture(BackdropdungeonElementSelect, "UI/dungeonElementSelect.blp", 0, true)
TriggerdungeonElementSelect = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerdungeonElementSelect, dungeonElementSelect, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerdungeonElementSelect, REFORGEDUIMAKER.dungeonElementSelectFunc) 

WindowSelectLabelBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectBackrop, "", 1)
BlzFrameSetPoint(WindowSelectLabelBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectBackrop, FRAMEPOINT_TOPLEFT, 0.19096, 0.026160)
BlzFrameSetPoint(WindowSelectLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.23339, 0.46694)
BlzFrameSetTexture(WindowSelectLabelBackrop, "dungeonWindowSelectLabelBackrop.png", 0, true)

WindowSelectSelectButtonBackrop = BlzCreateFrame("IconButtonTemplate", dungeonWindowSelectInfoBackrop, 0, 0)
BlzFrameSetPoint(WindowSelectSelectButtonBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.018160, -0.30763)
BlzFrameSetPoint(WindowSelectSelectButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.15184, 0.019110)

BackdropWindowSelectSelectButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropWindowSelectSelectButtonBackrop", WindowSelectSelectButtonBackrop, "", 0)
BlzFrameSetAllPoints(BackdropWindowSelectSelectButtonBackrop, WindowSelectSelectButtonBackrop)
BlzFrameSetTexture(BackdropWindowSelectSelectButtonBackrop, "UI/dungeonWindowSelectSelectButtonBackrop.blp", 0, true)
TriggerWindowSelectSelectButtonBackrop = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerWindowSelectSelectButtonBackrop, WindowSelectSelectButtonBackrop, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerWindowSelectSelectButtonBackrop, REFORGEDUIMAKER.WindowSelectSelectButtonBackropFunc) 

WindowSelectDungeonIconBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowSelectInfoBackrop, "", 1)
BlzFrameSetAbsPoint(WindowSelectDungeonIconBackrop, FRAMEPOINT_TOPLEFT, 0.518050, 0.436190)
BlzFrameSetAbsPoint(WindowSelectDungeonIconBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.618050, 0.336190)
BlzFrameSetTexture(WindowSelectDungeonIconBackrop, "UI/dungeonWindowSelectDungeonIcon.blp", 0, true)

dungeonWindowSelectNameDungeonText = BlzCreateFrameByType("TEXT", "name", dungeonWindowSelectInfoBackrop, "", 0)
BlzFrameSetPoint(dungeonWindowSelectNameDungeonText, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.10103, -0.14105)
BlzFrameSetPoint(dungeonWindowSelectNameDungeonText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.048970, 0.20569)
BlzFrameSetText(dungeonWindowSelectNameDungeonText, "|cffd9dc1eКладбище Резни|r")
BlzFrameSetEnable(dungeonWindowSelectNameDungeonText, false)
BlzFrameSetScale(dungeonWindowSelectNameDungeonText, 2.29)
BlzFrameSetTextAlignment(dungeonWindowSelectNameDungeonText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT)

dungeonDescriptionText = BlzCreateFrameByType("TEXT", "name", dungeonWindowSelectInfoBackrop, "", 0)
BlzFrameSetPoint(dungeonDescriptionText, FRAMEPOINT_TOPLEFT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_TOPLEFT, 0.098520, -0.19473)
BlzFrameSetPoint(dungeonDescriptionText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowSelectInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.051480, 0.11201)
BlzFrameSetText(dungeonDescriptionText, "|cffffffffКогда-то это место звалось Склепом Забытого Рыцаря, но один из главарей культистов лич Закжаж Лидер осквернил его, воскресив самого Рыцаря и его мертвых стражей себе во служение. На этом злодеяния Закжажа не закончились: самую глубокую часть склепа он превратил в завод по производству мясных монстров, самым большим и опасным из которых является гомункул Луни.|r")
BlzFrameSetEnable(dungeonDescriptionText, false)
BlzFrameSetScale(dungeonDescriptionText, 0.901)
BlzFrameSetTextAlignment(dungeonDescriptionText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT)

dungeonElementSelectIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonElementSelect, "", 1)
BlzFrameSetAbsPoint(dungeonElementSelectIcon, FRAMEPOINT_TOPLEFT, 0.110000, 0.454800)
BlzFrameSetAbsPoint(dungeonElementSelectIcon, FRAMEPOINT_BOTTOMRIGHT, 0.170000, 0.394800)
BlzFrameSetTexture(dungeonElementSelectIcon, "ICON_DUNGEON.blp", 0, true)

dungeonElementSelectNameText = BlzCreateFrameByType("TEXT", "name", dungeonElementSelect, "", 0)
BlzFrameSetPoint(dungeonElementSelectNameText, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, 0.097100, -0.013780)
BlzFrameSetPoint(dungeonElementSelectNameText, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, -0.036700, 0.016640)
BlzFrameSetText(dungeonElementSelectNameText, "|cffffffffКладбище Резни|r")
BlzFrameSetEnable(dungeonElementSelectNameText, false)
BlzFrameSetScale(dungeonElementSelectNameText, 2.29)
BlzFrameSetTextAlignment(dungeonElementSelectNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT)

dungeonIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonElementSelect, "", 1)
BlzFrameSetPoint(dungeonIcon, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, 0.43101, -0.047650)
BlzFrameSetPoint(dungeonIcon, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, 0.20594, -0.034260)
BlzFrameSetTexture(dungeonIcon, "ICON_DUNGEON.blp", 0, true)

dungeonElementSelectOutline = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonElementSelect, "", 1)
BlzFrameSetPoint(dungeonElementSelectOutline, FRAMEPOINT_TOPLEFT, dungeonElementSelect, FRAMEPOINT_TOPLEFT, -0.0076100, 0.00054000)
BlzFrameSetPoint(dungeonElementSelectOutline, FRAMEPOINT_BOTTOMRIGHT, dungeonElementSelect, FRAMEPOINT_BOTTOMRIGHT, -0.0014100, 0.00059000)
BlzFrameSetTexture(dungeonElementSelectOutline, "UI/dungeonElementSelectOutline.blp", 0, true)

labelText = BlzCreateFrameByType("TEXT", "name", WindowSelectLabelBackrop, "", 0)
BlzFrameSetPoint(labelText, FRAMEPOINT_TOPLEFT, WindowSelectLabelBackrop, FRAMEPOINT_TOPLEFT, 0.021210, -0.0077300)
BlzFrameSetPoint(labelText, FRAMEPOINT_BOTTOMRIGHT, WindowSelectLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.0027900, 0.012270)
BlzFrameSetText(labelText, "|cffffffffРейды|r")
BlzFrameSetEnable(labelText, false)
BlzFrameSetScale(labelText, 2.43)
BlzFrameSetTextAlignment(labelText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

WindowSelectSelectButtonBackropText = BlzCreateFrameByType("TEXT", "name", WindowSelectSelectButtonBackrop, "", 0)
BlzFrameSetPoint(WindowSelectSelectButtonBackropText, FRAMEPOINT_TOPLEFT, WindowSelectSelectButtonBackrop, FRAMEPOINT_TOPLEFT, 0.013400, -0.024950)
BlzFrameSetPoint(WindowSelectSelectButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, WindowSelectSelectButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.015180, 0.025050)
BlzFrameSetText(WindowSelectSelectButtonBackropText, "|cffffffffВыбрать|r")
BlzFrameSetEnable(WindowSelectSelectButtonBackropText, false)
BlzFrameSetScale(WindowSelectSelectButtonBackropText, 1.71)
BlzFrameSetTextAlignment(WindowSelectSelectButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)
end
