gg_rct_RegionMurlocSpawn = nil
gg_rct_RegionUndeadSpawn = nil
gg_rct_HeroSpawn = nil
gg_rct_RegionUndeadSpawnZombieMore = nil
gg_rct_RegionUndeadSpawnDemons = nil
gg_rct_NoViolanceArea = nil
gg_trg_Melee_Initialization = nil
gg_trg_Untitled_Trigger_001 = nil
gg_dest_YTcx_0217 = nil
gg_dest_YTcx_0218 = nil
gg_dest_YTce_0219 = nil
gg_dest_YTce_0220 = nil
function InitGlobals()
end

function CreateAllDestructables()
local d
local t
local life

gg_dest_YTce_0219 = BlzCreateDestructableWithSkin(FourCC("YTce"), 1728.0, -256.0, 180.000, 1.000, 0, FourCC("YTce"))
gg_dest_YTce_0220 = BlzCreateDestructableWithSkin(FourCC("YTce"), -2496.0, -256.0, 180.000, 1.000, 0, FourCC("YTce"))
gg_dest_YTcx_0218 = BlzCreateDestructableWithSkin(FourCC("YTcx"), -384.0, 1856.0, 270.000, 1.000, 0, FourCC("YTcx"))
gg_dest_YTcx_0217 = BlzCreateDestructableWithSkin(FourCC("YTcx"), -384.0, -2368.0, 270.000, 1.000, 0, FourCC("YTcx"))
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("nfoh"), -1536.0, 896.0, 270.000, FourCC("nfoh"))
u = BlzCreateUnitWithSkin(p, FourCC("nfoh"), 768.0, -1408.0, 270.000, FourCC("nfoh"))
end

function CreateNeutralPassive()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h002"), 1879.1, -636.9, 355.343, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 1859.0, 109.2, 353.793, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), -23.0, 2031.7, 114.331, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), -756.0, 2023.4, 76.760, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), -2631.3, 128.0, 204.587, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), -2601.3, -665.5, 161.088, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), -803.0, -2515.5, 271.344, FourCC("h002"))
u = BlzCreateUnitWithSkin(p, FourCC("h002"), 49.4, -2510.8, 267.701, FourCC("h002"))
end

function CreatePlayerBuildings()
end

function CreatePlayerUnits()
end

function CreateAllUnits()
CreateNeutralPassiveBuildings()
CreatePlayerBuildings()
CreateNeutralPassive()
CreatePlayerUnits()
end

function CreateRegions()
local we

gg_rct_RegionMurlocSpawn = Rect(-9824.0, -6336.0, -7488.0, -5024.0)
gg_rct_RegionUndeadSpawn = Rect(-1600.0, -7616.0, 320.0, -5216.0)
gg_rct_HeroSpawn = Rect(-896.0, -736.0, 96.0, 224.0)
gg_rct_RegionUndeadSpawnZombieMore = Rect(5920.0, 5088.0, 8000.0, 7296.0)
gg_rct_RegionUndeadSpawnDemons = Rect(-5792.0, 4832.0, -4096.0, 7232.0)
gg_rct_NoViolanceArea = Rect(-2528.0, -2400.0, 1760.0, 1856.0)
end

function Trig_Melee_Initialization_Actions()
StartMeleeAI(Player(10), "AI.ai")
end

function InitTrig_Melee_Initialization()
gg_trg_Melee_Initialization = CreateTrigger()
TriggerAddAction(gg_trg_Melee_Initialization, Trig_Melee_Initialization_Actions)
end

function Trig_Untitled_Trigger_001_Actions()
ModifyGateBJ(bj_GATEOPERATION_OPEN, gg_dest_YTcx_0217)
ModifyGateBJ(bj_GATEOPERATION_OPEN, gg_dest_YTce_0220)
ModifyGateBJ(bj_GATEOPERATION_OPEN, gg_dest_YTcx_0218)
ModifyGateBJ(bj_GATEOPERATION_OPEN, gg_dest_YTce_0219)
end

function InitTrig_Untitled_Trigger_001()
gg_trg_Untitled_Trigger_001 = CreateTrigger()
TriggerAddAction(gg_trg_Untitled_Trigger_001, Trig_Untitled_Trigger_001_Actions)
end

function InitCustomTriggers()
InitTrig_Melee_Initialization()
InitTrig_Untitled_Trigger_001()
end

function RunInitializationTriggers()
ConditionalTriggerExecute(gg_trg_Untitled_Trigger_001)
end

function InitCustomPlayerSlots()
SetPlayerStartLocation(Player(0), 0)
SetPlayerColor(Player(0), ConvertPlayerColor(0))
SetPlayerRacePreference(Player(0), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(0), false)
SetPlayerController(Player(0), MAP_CONTROL_USER)
SetPlayerStartLocation(Player(1), 1)
SetPlayerColor(Player(1), ConvertPlayerColor(1))
SetPlayerRacePreference(Player(1), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(1), false)
SetPlayerController(Player(1), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(2), 2)
SetPlayerColor(Player(2), ConvertPlayerColor(2))
SetPlayerRacePreference(Player(2), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(2), false)
SetPlayerController(Player(2), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(3), 3)
SetPlayerColor(Player(3), ConvertPlayerColor(3))
SetPlayerRacePreference(Player(3), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(3), false)
SetPlayerController(Player(3), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(4), 4)
SetPlayerColor(Player(4), ConvertPlayerColor(4))
SetPlayerRacePreference(Player(4), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(4), false)
SetPlayerController(Player(4), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(5), 5)
SetPlayerColor(Player(5), ConvertPlayerColor(5))
SetPlayerRacePreference(Player(5), RACE_PREF_ORC)
SetPlayerRaceSelectable(Player(5), false)
SetPlayerController(Player(5), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(6), 6)
SetPlayerColor(Player(6), ConvertPlayerColor(6))
SetPlayerRacePreference(Player(6), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(6), false)
SetPlayerController(Player(6), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(11), 7)
SetPlayerColor(Player(11), ConvertPlayerColor(11))
SetPlayerRacePreference(Player(11), RACE_PREF_NIGHTELF)
SetPlayerRaceSelectable(Player(11), false)
SetPlayerController(Player(11), MAP_CONTROL_COMPUTER)
end

function InitCustomTeams()
SetPlayerTeam(Player(0), 0)
SetPlayerTeam(Player(1), 0)
SetPlayerTeam(Player(2), 0)
SetPlayerTeam(Player(3), 0)
SetPlayerTeam(Player(4), 0)
SetPlayerTeam(Player(5), 0)
SetPlayerTeam(Player(6), 0)
SetPlayerTeam(Player(11), 0)
end

function InitAllyPriorities()
SetStartLocPrioCount(1, 5)
SetStartLocPrio(1, 0, 0, MAP_LOC_PRIO_LOW)
SetStartLocPrio(1, 1, 2, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(1, 2, 3, MAP_LOC_PRIO_LOW)
SetStartLocPrio(1, 3, 4, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrioCount(1, 3)
SetEnemyStartLocPrio(1, 0, 5, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(1, 1, 7, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrioCount(2, 4)
SetEnemyStartLocPrio(2, 0, 1, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(2, 1, 4, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(2, 2, 5, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(2, 3, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(5, 4)
SetStartLocPrio(5, 0, 0, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 1, 1, MAP_LOC_PRIO_LOW)
SetStartLocPrio(5, 2, 2, MAP_LOC_PRIO_LOW)
SetStartLocPrio(5, 3, 3, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(5, 2)
SetEnemyStartLocPrio(5, 0, 1, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(5, 1, 4, MAP_LOC_PRIO_LOW)
SetStartLocPrioCount(7, 1)
SetStartLocPrio(7, 0, 0, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrioCount(7, 2)
SetEnemyStartLocPrio(7, 0, 2, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(7, 1, 3, MAP_LOC_PRIO_LOW)
end

function main()
SetCameraBounds(-10112.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), -10240.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM), 10112.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), 9856.0 - GetCameraMargin(CAMERA_MARGIN_TOP), -10112.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), 9856.0 - GetCameraMargin(CAMERA_MARGIN_TOP), 10112.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), -10240.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM))
SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl", "Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
NewSoundEnvironment("Default")
SetAmbientDaySound("CityScapeDay")
SetAmbientNightSound("CityScapeNight")
SetMapMusic("Music", true, 0)
CreateRegions()
CreateAllDestructables()
CreateAllUnits()
InitBlizzard()
InitGlobals()
InitCustomTriggers()
RunInitializationTriggers()
end

function config()
SetMapName("TRIGSTR_004")
SetMapDescription("TRIGSTR_006")
SetPlayers(8)
SetTeams(8)
SetGamePlacement(MAP_PLACEMENT_USE_MAP_SETTINGS)
DefineStartLocation(0, -384.0, -256.0)
DefineStartLocation(1, -384.0, -256.0)
DefineStartLocation(2, -384.0, -256.0)
DefineStartLocation(3, -384.0, -256.0)
DefineStartLocation(4, -384.0, -256.0)
DefineStartLocation(5, -384.0, -256.0)
DefineStartLocation(6, -384.0, -256.0)
DefineStartLocation(7, -384.0, -256.0)
InitCustomPlayerSlots()
InitCustomTeams()
InitAllyPriorities()
end

