itemTolltip = nil 
TriggeritemTolltip = nil 
inventoryFrame = nil 
TriggerinventoryFrame = nil 
buttonExit = nil 
BackdropbuttonExit = nil 
TriggerbuttonExit = nil 
itemFrame = nil 
TriggeritemFrame = nil 
REFORGEDUIMAKER = {}
REFORGEDUIMAKER.buttonExitFunc = function() 
BlzFrameSetEnable(buttonExit, false) 
BlzFrameSetEnable(buttonExit, true) 
end 
 
REFORGEDUIMAKER.Initialize = function()


itemTolltip = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1)
BlzFrameSetAbsPoint(itemTolltip, FRAMEPOINT_TOPLEFT, 0.304250, 0.415730)
BlzFrameSetAbsPoint(itemTolltip, FRAMEPOINT_BOTTOMRIGHT, 0.519790, 0.193180)
BlzFrameSetTexture(itemTolltip, "itemTolltip.png", 0, true)

inventoryFrame = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1)
BlzFrameSetAbsPoint(inventoryFrame, FRAMEPOINT_TOPLEFT, 0.493970, 0.470440)
BlzFrameSetAbsPoint(inventoryFrame, FRAMEPOINT_BOTTOMRIGHT, 0.803800, 0.142360)
BlzFrameSetTexture(inventoryFrame, "CustomConsoleUI/inventoryFrame.blpITEM_CON.blp", 0, true)

buttonExit = BlzCreateFrame("IconButtonTemplate", inventoryFrame, 0, 0)
BlzFrameSetAbsPoint(buttonExit, FRAMEPOINT_TOPLEFT, 0.758500, 0.473090)
BlzFrameSetAbsPoint(buttonExit, FRAMEPOINT_BOTTOMRIGHT, 0.791890, 0.434150)

BackdropbuttonExit = BlzCreateFrameByType("BACKDROP", "BackdropbuttonExit", buttonExit, "", 0)
BlzFrameSetAllPoints(BackdropbuttonExit, buttonExit)
BlzFrameSetTexture(BackdropbuttonExit, "dungeonWindowSelectExitButton.png", 0, true)
TriggerbuttonExit = CreateTrigger() 
BlzTriggerRegisterFrameEvent(TriggerbuttonExit, buttonExit, FRAMEEVENT_CONTROL_CLICK) 
TriggerAddAction(TriggerbuttonExit, REFORGEDUIMAKER.buttonExitFunc) 

itemFrame = BlzCreateFrameByType("BACKDROP", "BACKDROP", inventoryFrame, "", 1)
BlzFrameSetPoint(itemFrame, FRAMEPOINT_TOPLEFT, inventoryFrame, FRAMEPOINT_TOPLEFT, 0.045590, -0.069640)
BlzFrameSetPoint(itemFrame, FRAMEPOINT_BOTTOMRIGHT, inventoryFrame, FRAMEPOINT_BOTTOMRIGHT, -0.24478, 0.23732)
BlzFrameSetTexture(itemFrame, "ReplaceableTextures\\CommandButtons\\BTNRingSkull.blp", 0, true)
end
