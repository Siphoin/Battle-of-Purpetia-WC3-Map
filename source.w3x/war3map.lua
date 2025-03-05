gg_trg_Melee_Initialization = nil
function InitGlobals()
end

function CreateBuildingsForPlayer0()
local p = Player(0)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("h000"), 8576.0, -1216.0, 270.000, FourCC("h000"))
end

function CreatePlayerBuildings()
CreateBuildingsForPlayer0()
end

function CreatePlayerUnits()
end

function CreateAllUnits()
CreatePlayerBuildings()
CreatePlayerUnits()
end

function Trig_Melee_Initialization_Actions()
MeleeStartingVisibility()
MeleeStartingHeroLimit()
MeleeGrantHeroItems()
MeleeStartingResources()
MeleeClearExcessUnits()
MeleeStartingUnits()
MeleeStartingAI()
MeleeInitVictoryDefeat()
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

