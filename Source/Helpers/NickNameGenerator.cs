using System;
using System.Collections.Generic;
using static WCSharp.Api.Common;
public static class NickNameGenerator
{
    private static readonly string[] Prefixes =
    {
        "Bot", "AI", "Helper", "Auto", "Smart", "Robo",
        "Mega", "Cyber", "Tech", "Virtual", "Quantum", "Nano",
        "Hyper", "Super", "Ultra", "Future", "Neo", "Epic",
        "Pixel", "Byte", "Data", "Info", "Logic", "Giga",
        "Tera", "Pico", "Terra", "Alpha", "Omega", "Beta",
        "Delta", "Sigma", "Theta", "Zeta", "Kappa", "Lambda",
        "Vortex", "Nexus", "Matrix", "Circuit", "Pulse",
        "Fusion", "Dynamo", "Echo", "Wave", "Stream",
        "Core", "Element", "Spark", "Flare", "Nova",
        "Comet", "Meteor", "Astro", "Orbit", "Galaxy",
        "Cosmo", "Nebula", "Stellar"
    };

    private static readonly string[] Bases =
    {
        "Master", "Wizard", "Guru", "Ninja", "Dude",
        "Sage", "Titan", "Hunter", "Knight", "Phantom",
        "Shadow", "Champion", "Warrior", "Maverick",
        "Legend", "Viking", "Samurai", "Ranger",
        "Assassin", "Gladiator", "Sorcerer",
        "Conqueror", "Defender", "Slayer",
        "Rogue", "Brawler", "Barbarian",
        "Paladin", "Seeker", "Protector",
        "Warlord", "Vanguard", "Crusader",
        "Avenger", "Sentinel", "Guardian",
        "Duelist", "Challenger"
    };

    private static readonly string[] Suffixes =
    {
        "3000", "X", "Z", "Pro",
        "inator", "Botter",
        "Xtreme", "Max",
        "Ultra",
        "Prime",
        "Elite",
        "King",
        "Queen",
        "Lord",
        "Demon",
        "Beast",
        "Slayer",
        "Hunter",
        "Master",
        "_01",
        "_02",
        "_03",
        "_04",
        "_05",
        "_06",
        "_07",
        "_08",
        "_09",
        "_10",
        "_Hero",
        "_God",
        "_Evil",
        "_Dark",
        "_Light",
        "_Fire",
        "_Ice",
        "_Storm",
        "_Thunder",
        "_Wind"
    };

    private static HashSet<string> generatedNicknames = new HashSet<string>();

    public static string GenerateNickName()
    {
        if (generatedNicknames.Count >= Prefixes.Length * Bases.Length * Suffixes.Length)
            throw new InvalidOperationException("Все возможные никнеймы уже сгенерированы.");

        string nickname;

        do
        {
            string prefix = Prefixes[GetRandomInt(0, Prefixes.Length)];
            string baseName = Bases[GetRandomInt(0, Bases.Length)];
            string suffix = Suffixes[GetRandomInt(0, Suffixes.Length)];

            nickname = $"{prefix}{baseName}{suffix}";

        } while (!generatedNicknames.Add(nickname)); // добавляем в HashSet и проверяем на уникальность

        return nickname;
    }
}
