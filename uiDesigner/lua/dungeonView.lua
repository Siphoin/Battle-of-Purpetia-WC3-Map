ListPlayers = nil 
TriggerListPlayers = nil 
DungeonPlayerSlot = nil 
TriggerDungeonPlayerSlot = nil 
DungeonIconBackrop = nil 
TriggerDungeonIconBackrop = nil 
Backdrop013 = nil 
TriggerBackdrop013 = nil 
DungeonPlayerSlotText = nil 
TriggerDungeonPlayerSlotText = nil 
Backdrop019 = nil 
TriggerBackdrop019 = nil 
NameDungeonText = nil 
TriggerNameDungeonText = nil 
BlueTextButton012 = nil 
TriggerBlueTextButton012 = nil 
REFORGEDUIMAKER = {}
REFORGEDUIMAKER.BlueTextButton012Func = function() 
BlzFrameSetEnable(BlueTextButton012, false) 
BlzFrameSetEnable(BlueTextButton012, true) 
end 
 
REFORGEDUIMAKER.Initialize = function()


ListPlayers = BlzCreateFrame("EscMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0)
BlzFrameSetAbsPoint(ListPlayers, FRAMEPOINT_TOPLEFT, 0.000220000, 0.585500)
BlzFrameSetAbsPoint(ListPlayers, FRAMEPOINT_BOTTOMRIGHT, 0.449140, 0.119330)

DungeonPlayerSlot = BlzCreateFrame("QuestButtonBaseTemplate", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0)
BlzFrameSetAbsPoint(DungeonPlayerSlot, FRAMEPOINT_TOPLEFT, 0.0627500, 0.528380)
BlzFrameSetAbsPoint(DungeonPlayerSlot, FRAMEPOINT_BOTTOMRIGHT, 0.384360, 0.458120)

DungeonIconBackrop = BlzCreateFrame("EscMenuBackdrop", ListPlayers, 0, 0)
BlzFrameSetAbsPoint(DungeonIconBackrop, FRAMEPOINT_TOPLEFT, 0.502740, 0.545880)
BlzFrameSetAbsPoint(DungeonIconBackrop, FRAMEPOINT_BOTTOMRIGHT, 0.690350, 0.386400)

Backdrop013 = BlzCreateFrameByType("BACKDROP", "BACKDROP", ListPlayers, "", 1)
BlzFrameSetAbsPoint(Backdrop013, FRAMEPOINT_TOPLEFT, 0.517250, 0.539260)
BlzFrameSetAbsPoint(Backdrop013, FRAMEPOINT_BOTTOMRIGHT, 0.677250, 0.399260)
BlzFrameSetTexture(Backdrop013, "CustomFrame.png", 0, true)

DungeonPlayerSlotText = BlzCreateFrameByType("TEXT", "name", DungeonPlayerSlot, "", 0)
BlzFrameSetAbsPoint(DungeonPlayerSlotText, FRAMEPOINT_TOPLEFT, 0.0800000, 0.510000)
BlzFrameSetAbsPoint(DungeonPlayerSlotText, FRAMEPOINT_BOTTOMRIGHT, 0.150000, 0.490000)
BlzFrameSetText(DungeonPlayerSlotText, "|cffffffffNamePlayer|r")
BlzFrameSetEnable(DungeonPlayerSlotText, false)
BlzFrameSetScale(DungeonPlayerSlotText, 1.29)
BlzFrameSetTextAlignment(DungeonPlayerSlotText, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT)

Backdrop019 = BlzCreateFrameByType("BACKDROP", "BACKDROP", DungeonPlayerSlot, "", 1)
BlzFrameSetAbsPoint(Backdrop019, FRAMEPOINT_TOPLEFT, 0.159910, 0.518480)
BlzFrameSetAbsPoint(Backdrop019, FRAMEPOINT_BOTTOMRIGHT, 0.189910, 0.488480)
BlzFrameSetTexture(Backdrop019, "CustomFrame.png", 0, true)

NameDungeonText = BlzCreateFrameByType("TEXT", "name", DungeonIconBackrop, "", 0)
BlzFrameSetAbsPoint(NameDungeonText, FRAMEPOINT_TOPLEFT, 0.455840, 0.389220)
BlzFrameSetAbsPoint(NameDungeonText, FRAMEPOINT_BOTTOMRIGHT, 0.735020, 0.350190)
BlzFrameSetText(NameDungeonText, "|cffFFCC00Кладбище резни|r")
BlzFrameSetEnable(NameDungeonText, false)
BlzFrameSetScale(NameDungeonText, 2.57)
BlzFrameSetTextAlignment(NameDungeonText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)

BlueTextButton012 = BlzCreateFrame("BrowserButton", DungeonIconBackrop, 0, 0)
BlzFrameSetAbsPoint(BlueTextButton012, FRAMEPOINT_TOPLEFT, 0.539590, 0.246190)
BlzFrameSetAbsPoint(BlueTextButton012, FRAMEPOINT_BOTTOMRIGHT, 0.711560, 0.169240)
BlzFrameSetText(BlueTextButton012, "|cffFCD20DStart|r")
BlzFrameSetScale(BlueTextButton012, 3.71)
TriggerBlueTextButton012 = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerBlueTextButton012, BlueTextButton012, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerBlueTextButton012, REFORGEDUIMAKER.BlueTextButton012Func) 
end
