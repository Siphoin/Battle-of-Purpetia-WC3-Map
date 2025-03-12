gg_rct_RegionMurlocSpawn = nil
gg_rct_RegionUndeadSpawn = nil
gg_rct_HeroSpawn = nil
gg_rct_RegionUndeadSpawnZombieMore = nil
gg_rct_RegionUndeadSpawnDemons = nil
gg_rct_NoViolanceArea = nil
gg_rct_RegionBanditsSpawn = nil
gg_rct_RegionGnollSpawn = nil
gg_rct_RegionGhostsSpawn = nil
gg_rct_RegionFelOrcsSpawn = nil
gg_rct_ArenaSpawnLeftPlayer = nil
gg_rct_ArenaSpawnRightPlayer = nil
gg_rct_ArenaRegion = nil
gg_rct_Dungeon1RegionFinalBoss = nil
gg_rct_Dungeon1RegionBossDeathKnight = nil
gg_rct_Dungeon1RegionBossLich = nil
gg_rct_Dungeon1EnterRegion = nil
gg_rct_Dungeon1RegionGuards1 = nil
gg_rct_Dungeon1RegionGuards2 = nil
gg_rct_Dungeon1RegionGuards3 = nil
gg_rct_Dungeon1RegionGuards4 = nil
gg_rct_Dungeon1RegionGuards5 = nil
gg_rct_Dungeon1RegionGuards6 = nil
gg_rct_Dungeon1RegionGuards7 = nil
gg_rct_Dungeon1RegionGuards8 = nil
gg_rct_Dungeon1RegionGuards9 = nil
gg_rct_Dungeon1RegionGuards10 = nil
gg_rct_Dungeon1RegionGuards11 = nil
gg_rct_Dungeon1RegionGate1 = nil
gg_rct_Dungeon1RegionGate2 = nil
gg_rct_Dungeon1RegionGate3 = nil
gg_rct_Dungeon1RegionGate4 = nil
gg_rct_Dungeon1RegionGate7 = nil
gg_rct_Dungeon1RegionGate8 = nil
gg_rct_Dungeon1RegionGate9 = nil
gg_rct_Dungeon1BossRegionFinalBoss = nil
gg_rct_Dungeon1RegionGate10 = nil
gg_rct_Dungeon1RegionGate5 = nil
gg_rct_Dungeon1RegionFinalGate = nil
function InitGlobals()
end

function CreateUnitsForPlayer12()
local p = Player(12)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("U000"), 8207.5, -10657.4, 179.817, FourCC("U000"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("U001"), 4040.4, -10388.3, 198.640, FourCC("U001"))
SetHeroLevel(u, 11, false)
SetHeroStr(u, 51, true)
SetHeroAgi(u, 30, true)
SetHeroInt(u, 95, true)
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("U002"), 11030.8, -6447.2, 245.680, FourCC("U002"))
SetHeroLevel(u, 17, false)
SetHeroStr(u, 102, true)
SetHeroAgi(u, 20, true)
SetHeroInt(u, 67, true)
SetUnitColor(u, ConvertPlayerColor(5))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 956.7, -13543.8, 191.017, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 961.3, -13700.0, 176.302, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 757.6, -13727.5, 151.111, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 869.5, -13959.1, 149.880, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 1051.0, -13929.8, 158.856, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 689.9, -13495.3, 209.757, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 1216.5, -13721.7, 176.756, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 1119.0, -13405.2, 198.509, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 2107.3, -11402.1, 251.436, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 2359.8, -11405.2, 236.594, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 2146.5, -11626.4, 241.653, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 2296.0, -11683.9, 228.095, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 1965.0, -11511.0, 259.818, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 1936.8, -11752.2, 257.899, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 2069.5, -11797.0, 239.968, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 2247.6, -11867.9, 218.396, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3769.3, -10135.5, 221.442, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3578.6, -10350.1, 217.879, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3581.4, -10625.4, 188.610, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3786.6, -10812.3, 169.526, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4056.7, -10821.6, 172.001, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3997.5, -10054.5, 216.600, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 4295.0, -10228.1, 201.877, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 4332.1, -10489.5, 189.652, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1007.8, -13396.9, 197.862, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1001.4, -13670.4, 170.572, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1003.7, -13851.2, 153.965, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1023.7, -13997.1, 142.195, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -833.9, -13465.6, 188.629, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -831.6, -13783.9, 164.239, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -839.2, -13974.0, 151.324, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), -605.6, -13641.3, 176.151, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), -619.3, -13885.5, 161.928, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3806.2, -12672.8, 27.209, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3869.9, -12930.3, 62.335, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 3923.4, -12738.9, 53.063, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4007.3, -12890.3, 78.760, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4076.2, -12726.3, 89.391, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4171.6, -12670.2, 124.207, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4223.7, -12868.8, 113.400, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4258.9, -12813.2, 122.798, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4327.6, -12690.7, 147.659, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 4361.6, -12837.5, 132.916, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 3814.5, -13108.7, 65.390, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 3963.7, -13113.0, 78.824, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 4128.8, -13110.9, 94.999, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 4271.5, -13097.7, 108.885, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 4407.5, -13093.4, 120.429, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 4555.2, -13004.1, 135.346, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6179.5, -12187.8, 275.250, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6132.7, -12549.8, 286.606, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6276.6, -12289.1, 267.517, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6298.8, -12408.9, 264.565, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6306.9, -12555.0, 261.318, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6383.1, -12331.4, 257.481, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6447.5, -12539.4, 243.451, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6495.9, -12381.5, 246.022, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6574.1, -12342.6, 241.319, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 6575.5, -12539.4, 230.621, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6129.2, -11923.0, 276.702, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6171.4, -12073.6, 275.094, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6298.7, -12005.5, 266.914, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6371.8, -11958.2, 262.825, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6390.0, -12167.1, 259.595, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6457.4, -12122.2, 255.631, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6555.8, -12058.3, 250.742, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 6565.9, -12193.6, 246.901, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7851.9, -10378.2, 191.021, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7858.1, -10537.4, 175.573, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7861.8, -10744.7, 156.902, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7699.8, -10373.1, 195.399, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7713.5, -10554.3, 171.998, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7712.5, -10736.6, 151.116, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7890.6, -11190.9, 279.711, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8047.6, -11194.6, 262.147, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 7901.2, -11375.4, 283.254, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8126.8, -11378.9, 245.129, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8276.7, -11339.9, 230.338, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8236.0, -11179.1, 243.647, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 7996.1, -10833.0, 212.769, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 8122.2, -11026.8, 186.588, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8440.0, -12781.8, 141.388, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8324.5, -13086.1, 112.386, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8688.2, -12912.3, 145.506, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8537.8, -13068.0, 128.564, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8640.4, -13013.1, 137.199, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8439.8, -13263.0, 115.035, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8501.4, -13164.9, 122.108, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8479.4, -12931.2, 132.410, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8586.3, -12866.7, 143.667, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8437.5, -13042.4, 123.070, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 8396.8, -13154.2, 115.593, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 8797.4, -13129.3, 138.483, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 8643.2, -13290.5, 125.248, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 8851.6, -13168.4, 138.853, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 8923.1, -13193.2, 140.341, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 8867.9, -13304.3, 134.198, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 9777.9, -10963.5, 286.284, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 9998.4, -10841.4, 272.826, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10017.6, -11036.7, 272.189, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10080.8, -10990.6, 268.080, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10168.9, -11156.9, 260.897, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10293.0, -10963.5, 255.425, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10359.2, -11055.7, 249.835, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 9763.3, -11230.3, 293.321, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 9754.1, -11298.8, 296.373, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 9867.3, -11291.6, 286.848, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 9765.2, -11442.6, 302.150, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 9890.5, -11432.3, 289.009, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10200.9, -11337.9, 254.921, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10212.2, -11490.5, 248.279, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10245.8, -11394.1, 248.752, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10306.1, -11480.3, 238.439, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10345.9, -11404.5, 239.012, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10749.8, -8468.7, 261.771, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 10587.1, -8653.6, 258.681, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 10875.1, -8731.4, 225.886, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10937.5, -8425.3, 246.194, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 11137.5, -8803.3, 270.558, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 10552.4, -8917.5, 305.330, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 10842.8, -8977.4, 283.731, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 4061.3, -12449.6, 101.187, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 10877.4, -7321.3, 241.443, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 11313.2, -7414.2, 220.425, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 11041.2, -8457.2, 237.218, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 11038.7, -7576.7, 234.038, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 3314.5, -10596.8, 173.010, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10621.6, -8464.4, 274.577, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 11037.8, -8373.0, 240.867, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 11103.2, -8441.3, 233.839, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10696.7, -8320.5, 267.666, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 10974.5, -8303.5, 247.298, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u003"), 11173.8, -8381.1, 232.356, FourCC("u003"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10742.2, -6616.5, 323.410, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10829.5, -6835.0, 22.701, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 11193.5, -6698.2, 198.874, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 11187.8, -6857.3, 155.376, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 11262.7, -6799.3, 173.259, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), 10718.1, -6744.0, 355.134, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -2487.4, -13473.5, 150.528, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -2559.5, -13715.8, 124.041, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -2276.0, -13516.5, 156.435, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -2340.5, -13777.1, 135.502, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1546.0, -12368.6, 165.546, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1436.5, -12555.1, 153.358, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1687.8, -12483.3, 147.462, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u004"), -1563.4, -12695.2, 138.266, FourCC("u004"))
SetUnitAcquireRange(u, 200.0)
u = BlzCreateUnitWithSkin(p, FourCC("u005"), 1361.1, -12743.1, 252.430, FourCC("u005"))
SetUnitAcquireRange(u, 200.0)
end

function CreateNeutralPassiveBuildings()
local p = Player(PLAYER_NEUTRAL_PASSIVE)
local u
local unitID
local t
local life

u = BlzCreateUnitWithSkin(p, FourCC("nfoh"), -1536.0, 896.0, 270.000, FourCC("nfoh"))
u = BlzCreateUnitWithSkin(p, FourCC("nfoh"), 768.0, -1408.0, 270.000, FourCC("nfoh"))
u = BlzCreateUnitWithSkin(p, FourCC("ncp3"), -8832.0, -10880.0, 270.000, FourCC("ncp3"))
u = BlzCreateUnitWithSkin(p, FourCC("ncp3"), -10752.0, -10880.0, 270.000, FourCC("ncp3"))
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
CreateUnitsForPlayer12()
end

function CreateAllUnits()
CreateNeutralPassiveBuildings()
CreatePlayerBuildings()
CreateNeutralPassive()
CreatePlayerUnits()
end

function CreateRegions()
local we

gg_rct_RegionMurlocSpawn = Rect(-9728.0, -6400.0, -6912.0, -4576.0)
gg_rct_RegionUndeadSpawn = Rect(-1568.0, -8384.0, 320.0, -4736.0)
gg_rct_HeroSpawn = Rect(-896.0, -736.0, 96.0, 224.0)
gg_rct_RegionUndeadSpawnZombieMore = Rect(5504.0, 4224.0, 7968.0, 7264.0)
gg_rct_RegionUndeadSpawnDemons = Rect(-5792.0, 4608.0, -4032.0, 7360.0)
gg_rct_NoViolanceArea = Rect(-3392.0, -2944.0, 2240.0, 2784.0)
gg_rct_RegionBanditsSpawn = Rect(10304.0, -544.0, 11552.0, 800.0)
gg_rct_RegionGnollSpawn = Rect(-11328.0, -1024.0, -8608.0, 288.0)
gg_rct_RegionGhostsSpawn = Rect(5856.0, 832.0, 8608.0, 2976.0)
gg_rct_RegionFelOrcsSpawn = Rect(-1024.0, 8512.0, 256.0, 10720.0)
gg_rct_ArenaSpawnLeftPlayer = Rect(-10944.0, -11072.0, -10528.0, -10656.0)
gg_rct_ArenaSpawnRightPlayer = Rect(-9024.0, -11072.0, -8608.0, -10656.0)
gg_rct_ArenaRegion = Rect(-11648.0, -11648.0, -8096.0, -10112.0)
gg_rct_Dungeon1RegionFinalBoss = Rect(10208.0, -7744.0, 12096.0, -6016.0)
gg_rct_Dungeon1RegionBossDeathKnight = Rect(7296.0, -11488.0, 8928.0, -10144.0)
gg_rct_Dungeon1RegionBossLich = Rect(3136.0, -11360.0, 4416.0, -9792.0)
gg_rct_Dungeon1EnterRegion = Rect(-3104.0, -12704.0, -2560.0, -12288.0)
gg_rct_Dungeon1RegionGuards1 = Rect(-2784.0, -14016.0, -2080.0, -13376.0)
gg_rct_Dungeon1RegionGuards2 = Rect(-1856.0, -12864.0, -1152.0, -12224.0)
gg_rct_Dungeon1RegionGuards3 = Rect(-1152.0, -14144.0, -480.0, -13280.0)
gg_rct_Dungeon1RegionGuards4 = Rect(480.0, -14080.0, 1344.0, -13248.0)
gg_rct_Dungeon1RegionGuards5 = Rect(1184.0, -12960.0, 1600.0, -12512.0)
gg_rct_Dungeon1RegionGuards6 = Rect(1728.0, -12032.0, 2528.0, -11232.0)
gg_rct_Dungeon1RegionGuards7 = Rect(3648.0, -13216.0, 4704.0, -12160.0)
gg_rct_Dungeon1RegionGuards8 = Rect(6016.0, -12672.0, 6912.0, -11776.0)
gg_rct_Dungeon1RegionGuards9 = Rect(8224.0, -13472.0, 9120.0, -12576.0)
gg_rct_Dungeon1RegionGuards10 = Rect(9504.0, -11584.0, 10560.0, -10688.0)
gg_rct_Dungeon1RegionGuards11 = Rect(10432.0, -9152.0, 11328.0, -8160.0)
gg_rct_Dungeon1RegionGate1 = Rect(-416.0, -14208.0, 96.0, -13152.0)
gg_rct_Dungeon1RegionGate2 = Rect(2336.0, -11008.0, 3040.0, -10368.0)
gg_rct_Dungeon1RegionGate3 = Rect(3552.0, -12000.0, 4576.0, -11392.0)
gg_rct_Dungeon1RegionGate4 = Rect(4448.0, -10816.0, 4768.0, -9952.0)
gg_rct_Dungeon1RegionGate7 = Rect(7456.0, -12672.0, 8352.0, -11712.0)
gg_rct_Dungeon1RegionGate8 = Rect(9536.0, -12192.0, 10752.0, -11808.0)
gg_rct_Dungeon1RegionGate9 = Rect(10080.0, -9792.0, 10848.0, -9088.0)
gg_rct_Dungeon1BossRegionFinalBoss = Rect(10848.0, -6656.0, 11200.0, -6368.0)
gg_rct_Dungeon1RegionGate10 = Rect(5856.0, -11616.0, 6912.0, -11232.0)
gg_rct_Dungeon1RegionGate5 = Rect(5792.0, -13088.0, 6848.0, -12704.0)
gg_rct_Dungeon1RegionFinalGate = Rect(10432.0, -8224.0, 11488.0, -7840.0)
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
SetPlayerRacePreference(Player(11), RACE_PREF_UNDEAD)
SetPlayerRaceSelectable(Player(11), false)
SetPlayerController(Player(11), MAP_CONTROL_COMPUTER)
SetPlayerStartLocation(Player(12), 8)
SetPlayerColor(Player(12), ConvertPlayerColor(12))
SetPlayerRacePreference(Player(12), RACE_PREF_HUMAN)
SetPlayerRaceSelectable(Player(12), false)
SetPlayerController(Player(12), MAP_CONTROL_COMPUTER)
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
SetPlayerTeam(Player(12), 0)
end

function InitAllyPriorities()
SetStartLocPrioCount(1, 2)
SetStartLocPrio(1, 0, 5, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(1, 5)
SetEnemyStartLocPrio(1, 0, 0, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(1, 1, 3, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(1, 2, 5, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(1, 3, 6, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(1, 4, 7, MAP_LOC_PRIO_LOW)
SetStartLocPrioCount(2, 7)
SetStartLocPrio(2, 0, 0, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 1, 3, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 2, 4, MAP_LOC_PRIO_LOW)
SetStartLocPrio(2, 3, 5, MAP_LOC_PRIO_LOW)
SetStartLocPrio(2, 4, 6, MAP_LOC_PRIO_LOW)
SetStartLocPrio(2, 5, 7, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(2, 6, 8, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrioCount(2, 9)
SetEnemyStartLocPrio(2, 0, 0, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(2, 1, 1, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(2, 2, 3, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(2, 3, 4, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(2, 4, 5, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(2, 5, 6, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(2, 6, 7, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrio(2, 7, 8, MAP_LOC_PRIO_HIGH)
SetStartLocPrioCount(5, 4)
SetStartLocPrio(5, 0, 0, MAP_LOC_PRIO_HIGH)
SetStartLocPrio(5, 1, 1, MAP_LOC_PRIO_LOW)
SetStartLocPrio(5, 2, 2, MAP_LOC_PRIO_LOW)
SetStartLocPrio(5, 3, 3, MAP_LOC_PRIO_LOW)
SetEnemyStartLocPrioCount(5, 2)
SetEnemyStartLocPrio(5, 0, 1, MAP_LOC_PRIO_HIGH)
SetEnemyStartLocPrio(5, 1, 4, MAP_LOC_PRIO_LOW)
end

function main()
SetCameraBounds(-12160.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), -14848.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM), 12160.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), 11904.0 - GetCameraMargin(CAMERA_MARGIN_TOP), -12160.0 + GetCameraMargin(CAMERA_MARGIN_LEFT), 11904.0 - GetCameraMargin(CAMERA_MARGIN_TOP), 12160.0 - GetCameraMargin(CAMERA_MARGIN_RIGHT), -14848.0 + GetCameraMargin(CAMERA_MARGIN_BOTTOM))
SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl", "Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
NewSoundEnvironment("Default")
SetAmbientDaySound("CityScapeDay")
SetAmbientNightSound("CityScapeNight")
SetMapMusic("Music", true, 0)
CreateRegions()
CreateAllUnits()
InitBlizzard()
InitGlobals()
end

function config()
SetMapName("TRIGSTR_004")
SetMapDescription("TRIGSTR_006")
SetPlayers(9)
SetTeams(9)
SetGamePlacement(MAP_PLACEMENT_USE_MAP_SETTINGS)
DefineStartLocation(0, -384.0, -256.0)
DefineStartLocation(1, -384.0, -256.0)
DefineStartLocation(2, -384.0, -256.0)
DefineStartLocation(3, -384.0, -256.0)
DefineStartLocation(4, -384.0, -256.0)
DefineStartLocation(5, -384.0, -256.0)
DefineStartLocation(6, -384.0, -256.0)
DefineStartLocation(7, -384.0, -256.0)
DefineStartLocation(8, -384.0, -256.0)
InitCustomPlayerSlots()
InitCustomTeams()
InitAllyPriorities()
end

