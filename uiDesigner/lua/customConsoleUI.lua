buttonDungeons = nil 
BackdropbuttonDungeons = nil 
TriggerbuttonDungeons = nil 
buttonDungeonsText = nil 
TriggerbuttonDungeonsText = nil 
REFORGEDUIMAKER = {}
REFORGEDUIMAKER.buttonDungeonsFunc = function() 
BlzFrameSetEnable(buttonDungeons, false) 
BlzFrameSetEnable(buttonDungeons, true) 
end 
 
REFORGEDUIMAKER.Initialize = function()


buttonDungeons = BlzCreateFrame("IconButtonTemplate", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0)
BlzFrameSetAbsPoint(buttonDungeons, FRAMEPOINT_TOPLEFT, 0.000220000, 0.602230)
BlzFrameSetAbsPoint(buttonDungeons, FRAMEPOINT_BOTTOMRIGHT, 0.111890, 0.562080)

BackdropbuttonDungeons = BlzCreateFrameByType("BACKDROP", "BackdropbuttonDungeons", buttonDungeons, "", 0)
BlzFrameSetAllPoints(BackdropbuttonDungeons, buttonDungeons)
BlzFrameSetTexture(BackdropbuttonDungeons, "CustomConsoleUI/buttonOpenDungeons.blp", 0, true)
TriggerbuttonDungeons = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerbuttonDungeons, buttonDungeons, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerbuttonDungeons, REFORGEDUIMAKER.buttonDungeonsFunc) 

buttonDungeonsText = BlzCreateFrameByType("TEXT", "name", buttonDungeons, "", 0)
BlzFrameSetAbsPoint(buttonDungeonsText, FRAMEPOINT_TOPLEFT, 0.0189500, 0.599310)
BlzFrameSetAbsPoint(buttonDungeonsText, FRAMEPOINT_BOTTOMRIGHT, 0.0889500, 0.569310)
BlzFrameSetText(buttonDungeonsText, "|cffffffffРейды|r")
BlzFrameSetEnable(buttonDungeonsText, false)
BlzFrameSetScale(buttonDungeonsText, 1.00)
BlzFrameSetTextAlignment(buttonDungeonsText, TEXT_JUSTIFY_CENTER, TEXT_JUSTIFY_MIDDLE)
end
