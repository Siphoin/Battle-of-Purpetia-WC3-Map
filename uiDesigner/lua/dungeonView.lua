dungeonWindowBackrop = nil 
TriggerdungeonWindowBackrop = nil 
dungeonWindowListPlayersBackrop = nil 
TriggerdungeonWindowListPlayersBackrop = nil 
dungeonWindowLabelBackrop = nil 
TriggerdungeonWindowLabelBackrop = nil 
dungeonWindowInfoBackrop = nil 
TriggerdungeonWindowInfoBackrop = nil 
dungeonWndowPlayerSlotBackrop = nil 
TriggerdungeonWndowPlayerSlotBackrop = nil 
dungeonWindowLabelBackropText = nil 
TriggerdungeonWindowLabelBackropText = nil 
dungeonWindowIconBackrop = nil 
TriggerdungeonWindowIconBackrop = nil 
dungeonWindowStartButtonBackrop = nil 
BackdropdungeonWindowStartButtonBackrop = nil 
TriggerdungeonWindowStartButtonBackrop = nil 
dungeonWindowLeaveButtonBackrop = nil 
BackdropdungeonWindowLeaveButtonBackrop = nil 
TriggerdungeonWindowLeaveButtonBackrop = nil 
dungeonNameText = nil 
TriggerdungeonNameText = nil 
dungeonDescriptiionText = nil 
TriggerdungeonDescriptiionText = nil 
dungeonWindowKickPlayerButtonBackrop = nil 
BackdropdungeonWindowKickPlayerButtonBackrop = nil 
TriggerdungeonWindowKickPlayerButtonBackrop = nil 
dungeonWindowPlayerSlotNameText = nil 
TriggerdungeonWindowPlayerSlotNameText = nil 
playerHeroIcon = nil 
TriggerplayerHeroIcon = nil 
dungeonIcon = nil 
TriggerdungeonIcon = nil 
dungeonWindowStartButtonBackropText = nil 
TriggerdungeonWindowStartButtonBackropText = nil 
dungeonWindowLeaveButtonBackropText = nil 
TriggerdungeonWindowLeaveButtonBackropText = nil 
dungeonWindowKickPlayerButtonBackropText = nil 
TriggerdungeonWindowKickPlayerButtonBackropText = nil 
REFORGEDUIMAKER = {}
REFORGEDUIMAKER.dungeonWindowStartButtonBackropFunc = function() 
BlzFrameSetEnable(dungeonWindowStartButtonBackrop, false) 
BlzFrameSetEnable(dungeonWindowStartButtonBackrop, true) 
end 
 
REFORGEDUIMAKER.dungeonWindowLeaveButtonBackropFunc = function() 
BlzFrameSetEnable(dungeonWindowLeaveButtonBackrop, false) 
BlzFrameSetEnable(dungeonWindowLeaveButtonBackrop, true) 
end 
 
REFORGEDUIMAKER.dungeonWindowKickPlayerButtonBackropFunc = function() 
BlzFrameSetEnable(dungeonWindowKickPlayerButtonBackrop, false) 
BlzFrameSetEnable(dungeonWindowKickPlayerButtonBackrop, true) 
end 
 
REFORGEDUIMAKER.Initialize = function()


dungeonWindowBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1)
BlzFrameSetAbsPoint(dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.00409000, 0.574980)
BlzFrameSetAbsPoint(dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.801420, 0.000630000)
BlzFrameSetTexture(dungeonWindowBackrop, "UI/dungeonWindowBackrop", 0, true)

dungeonWindowListPlayersBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowBackrop, "", 1)
BlzFrameSetPoint(dungeonWindowListPlayersBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.042690, -0.066510)
BlzFrameSetPoint(dungeonWindowListPlayersBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.33464, 0.089430)
BlzFrameSetTexture(dungeonWindowListPlayersBackrop, "UI/dungeonWindowListPlayersBackrop", 0, true)

dungeonWindowLabelBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowBackrop, "", 1)
BlzFrameSetPoint(dungeonWindowLabelBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.036000, -0.014740)
BlzFrameSetPoint(dungeonWindowLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.55133, 0.51961)
BlzFrameSetTexture(dungeonWindowLabelBackrop, "UI/dungeonWindowLabelBackrop.blp", 0, true)

dungeonWindowInfoBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowBackrop, "", 1)
BlzFrameSetPoint(dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowBackrop, FRAMEPOINT_TOPLEFT, 0.45788, -0.070770)
BlzFrameSetPoint(dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.057360, 0.070110)
BlzFrameSetTexture(dungeonWindowInfoBackrop, "UI/dungeonWindowInfoBackrop.blp", 0, true)

dungeonWndowPlayerSlotBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowListPlayersBackrop, "", 1)
BlzFrameSetPoint(dungeonWndowPlayerSlotBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowListPlayersBackrop, FRAMEPOINT_TOPLEFT, 0.028460, -0.028720)
BlzFrameSetPoint(dungeonWndowPlayerSlotBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowListPlayersBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.029090, 0.29969)
BlzFrameSetTexture(dungeonWndowPlayerSlotBackrop, "UI/dungeonWndowPlayerSlotBackrop.blp", 0, true)

dungeonWindowLabelBackropText = BlzCreateFrameByType("TEXT", "name", dungeonWindowLabelBackrop, "", 0)
BlzFrameSetPoint(dungeonWindowLabelBackropText, FRAMEPOINT_TOPLEFT, dungeonWindowLabelBackrop, FRAMEPOINT_TOPLEFT, 0.0075300, 0.0030500)
BlzFrameSetPoint(dungeonWindowLabelBackropText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowLabelBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.012470, 0.0030500)
BlzFrameSetText(dungeonWindowLabelBackropText, "|cffffffffРейд|r")
BlzFrameSetEnable(dungeonWindowLabelBackropText, false)
BlzFrameSetScale(dungeonWindowLabelBackropText, 2.86)
BlzFrameSetTextAlignment(dungeonWindowLabelBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

dungeonWindowIconBackrop = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowInfoBackrop, "", 1)
BlzFrameSetPoint(dungeonWindowIconBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.080360, -0.039260)
BlzFrameSetPoint(dungeonWindowIconBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.081730, 0.28459)
BlzFrameSetTexture(dungeonWindowIconBackrop, "UI/dungeonWindowIconBackrop.blp", 0, true)

dungeonWindowStartButtonBackrop = BlzCreateFrame("IconButtonTemplate", dungeonWindowInfoBackrop, 0, 0)
BlzFrameSetPoint(dungeonWindowStartButtonBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.023440, -0.32683)
BlzFrameSetPoint(dungeonWindowStartButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.12865, 0.026640)

BackdropdungeonWindowStartButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropdungeonWindowStartButtonBackrop", dungeonWindowStartButtonBackrop, "", 0)
BlzFrameSetAllPoints(BackdropdungeonWindowStartButtonBackrop, dungeonWindowStartButtonBackrop)
BlzFrameSetTexture(BackdropdungeonWindowStartButtonBackrop, "UI/dungeonWindowStartButtonBackrop.blp", 0, true)
TriggerdungeonWindowStartButtonBackrop = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerdungeonWindowStartButtonBackrop, dungeonWindowStartButtonBackrop, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerdungeonWindowStartButtonBackrop, REFORGEDUIMAKER.dungeonWindowStartButtonBackropFunc) 

dungeonWindowLeaveButtonBackrop = BlzCreateFrame("IconButtonTemplate", dungeonWindowInfoBackrop, 0, 0)
BlzFrameSetPoint(dungeonWindowLeaveButtonBackrop, FRAMEPOINT_TOPLEFT, dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.13477, -0.32683)
BlzFrameSetPoint(dungeonWindowLeaveButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.017320, 0.026640)

BackdropdungeonWindowLeaveButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropdungeonWindowLeaveButtonBackrop", dungeonWindowLeaveButtonBackrop, "", 0)
BlzFrameSetAllPoints(BackdropdungeonWindowLeaveButtonBackrop, dungeonWindowLeaveButtonBackrop)
BlzFrameSetTexture(BackdropdungeonWindowLeaveButtonBackrop, "UI/dungeonWindowLeaveBackrop.blp", 0, true)
TriggerdungeonWindowLeaveButtonBackrop = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerdungeonWindowLeaveButtonBackrop, dungeonWindowLeaveButtonBackrop, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerdungeonWindowLeaveButtonBackrop, REFORGEDUIMAKER.dungeonWindowLeaveButtonBackropFunc) 

dungeonNameText = BlzCreateFrameByType("TEXT", "name", dungeonWindowInfoBackrop, "", 0)
BlzFrameSetAbsPoint(dungeonNameText, FRAMEPOINT_TOPLEFT, 0.543160, 0.348250)
BlzFrameSetAbsPoint(dungeonNameText, FRAMEPOINT_BOTTOMRIGHT, 0.663160, 0.318250)
BlzFrameSetText(dungeonNameText, "|cffFFCC00Кладбище Резни|r")
BlzFrameSetEnable(dungeonNameText, false)
BlzFrameSetScale(dungeonNameText, 1.57)
BlzFrameSetTextAlignment(dungeonNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

dungeonDescriptiionText = BlzCreateFrameByType("TEXT", "name", dungeonWindowInfoBackrop, "", 0)
BlzFrameSetPoint(dungeonDescriptiionText, FRAMEPOINT_TOPLEFT, dungeonWindowInfoBackrop, FRAMEPOINT_TOPLEFT, 0.027620, -0.15969)
BlzFrameSetPoint(dungeonDescriptiionText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowInfoBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.034470, 0.12378)
BlzFrameSetText(dungeonDescriptiionText, "|cffffffffКогда-то это место звалось Склепом Забытого Рыцаря, но один из главарей культистов лич Закжаж Лидер осквернил его, воскресив самого Рыцаря и его мертвых стражей себе во служение. На этом злодеяния Закжажа не закончились: самую глубокую часть склепа он превратил в завод по производству мясных монстров, самым большим и опасным из которых является гомункул Луни.|r")
BlzFrameSetEnable(dungeonDescriptiionText, false)
BlzFrameSetScale(dungeonDescriptiionText, 1.00)
BlzFrameSetTextAlignment(dungeonDescriptiionText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

dungeonWindowKickPlayerButtonBackrop = BlzCreateFrame("IconButtonTemplate", dungeonWndowPlayerSlotBackrop, 0, 0)
BlzFrameSetPoint(dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_TOPLEFT, dungeonWndowPlayerSlotBackrop, FRAMEPOINT_TOPLEFT, 0.26368, -0.042820)
BlzFrameSetPoint(dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, dungeonWndowPlayerSlotBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.0012300, 0.0071800)

BackdropdungeonWindowKickPlayerButtonBackrop = BlzCreateFrameByType("BACKDROP", "BackdropdungeonWindowKickPlayerButtonBackrop", dungeonWindowKickPlayerButtonBackrop, "", 0)
BlzFrameSetAllPoints(BackdropdungeonWindowKickPlayerButtonBackrop, dungeonWindowKickPlayerButtonBackrop)
BlzFrameSetTexture(BackdropdungeonWindowKickPlayerButtonBackrop, "UI/dungeonWindowKickPlayerButtonBackrop.blp", 0, true)
TriggerdungeonWindowKickPlayerButtonBackrop = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerdungeonWindowKickPlayerButtonBackrop, dungeonWindowKickPlayerButtonBackrop, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerdungeonWindowKickPlayerButtonBackrop, REFORGEDUIMAKER.dungeonWindowKickPlayerButtonBackropFunc) 

dungeonWindowPlayerSlotNameText = BlzCreateFrameByType("TEXT", "name", dungeonWndowPlayerSlotBackrop, "", 0)
BlzFrameSetPoint(dungeonWindowPlayerSlotNameText, FRAMEPOINT_TOPLEFT, dungeonWndowPlayerSlotBackrop, FRAMEPOINT_TOPLEFT, 0.027630, -0.032720)
BlzFrameSetPoint(dungeonWindowPlayerSlotNameText, FRAMEPOINT_BOTTOMRIGHT, dungeonWndowPlayerSlotBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.26482, 0.037280)
BlzFrameSetText(dungeonWindowPlayerSlotNameText, "|cffffffffPlayerName|r")
BlzFrameSetEnable(dungeonWindowPlayerSlotNameText, false)
BlzFrameSetScale(dungeonWindowPlayerSlotNameText, 1.29)
BlzFrameSetTextAlignment(dungeonWindowPlayerSlotNameText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_LEFT)

playerHeroIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWndowPlayerSlotBackrop, "", 1)
BlzFrameSetPoint(playerHeroIcon, FRAMEPOINT_TOPLEFT, dungeonWndowPlayerSlotBackrop, FRAMEPOINT_TOPLEFT, 0.10799, -0.033560)
BlzFrameSetPoint(playerHeroIcon, FRAMEPOINT_BOTTOMRIGHT, dungeonWndowPlayerSlotBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.23446, 0.036440)
BlzFrameSetTexture(playerHeroIcon, "PLAYER_HERO_ICON.blp", 0, true)

dungeonIcon = BlzCreateFrameByType("BACKDROP", "BACKDROP", dungeonWindowIconBackrop, "", 1)
BlzFrameSetPoint(dungeonIcon, FRAMEPOINT_TOPLEFT, dungeonWindowIconBackrop, FRAMEPOINT_TOPLEFT, 0.010880, -0.0039500)
BlzFrameSetPoint(dungeonIcon, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowIconBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.0091200, 0.0056700)
BlzFrameSetTexture(dungeonIcon, "UI/Icons/Dungeons/DUNGEON_TARGET_ICON.blp", 0, true)

dungeonWindowStartButtonBackropText = BlzCreateFrameByType("TEXT", "name", dungeonWindowStartButtonBackrop, "", 0)
BlzFrameSetPoint(dungeonWindowStartButtonBackropText, FRAMEPOINT_TOPLEFT, dungeonWindowStartButtonBackrop, FRAMEPOINT_TOPLEFT, 0.030130, -0.0041500)
BlzFrameSetPoint(dungeonWindowStartButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowStartButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.029870, 0.0058500)
BlzFrameSetText(dungeonWindowStartButtonBackropText, "|cffffffffСтарт|r")
BlzFrameSetEnable(dungeonWindowStartButtonBackropText, false)
BlzFrameSetScale(dungeonWindowStartButtonBackropText, 1.86)
BlzFrameSetTextAlignment(dungeonWindowStartButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

dungeonWindowLeaveButtonBackropText = BlzCreateFrameByType("TEXT", "name", dungeonWindowLeaveButtonBackrop, "", 0)
BlzFrameSetPoint(dungeonWindowLeaveButtonBackropText, FRAMEPOINT_TOPLEFT, dungeonWindowLeaveButtonBackrop, FRAMEPOINT_TOPLEFT, 0.028460, -0.0049900)
BlzFrameSetPoint(dungeonWindowLeaveButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowLeaveButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.031540, 0.0050100)
BlzFrameSetText(dungeonWindowLeaveButtonBackropText, "|cffffffffВыйти|r")
BlzFrameSetEnable(dungeonWindowLeaveButtonBackropText, false)
BlzFrameSetScale(dungeonWindowLeaveButtonBackropText, 1.86)
BlzFrameSetTextAlignment(dungeonWindowLeaveButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

dungeonWindowKickPlayerButtonBackropText = BlzCreateFrameByType("TEXT", "name", dungeonWindowKickPlayerButtonBackrop, "", 0)
BlzFrameSetPoint(dungeonWindowKickPlayerButtonBackropText, FRAMEPOINT_TOPLEFT, dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_TOPLEFT, 0.041850, -0.014950)
BlzFrameSetPoint(dungeonWindowKickPlayerButtonBackropText, FRAMEPOINT_BOTTOMRIGHT, dungeonWindowKickPlayerButtonBackrop, FRAMEPOINT_BOTTOMRIGHT, -0.038150, 0.014170)
BlzFrameSetText(dungeonWindowKickPlayerButtonBackropText, "|cffffffffX|r")
BlzFrameSetEnable(dungeonWindowKickPlayerButtonBackropText, false)
BlzFrameSetScale(dungeonWindowKickPlayerButtonBackropText, 1.00)
BlzFrameSetTextAlignment(dungeonWindowKickPlayerButtonBackropText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)
end
