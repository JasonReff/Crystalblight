using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Hollow
        Disciplines("Hollow", "Iron Will", "Give Guard to friendly characters.", "Ancient Defender", "Inflict Decoy.", "Counterstrike", "Gain Counter.");
        SkillMake("Bolster", "Hollow", 1, 1, "Gain 3 + 3*END Guard.", "Untargeted");
        SkillMake("Decoy", "Hollow", 1, 2, "Gain Decoy: 2.", "Untargeted");
        SkillMake("Riposte", "Hollow", 1, 3, "Fast. Gain Counter: 1.", "Untargeted");
        SpecialMake("Iron Will", "Hollow", 60, "Restore Guard to prepare Iron Cleaver.", 1);
        SpecialMake("Ancient Defender", "Hollow", 8, "Gain Decoy to prepare Will of the Ancients.", 2);
        SpecialMake("Counterstrike", "Hollow", 8, "Gain Counter to prepare Rupture Tank.", 3);
        UltMake("Iron Cleaver", "Hollow", 1, "Deal physical damage to an enemy equal to Guard gained this combat.", "SingleTarget");
        UltMake("Will of the Ancients", "Hollow", 2, "Fast. Lose all Decoy. Gain 10 Guard for each Decoy lost.", "Untargeted");
        UltMake("Rupture Tank", "Hollow", 3, "The next time you survive damage, deal 10*END explosive damage to all enemies.", "Untargeted");
        SkillMake("Iron Will1", "Hollow", 2, 1, "+1 END. Whenever you defend, deal 3 magic damage to a random enemy.", "Passive");
        SkillMake("Iron Will2", "Hollow", 4, 1, "+1 END. Whenever you defend, deal 5 magic damage to a random enemy.", "Passive");
        SkillMake("Iron Will3", "Hollow", 6, 1, "+2 END. Whenever you defend, deal 8 magic damage to a random enemy.", "Passive");
        SkillMake("Ancient Defender1", "Hollow", 2, 2, "Whenever you inflict Decoy, gain 5 Guard.", "Passive");
        SkillMake("Ancient Defender2", "Hollow", 4, 2, "Whenever you inflict Decoy, gain 8 Guard. Your attacks and skills deal +25% damage while you have Decoy.", "Passive");
        SkillMake("Ancient Defender3", "Hollow", 6, 2, "Whenever you inflict Decoy, gain 10 Guard. Your attacks and skills deal +35% damage while you have Decoy.", "Passive");
        SkillMake("Counterstrike1", "Hollow", 2, 3, "Gain +3 attack during the enemy turn.", "Passive");
        SkillMake("Counterstrike2", "Hollow", 4, 3, "Gain +4 attack during the enemy turn. Whenever you defend, inflict Alarm: 1 on a random enemy.", "Passive");
        SkillMake("Counterstrike3", "Hollow", 6, 3, "Gain +5 attack during the enemy turn. Whenever you defend, inflict Alarm: 2 on a random enemy.", "Passive");
        SkillMake("Aether Cloak", "Hollow", 3, 1, "Gain 4 + 2*END Guard. Gain Ethereal: 2.", "Untargeted");
        SkillMake("Taunt", "Hollow", 3, 2, "Gain 4 + 3*END Guard. Gain Decoy: 1 and Steadfast: 1.", "Untargeted");
        SkillMake("Bravesword", "Hollow", 3, 3, "Deal 5 + 2*STR physical damage to an enemy. Gain Decoy: 1.", "SingleTarget");
        SkillMake("Stand Your Ground", "Hollow", 3, 4, "Gain Decoy: 3. Lock: Decoy.", "Untargeted");
        SkillMake("Lambaste", "Hollow", 3, 5, "Gain Decoy: 2 and Counter: 2.", "Untargeted");
        SkillMake("Spike Shield", "Hollow", 3, 6, "Gain Counter: 1 and Shield: 1.", "Untargeted");
        SkillMake("Energy Absorption", "Hollow", 5, 1, "Absorb 3*INT Guard from an enemy.", "SingleTarget");
        SkillMake("Eldritch Armor", "Hollow", 5, 2, "Inflict Alarm: 2 on an enemy. Gain 4 + 3*INT Guard.", "SingleTarget");
        SkillMake("Dual Siege", "Hollow", 5, 3, "Target another friendly character. You both gain Decoy: 2 and 2*END Guard.", "SingleTargetFriendlyOther");
        SkillMake("Ancient Champion", "Hollow", 5, 4, "Deal 6 + 2*INT magic damage to a column of enemies and inflict Jammed: 2. Gain Decoy: 2.", "EnemyColumn");
        SkillMake("Backswing", "Hollow", 5, 5, "Deal 10 + 2*STR physical damage to an enemy. Gain Counter: 1.", "SingleTarget");
        SkillMake("Aether Field", "Hollow", 5, 6, "Give all friendly characters Counter: 1.", "Untargeted");
        SkillMake("Subjugate", "Hollow", 7, 1, "Gain 5*END Guard. Deal 20 + STR physical damage to all enemies.", "Untargeted");
        SkillMake("Aether Dome", "Hollow", 7, 2, "Give all friendly characters 5 + 2*END Guard.", "Untargeted");
        SkillMake("Titan's Clash", "Hollow", 7, 3, "Deal 14*X physical damage to an enemy, where X equals your current Decoy.", "SingleTarget");
        SkillMake("Get Behind Me", "Hollow", 7, 4, "Gain Decoy equal to your END. Give all friendly characters behind you +3 STR for the rest of combat.", "Untargeted");
        SkillMake("Mana Shell", "Hollow", 7, 5, "Gain 4*END and Counter: 4.", "Untargeted");
        SkillMake("Embolden", "Hollow", 7, 6, "Gain Counter equal to your END. Inflict Weakened: 2 on all enemies.", "Untargeted");
        //Storm
        Disciplines("Storm", "Flamebearer", "Deal fire damage.", "Frost Tender", "Deal frost damage.", "Storm Claws", "Deal electric damage.");
        SkillMake("Heat Blast", "Storm", 1, 1, "Deal 8 + INT fire damage to an enemy. If the target is in the front row, deal +5 fire damage.", "SingleTarget");
        SkillMake("Winter Shard", "Storm", 1, 2, "Deal 6 + INT frost damage to an enemy. Inflict Frozen: 1.", "SingleTarget");
        SkillMake("Lightning Fuel", "Storm", 1, 3, "Deal 5 + 2*INT electric damage to an enemy. Gain Surge: 1.", "SingleTarget");
        SpecialMake("Flamebearer", "Storm", 80, "Deal fire damage to prepare Firestorm.", 1);
        SpecialMake("Frost Tender", "Storm", 80, "Deal frost damage to prepare Snowstorm.", 2);
        SpecialMake("Storm Claws", "Storm", 80, "Deal electric damage to prepare Thunderstorm.", 3);
        UltMake("Firestorm", "Storm", 1, "Fast. For 3 turns, your fire attacks deal double damage.", "Untargeted");
        UltMake("Snowstorm", "Storm", 2, "Fast. For 3 turns, your frost attacks are Piercing and inflict Timid: 3.", "Untargeted");
        UltMake("Thunderstorm", "Storm", 3, "Fast. For 3 turns, your electric attacks target all enemies.", "Untargeted");
        SkillMake("Flamebearer1", "Storm", 2, 1, "Your attacks inflict Burning: 1.", "Passive");
        SkillMake("Flamebearer2", "Storm", 4, 1, "Your attacks inflict Burning: 2. Whenever you attack, gain 1 SP.", "Passive");
        SkillMake("Flamebearer3", "Storm", 6, 1, "Your attacks inflict Burning: 3. Whenever you attack, gain 2 SP.", "Passive");
        SkillMake("Frost Tender1", "Storm", 2, 2, "Your attacks push enemies. Enemies that collide gain Frozen: 2.", "Passive");
        SkillMake("Frost Tender2", "Storm", 4, 2, "Your attacks push enemies. Enemies that collide gain Frozen: 3. Deal +25% damage to Frozen enemies.", "Passive");
        SkillMake("Frost Tender3", "Storm", 6, 2, "Your attacks push enemies. Enemies that collide gain Frozen: 3. Deal +50% damage to Frozen enemies.", "Passive");
        SkillMake("Storm Claws1", "Storm", 2, 3, "Whenever you deal electric damage, +15% chance to also damage an adjacent enemy.", "Passive");
        SkillMake("Storm Claws2", "Storm", 4, 3, "+1 DEX. Whenever you deal electric damage, +25% chance to also damage an adjacent enemy.", "Passive");
        SkillMake("Storm Claws3", "Storm", 6, 3, "+2 DEX. Whenever you deal electric damage, +33% chance to also damage an adjacent enemy.", "Passive");
        SkillMake("Ember Rain", "Storm", 3, 1, "Inflict Burning: 2 on all enemies.", "Untargeted");
        SkillMake("Heat Seekers", "Storm", 3, 2, "Double Strike. Deal 7 + INT fire damage to a random enemy.", "Untargeted");
        SkillMake("Frost Wave", "Storm", 3, 3, "Deal 5 + 2*INT frost damage to a column of enemies. Inflict Frozen: 2.", "EnemyColumn");
        SkillMake("Creeping Cold", "Storm", 3, 4, "Deal 14 + INT frost damage to an enemy and inflict Shiver: 5.", "SingleTarget");
        SkillMake("Plasma Bolt", "Storm", 3, 5, "Deal 8 + 2*INT electric damage to an enemy and inflict Burning: 3.", "SingleTarget");
        SkillMake("Thunderstrike", "Storm", 3, 6, "Deal 7 + 2*INT electric damage to an enemy and inflict Twitch: 5.", "SingleTarget");
        SkillMake("Third Degree", "Storm", 5, 1, "Deal 16 + 2*INT fire damage to an enemy and inflict Scarred: 4.", "SingleTarget");
        SkillMake("Combustion", "Storm", 5, 2, "Deal 11 + INT fire damage to an enemy. If they are burning, deal +10 explosive damage and Lock: Burning.", "SingleTarget");
        SkillMake("Water Whip", "Storm", 5, 3, "Deal 8 + 2*INT rost damage to an enemy. Inflict Shiver: 5 and Lock: Shiver.", "SingleTarget");
        SkillMake("Icicle", "Storm", 5, 4, "Summon an icicle with 20 health. It deals 10 frost damage and inflicts Frozen: 2.", "Summon");
        SkillMake("Cloudburst", "Storm", 5, 5, "Slow. Deal 25 + 2*INT electric damage to an enemy and inflict Weakened: 3.", "SingleTarget");
        SkillMake("Mindshock", "Storm", 5, 6, "Deal 18 + INT electric damage to an enemy and inflict Confusion: 2.", "SingleTarget");
        SkillMake("Inferno", "Storm", 7, 1, "Deal 25 + 3*INT fire damage to all enemies. Gain Burning: 3.", "Untargeted");
        SkillMake("Incinerate", "Storm", 7, 2, "Deal 25 + INT fire damage to an enemy and inflict Burning: 10.", "SingleTarget");
        SkillMake("Ice Age", "Storm", 7, 3, "Deal 15 + 2*INT frost damage to all enemies. Inflict Frozen: 3.", "Untargeted");
        SkillMake("Avalanche", "Storm", 7, 4, "Place Icecap: 8 on a 3x3 of enemy spaces.", "EnemySpace");
        SkillMake("Godhand", "Storm", 7, 5, "Deal 50 + 2*INT electric damage to an enemy. Gain Stun: 2.", "SingleTarget");
        SkillMake("Chainbolt", "Storm", 7, 6, "Deal 40 + INT piercing lightning damage to an enemy. If the target dies, this is Fast.", "SingleTarget");
        //Shadow
        Disciplines("Shadow", "Unseen", "Use skills with Fast.", "Piercer", "Deal Piercing damage.", "Slow Death", "Inflict Poison.");
        SkillMake("Quick Blade", "Shadow", 1, 1, "Fast. Deal 4 + DEX physical damage to an enemy. This skill is always Fast.", "SingleTarget");
        SkillMake("Pincer", "Shadow", 1, 2, "Deal 8 + 2*DEX Piercing physical damage to an enemy.", "SingleTarget");
        SkillMake("Disease", "Shadow", 1, 3, "Inflict Poison: 5 on an enemy.", "SingleTarget");
        SpecialMake("Unseen", "Shadow", 7, "Use skills with Fast to prepare Finale.", 1);
        SpecialMake("Piercer", "Shadow", 60, "Deal Piercing damage to prepare Razorsweep.", 2);
        SpecialMake("Slow Death", "Shadow", 30, "Inflict Poison to prepare Lethal Extraction.", 3);
        UltMake("Finale", "Shadow", 1, "Deal 6 + DEX physical damage to an enemy. Repeat this for each other skill played this turn.", "SingleTarget");
        UltMake("Razorsweep", "Shadow", 2, "Deal 8 + 2*DEX piercing blood damage to all enemies. Inflict Bleeding: 5.", "Untargeted");
        UltMake("Lethal Extraction", "Shadow", 3, "Remove all Poison from an enemy. Deal physical damage to the target equal to 3x the Poison removed.", "SingleTarget");
        SkillMake("Unseen1", "Shadow", 2, 1, "Whenever you use a skill, gain +1 DEX for the rest of the turn.", "Passive");
        SkillMake("Unseen2", "Shadow", 4, 1, "Whenever you use an attack or skill, gain +1 DEX for the rest of the turn. Attacks have a 25% chance to be Fast.", "Passive");
        SkillMake("Unseen3", "Shadow", 6, 1, "Whenever you use an attack or skill, gain +2 DEX for the rest of the turn. Attacks have a 45% chance to be Fast.", "Passive");
        SkillMake("Piercer1", "Shadow", 2, 2, "Whenever you deal Piercing damage, +20% chance to damage the character behind the target as well.", "Passive");
        SkillMake("Piercer2", "Shadow", 4, 2, "Whenever you deal Piercing damage, inflict Vulnerable: 1 and +30% chance to damage the character behind the target as well.", "Passive");
        SkillMake("Piercer3", "Shadow", 6, 2, "Whenever you deal Piercing damage, inflict Vulnerable: 2 and +40% chance to damage the character behind the target as well.", "Passive");
        SkillMake("Slow Death1", "Shadow", 2, 3, "Your attacks inflict Poison: 1.", "Passive");
        SkillMake("Slow Death2", "Shadow", 4, 3, "Your attacks inflict Poison: 2. You are immune to Poison.", "Passive");
        SkillMake("Slow Death3", "Shadow", 6, 3, "Your attacks inflict Poison: 3. You are immune to Poison and Corrosion.", "Passive");
        SkillMake("Quick Thinking", "Shadow", 3, 1, "Fast. Increase Critical Rate by 10 this turn.", "Untargeted");
        SkillMake("Darkshot", "Shadow", 3, 2, "Fast. Deal 7 + INT dark damage to an enemy and inflict Fear: 1.", "SingleTarget");
        SkillMake("Timed Strike", "Shadow", 3, 3, "Deal 14 + 2*DEX physical damage to an enemy. If they intend to attack, this is Piercing.", "SingleTarget");
        SkillMake("Forced Martyr", "Shadow", 3, 4, "Deal 6 + DEX Piercing physical damage to an enemy and inflict Tether: 2.", "SingleTarget");
        SkillMake("Deadly Silence", "Shadow", 3, 5, "Inflict Poison: 3 and Jammed: 1 on an enemy.", "SingleTarget");
        SkillMake("Pollute", "Shadow", 3, 6, "Inflict Poison: 4 on a column of enemies.", "EnemyColumn");
        SkillMake("Venomize", "Shadow", 5, 1, "Fast. Inflict Poison: 3 on an enemy.", "SingleTarget");
        SkillMake("Darkveil", "Shadow", 5, 2, "Fast. Gain Evasion: 2.", "Untargeted");
        SkillMake("Sharpen Blade", "Shadow", 5, 3, "Gain Pierce: 4.", "Untargeted");
        SkillMake("Shadow Slice", "Shadow", 5, 4, "Deal 20 + INT Piercing dark damage. Gain Ethereal: 2.", "SingleTarget");
        SkillMake("Permatox", "Shadow", 5, 5, "Inflict Poison: 6 on an enemy and Lock: Poison.", "SingleTarget");
        SkillMake("Alchemy Bomb", "Shadow", 5, 6, "Deal 12 + DEX Piercing toxic damage to an enemy. If it has Poison, inflict Poison: 3 on all enemies.", "SingleTarget");
        SkillMake("Finisher", "Shadow", 7, 1, "Deal 18 + 3*DEX physical damage to an enemy. If it has Vulnerable, this is Fast.", "SingleTarget");
        SkillMake("Shadow Song", "Shadow", 7, 2, "Fast. Deal 5 + INT dark damage to all enemies.", "Untargeted");
        SkillMake("Dark Spear", "Shadow", 7, 3, "Slow. Deal 40 + 3*STR piercing physical damage to an enemy.", "SingleTarget");
        SkillMake("Blade Dance", "Shadow", 7, 4, "Deal 15 + DEX Piercing physical damage to a column of enemies. If any enemies die, this is Fast.", "EnemyColumn");
        SkillMake("Cower", "Shadow", 7, 5, "Deal 8 + 2*DEX Piercing toxic damage to a row of enemies. Inflict Timid: 3 and Poison: 5.", "EnemyRow");
        SkillMake("Choking Void", "Shadow", 7, 6, "Deal 8 + INT dark damage to all enemies. Inflict Marked: 3 and Poison: 5.", "Untargeted");
        //Reaper
        SpecialMake("Patient Hunter", "Reaper", 5, "", 1);
        SpecialMake("Tracker", "Reaper", 10, "", 2);
        SpecialMake("Bloodletter", "Reaper", 15, "", 3);
        UltMake("Whirlwind", "Reaper", 1, "", "Untargeted");
        UltMake("Hunter Missiles", "Reaper", 2, "", "Untargeted");
        UltMake("Bloodmoon Curse", "Reaper", 3, "", "SingleTarget");
        SpecialMake("Volatility", "Matriarch", 60, "", 1);
        SpecialMake("Fleshgiver", "Matriarch", 80, "", 2);
        SpecialMake("Seeds of Darkness", "Matriarch", 30, "", 3);
        SkillMake("Poisoner1", "Matriarch", 2, 1, "Your effects that cause Poison inflict +1.", "");
        UltMake("Liquification", "Matriarch", 1, "", "Untargeted");
        UltMake("Expulsion", "Matriarch", 2, "", "Untargeted");
        UltMake("Blackroot Harvest", "Matriarch", 3, "", "SingleTarget");
    }

    public void UltMake(string ultName, string character, int discipline, string ultDescription, string targeting)
    {
        PlayerPrefs.SetString(character + "-Ultimate" + discipline, ultName);
        PlayerPrefs.SetString(character + "-Ultimate" + discipline + "Description", ultDescription);
        PlayerPrefs.SetString(ultName + "ID", character + "-Ultimate" + discipline);
        PlayerPrefs.SetString(ultName + "-Targeting", targeting);
    }

    public void Disciplines(string characterName, string discipline1, string discipline1Special, string discipline2, string discipline2Special, string discipline3, string discipline3Special)
    {
        PlayerPrefs.SetString(characterName + "Discipline1", discipline1);
        PlayerPrefs.SetString(characterName + "Discipline1Special", discipline1Special);
        PlayerPrefs.SetString(characterName + "Discipline2", discipline2);
        PlayerPrefs.SetString(characterName + "Discipline2Special", discipline2Special);
        PlayerPrefs.SetString(characterName + "Discipline3", discipline3);
        PlayerPrefs.SetString(characterName + "Discipline3Special", discipline3Special);
    }

    public void SpecialMake(string specialName, string character, int specialMax, string specialDescription, int discipline)
    {
        PlayerPrefs.SetString(character + "-Special" + discipline, specialName);
        PlayerPrefs.SetString(character + "-Special" + discipline + "Description", specialDescription);
        PlayerPrefs.SetInt(character + "-Special" + discipline + "Max", specialMax);
        PlayerPrefs.SetString(specialName + "ID", character + "-Special" + discipline);
    }
    public void SkillMake(string skillName, string character, int level, int skillChoice, string skillDescription, string targeting)
    {
        PlayerPrefs.SetString(character + "Level" + level + "Skill" + skillChoice, skillName);
        PlayerPrefs.SetString(character + "Level" + level + "Skill" + skillChoice + "Description", skillDescription);
        PlayerPrefs.SetString(skillName + "ID", character + "Level" + level + "Skill" + skillChoice);
        PlayerPrefs.SetString(skillName + "-Targeting", targeting);
    }
}
