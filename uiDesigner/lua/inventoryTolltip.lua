itemTolltip = nil 
TriggeritemTolltip = nil 
tolltipTextNameItem = nil 
TriggertolltipTextNameItem = nil 
tolltipTextNameItemCopy = nil 
TriggertolltipTextNameItemCopy = nil 
iconItemTooltip = nil 
TriggericonItemTooltip = nil 
REFORGEDUIMAKER = {}
REFORGEDUIMAKER.Initialize = function()


itemTolltip = BlzCreateFrameByType("BACKDROP", "BACKDROP", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), "", 1)
BlzFrameSetAbsPoint(itemTolltip, FRAMEPOINT_TOPLEFT, 0.304250, 0.415730)
BlzFrameSetAbsPoint(itemTolltip, FRAMEPOINT_BOTTOMRIGHT, 0.519790, 0.193180)
BlzFrameSetTexture(itemTolltip, "itemTolltip.png", 0, true)

tolltipTextNameItem = BlzCreateFrameByType("TEXT", "name", itemTolltip, "", 0)
BlzFrameSetAbsPoint(tolltipTextNameItem, FRAMEPOINT_TOPLEFT, 0.374570, 0.379420)
BlzFrameSetAbsPoint(tolltipTextNameItem, FRAMEPOINT_BOTTOMRIGHT, 0.489970, 0.352410)
BlzFrameSetText(tolltipTextNameItem, "|cffffffffLorem ipsum|r")
BlzFrameSetEnable(tolltipTextNameItem, false)
BlzFrameSetScale(tolltipTextNameItem, 1.00)
BlzFrameSetTextAlignment(tolltipTextNameItem, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT)

tolltipTextNameItemCopy = BlzCreateFrameByType("TEXT", "name", itemTolltip, "", 0)
BlzFrameSetAbsPoint(tolltipTextNameItemCopy, FRAMEPOINT_TOPLEFT, 0.335780, 0.345130)
BlzFrameSetAbsPoint(tolltipTextNameItemCopy, FRAMEPOINT_BOTTOMRIGHT, 0.490600, 0.225640)
BlzFrameSetText(tolltipTextNameItemCopy, "|cffffffff"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."|r")
BlzFrameSetEnable(tolltipTextNameItemCopy, false)
BlzFrameSetScale(tolltipTextNameItemCopy, 0.143)
BlzFrameSetTextAlignment(tolltipTextNameItemCopy, TEXT_JUSTIFY_TOP, TEXT_JUSTIFY_LEFT)

iconItemTooltip = BlzCreateFrameByType("BACKDROP", "BACKDROP", itemTolltip, "", 1)
BlzFrameSetAbsPoint(iconItemTooltip, FRAMEPOINT_TOPLEFT, 0.341010, 0.383410)
BlzFrameSetAbsPoint(iconItemTooltip, FRAMEPOINT_BOTTOMRIGHT, 0.362950, 0.359260)
BlzFrameSetTexture(iconItemTooltip, "CustomFrame.png", 0, true)
end
