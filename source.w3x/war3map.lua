gg_trg_Melee_Initialization = nil
gg_rct_regionSpawn = nil
gg_rct_regionEndMoveEnemy = nil
function InitGlobals()
end

function CreateBuildingsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h000"), 8128.0, -960.0, 270.000, FourCC("h000"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7488.0, -5440.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7424.0, -5184.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7424.0, -4928.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 9088.0, -5056.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 9024.0, -4800.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 9024.0, -4544.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8960.0, -4352.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8896.0, -4096.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8896.0, -3840.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7296.0, -4608.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7232.0, -4352.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7232.0, -4096.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8896.0, -5760.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8832.0, -5504.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8832.0, -5248.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7296.0, -1856.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7424.0, -3904.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7360.0, -3648.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7232.0, -3072.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7168.0, -2816.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7168.0, -2560.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7360.0, -3392.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7360.0, -2368.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7296.0, -2112.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7168.0, -1536.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7104.0, -1280.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 7104.0, -1024.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8896.0, -1856.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8960.0, -2368.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8896.0, -2112.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 9088.0, -3072.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 9024.0, -2816.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 9024.0, -2560.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8960.0, -3648.0, 270.000, FourCC("hgtw"))
u = BlzCreateUnitWithSkin(p, FourCC("hgtw"), 8960.0, -3392.0, 270.000, FourCC("hgtw"))
end

function CreateUnitsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("hpea"), 7215.8, -5419.4, 152.627, FourCC("hpea"))
end

function CreatePlayerBuildings()
CreateBuildingsForPlayer0()
end

function CreatePlayerUnits()
CreateUnitsForPlayer0()
end

function CreateAllUnits()
CreatePlayerBuildings()
CreatePlayerUnits()
end

function CreateRegions()
local we

gg_rct_regionSpawn = Rect(7872.0, -5696.0, 8480.0, -5184.0)
gg_rct_regionEndMoveEnemy = Rect(7968.0, -1280.0, 8224.0, -1120.0)
end

function Trig_Melee_Initialization_Actions()
SetPlayerFlagBJ(PLAYER_STATE_GIVES_BOUNTY, false, Player(11))
end

function InitTrig_Melee_Initialization()
gg_trg_Melee_Initialization = CreateTrigger()
TriggerAddAction(gg_trg_Melee_Initialization, Trig_Melee_Initialization_Actions)
end

function InitCustomTriggers()
InitTrig_Melee_Initialization()
end

function RunInitializationTriggers()
ConditionalTriggerExecute(gg_trg_Melee_Initialization)
end

function InitCustomPlayerSlots()
SetPlayerStartLocation(Player(0), 0)
SetPlayerColor(Player(0), ConvertPlayerColor(0))
SetPlayerRacePreference(Player(0), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(0), true)
SetPlayerController(Player(0), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(1), 1)
SetPlayerColor(Player(1), ConvertPlayerColor(1))
SetPlayerRacePreference(Player(1), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(1), true)
SetPlayerController(Player(1), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(11), 2)
SetPlayerColor(Player(11), ConvertPlayerColor(11))
SetPlayerRacePreference(Player(11), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(11), true)
SetPlayerController(Player(11), MAP_CONTROL_COMPUTER)
end

function InitCustomTeams()
SetPlayerTeam(Player(0), 0)
SetPlayerTeam(Player(1), 0)
SetPlayerTeam(Player(11), 0)
end

function InitAllyPriorities()
SetStartLocPrioCount(1, 2)
SetStartLocPrio(1, 0, 0, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(1, 2)
SetEnemyStartLocPrio(1, 0, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(2, 1)
SetStartLocPrio(2, 0, 0, MAP_LOC_PRIO_HIGH)
end

function main()
SetCameraBounds(-9472.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), -9728.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM), 9472.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), 9216.0 - GetCameraMargin(CAMERA_MARGIN_TOP), -9472.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), 9216.0 - GetCameraMargin(CAMERA_MARGIN_TOP), 9472.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), -9728.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM))
SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl", "Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
NewSoundEnvironment("Default")
SetAmbientDaySound("LordaeronSummerDay")
SetAmbientNightSound("LordaeronSummerNight")
SetMapMusic("Music", true, 0)
CreateRegions()
CreateAllUnits()
InitBlizzard()
InitGlobals()
InitCustomTriggers()
RunInitializationTriggers()
end

function config()
SetMapName("TRIGSTR_004")
SetMapDescription("TRIGSTR_006")
SetPlayers(3)
SetTeams(3)
SetGamePlacement(MAP_PLACEMENT_USE_MAP_SETTINGS)
DefineStartLocation(0, -2496.0, 4160.0)
DefineStartLocation(1, -7808.0, 1984.0)
DefineStartLocation(2, -5376.0, 7680.0)
InitCustomPlayerSlots()
SetPlayerSlotAvailable(Player(0), MAP_CONTROL_USER)
SetPlayerSlotAvailable(Player(1), MAP_CONTROL_COMPUTER)
SetPlayerSlotAvailable(Player(11), MAP_CONTROL_COMPUTER)
InitGenericPlayerSlots()
InitAllyPriorities()
end

