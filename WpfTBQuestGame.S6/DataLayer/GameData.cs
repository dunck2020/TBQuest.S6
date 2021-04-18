using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        #region CONSTANTS

        public const string DEFAULT_GAME_MESSAGE =
            "You appear in a village from the past. Last thing you knew you were working " +
            "in your lab." +
            "Your goal is to get home.  Speak to as many characters as you can.  Complete " +
            "missions to gain experience.  When you find a weapon, be sure to use it to " +
            "boost attack strength.  The Abyss and Kranik Mountains are very " +
            "dangerous places to visit.  Some characters have more than one thing to say " +
            "click \"speak to\" again to hear more.  Check the items tab regularly as " +
            "some characters drop items when you speak to them.";

        #endregion
        
        public static Player DefaultPlayer(bool newPlayer = false, string name = "Player")
        {
            return new Player()
            {
                Id = 1000,
                Name = name,
                Location = 0,
                Kind = Character.Genus.Player,
                Lives = 1,
                AttackLevel = 1,
                Health = 5,
                AttackPoints = 5,
                NewPlayer = newPlayer,
                CurrentWeapon = GameItemById(1000) as Weapon,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(4000)
                },
                Missions = new ObservableCollection<Mission>()
                {
                    MissionById(1),
                    MissionById(2),
                    MissionById(3)
                }
                  
            };
        }
        public static Map MasterGameMap()
        {
            Map masterGameMap = new Map();
            masterGameMap.StandardGameItems = StandardGameItems();

            //add all locations to the map

            masterGameMap.Locations.Add // The Village
                (new Location()
                {
                    Id = 100,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 101, 102, 103, 104, 105},
                    Name = "The Village",
                    Description =
                    "CURRENT LOCATION:  The Village.  A small beautiful city born from the middle ages.\n" +
                    "Home base to all of your quests.",

                    LocationMessage =
                    "Welcome to the village.  You have one purpose, to get home.  Interact with everyone " +
                    "that you can as they may provide gifts.  Battle in the village should be the " +
                    "last resort...",

                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1001),
                        NpcById(1002),
                        NpcById(1003)
                    }
                }
                );       
            masterGameMap.Locations.Add //The mountains
                (new Location()
                {
                    Id = 101,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 101 },
                    Name = "The Kranik Moutains",
                    Description =
                    "CURRENT LOCATION: The Kranik Moutains.  The mountains are treacherous, steep jagged\n " +
                    "peaks, and unforgiving terrain.  One must be prepared for unimaginably powerful beasts.\n",
                    LocationMessage =
                    "At the base of the mountain you see large handmade stone stairs covered in moss and " +
                    "wet from the unrelenting cold mist.  They appear to lead to oblivion, disappearing " +
                    "into the dense clouds above.  As you start to climb the gloom of clouds envelope you, " +
                    "making it impossible to see anything but a few steps in front of you.  You hear the " +
                    "cry of what sounds like an eagle, evolving into a blood curdling scream.  Soon you are lost " +
                    "in the fog.  HINT: A creature here possess an artifact to get back to the village.",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(3001),
                        NpcById(3002)
                    }
                }
                );
            masterGameMap.Locations.Add //the forest
                (new Location()
                {
                    Id = 102,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 100, 202 },
                    Name = "The Black Forest",
                    Description =
                    "CURRENT LOCATION: The Black Forest.  An ancient forest. Towering trees filter the\n" +
                    "sunlight, little of it reaches you, pine scent fills the air.",
                    LocationMessage =
                    "You hear a howling in the far distance.  Knowing few who have ventured through the forest " +
                    "have ever returned, you are not even sure how to get out of here.  Branches break in the distance " +
                    "as it approaches dusk.  This may not be the best place to be at night.",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(3003)
                    }
                }
                );
            masterGameMap.Locations.Add //the aegis swamp
                (new Location()
                {
                    Id = 103,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 100, 203 },
                    Name = "The Aegis Swamp",
                    Description =
                    "CURRENT LOCATION: The Aegis Swamp.  Dark foreboding swamp.  Water floods the trees \n" +
                    "with little high ground.  The trunk of cedar trees hide all that is beyond.",
                    LocationMessage =
                    "The smell of stagnant water fills your nose as you make your way into the swamp.  Everything " +
                    "is wet, the water moves slowly flowing into the darkness.  The density of the undergrowth make it " +
                    "near impossible to travel but you push on.  Splashing erupts around you...  Continue..",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(3006),
                        NpcById(3007)
                    }

                }
                );
            masterGameMap.Locations.Add // the harbor
                (new Location()
                {
                    Id = 104,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 100, 204 },
                    Name = "The Harbor",
                    Description =
                    "CURRENT LOCATION: The Harbor.  The docks are lined wih fishing trawlers.  Town folk \n" +
                    "walk about, all performing some daily task.",
                    LocationMessage =
                    "The smell low tide, and fish hits you strong.  You are looking for someone but not sure " +
                    "who.  You meander around looking for someone to talk to, everyone seems busy, as the " +
                    "boats have recently returned from the dark sea.  You can see an island out in the horizon and " +
                    "you smile as the sun warms your face, the sound of slow crashing waves calms you...  Continue",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1007),
                        NpcById(1011)
                    }
                }
                );
            masterGameMap.Locations.Add // the abyss
                (new Location()
                {
                    Id = 105,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 100 },
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(2002) as Artifact //death stone
                    },
                    Name = "The Abyss",
                    Description =
                    "CURRENT LOCATION: The Abyss.  Darkness, fire and the end of everything\n",
                    LocationMessage =
                    "The unrelenting heat and pressure make you fall to your knees.  The smell of death makes you " +
                    "sick.  A deep guttural laugh starts in the distance and gets louder and louder.  Your vision " +
                    "begins to twist, the laughing gets louder and more sinister.  Your flesh begins to melt and you " +
                    "feel your bones cracking.  The laughter echoes through your head as you turn to dust...",
                    ModifyLives = -1,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(3004)
                    }
                }
                );
            masterGameMap.Locations.Add // the cave
                (new Location()
                {
                    Id = 201,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 101 },
                    //REQUIRE RELIC
                    Name = "The Cave",
                    Description =
                    "CURRENT LOCATION: The Cave.  A place for refuge from the unrelenting death that awaits\n" +
                    "in the mountains.  Warmth and protection.",
                    LocationMessage =
                    "The entrance to the cave is proteced by a iron door, the artifact Marica gave you glows " +
                    "matching the insignia on the door and it slides open easily.  The cave is dark, but you can feel " +
                    "the warmth and smell the food.  In the distance you see light against the wall of the cave."  +
                    "Cont...",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1004)
                    }
                }
                );
            masterGameMap.Locations.Add // the Elf citadel
                (new Location()
                {
                    Id = 202,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 102 },
                    Name = "The Elf Citadel",
                    Description =
                    "CURRENT LOCATION: The Elf Citadel.  A well fortified imposing structure.  Archers \n"  +
                    "protect the flanks.  Well armored guardsmen stand at the gate.",
                    LocationMessage =
                    "The large looming structure before you looks like a picture of a 16th century castle.  " +
                    "You approach cautiously, you can feel the eyes on you.  \"Hault! Proceed no further\" a " +
                    "voice calls out to you.  Continue...",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1005),
                        NpcById(1006)
                    }
                }
                );
            masterGameMap.Locations.Add // the witches encampment
                (new Location()
                {
                    Id = 203,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 103 },
                    GameItems = new ObservableCollection<GameItem>
                    {
                        GameItemById(3001) as Spell,
                        GameItemById(3002) as Spell
                    },
                    Name = "The Witches Encampment",
                    Description =
                    "CURRENT LOCATION: The Witches Encampment.  Weird earthly structures litter the area.  \n" +
                    "They appear to have grown out of the ground.",
                    LocationMessage =
                    "You finally reach high groud.  The only area out of the water for miles, weird smells fill your " +
                    "nostrils.  It feels like you are being watched.  A few cats scutter around you as you move.  It " +
                    "is vital you pick the right structure.  Continue...",
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(1010)
                    }
                }
                );
            masterGameMap.Locations.Add // the island of lost souls
                (new Location()
                {
                    Id = 204,
                    IsAccessible = false,
                    CurrentAvailableLocations = new List<int>() { 104 },
                    Name = "The Island of Lost Souls",
                    Description =
                        "CURRENT LOCATION: The Island of Lost Souls.  An island said to move at random in\n" +
                        "the sea, not always near land. A place of trapped tortured souls.",
                    LocationMessage =
                        "The Ferryman drops you at the dock and is simply gone.  There appears to be no life " +
                        "anywhere on the island.  You see some grave markers and hear weird ghoulish screams " +
                        "strange lights and ghostly shapes float around in the distance.  You were told it is " +
                        "always dark here.  The darkness is crushing, you feel a pull to lie on the ground " +
                        "and let them take you, your life blood feels like it is slipping away.  Continue...",
                    ModifyHealth = -50,
                    Npcs = new ObservableCollection<Npc>()
                    {
                        NpcById(3005),
                        NpcById(1009)
                    }

                }
                ) ;
            masterGameMap.Locations.Add //home
                (new Location()
                    {
                        Id = 300,
                        IsAccessible = false,
                        CurrentAvailableLocations = new List<int>() { 300 },
                        //REQUIRE RELIC,
                        Name = "Home",
                        Description =
                        "CURRENT LOCATION: Home.  \n",
                        LocationMessage =
                        "YOU WIN!  Thank you for playing.  To play again select New Game."
                    }
                );

            //player will start the game in the village
            masterGameMap.CurrentLocation = masterGameMap.Locations.FirstOrDefault(l => l.Id == 100);

            return masterGameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                //TREASURES - id, name, value, description, use, message, TreasureType, isavailable
                new Treasure(4000, "Gold Watch", 100, "Grandfathers Rolex", "You look at the time", Treasure.TreasureType.General, true),

                //WEAPONS - id, name, value, description, useMessage, bindable, hitpoints, times can use, enemy hits per use, is it available
                new Weapon(1000, "Base Weapon", 0, "Fists - Claws", "Fight", false, 5, 10000 , 1, true),
                new Weapon(1001, "Club", 5, "Oak club used on fishing boats", "Swing", false, 30, 800, 1, true),
                new Weapon(1002, "Rapier", 30, "Sharp double edged sword", "Slice", false, 55, 20, 1, true),
                new Weapon(1003, "Dagger", 60, "Dragon tooth dagger", "Stab", true, 45, 60, .5, true),
                new Weapon(1004, "Talons of Hell", 0, "Rakshasa Talons", "", false, 300, 5,1,true),
                new Weapon(1005, "War Hammer", 400, "Large weapon of carnage", "Smash", true, 250, 800, 3, true),
                new Weapon(1006, "Long sword", 30, "Heavy deadly sword of a great knight", "Chop", false, 100, 40, 2, true),
                new Weapon(1007, "Lightning Staff", 1800, "Open up the sky", "Thunder", true, 200, 5, 2, true),
                new Weapon(1008, "Hell Scythe", 0, "Made from the smashed skulls of ghouls, forged in hell", "Death to all", true, 500, 1, 1, false),

                //ARIFACTS - id, name, value description, useMessage, Artifact use action, is it available         
                new Artifact(2001, "Healing Stone", 20, "A life rock", "Breaking the stone you gain 3 lives",Artifact.UseActionType.HEAL_PLAYER, true),
                new Artifact(2002, "Death Stone", 0, "Polished black stone", "You are enveloped by darkness", Artifact.UseActionType.KILL_PLAYER, true),
                new Artifact(2003, "Goblet of doom", 350, "A vessel scraped from deathonimus steel", "The liquid poors into your soul",Artifact.UseActionType.ELF_DROP_ITEM, true),
                new Artifact(2004, "Home Stone", 0, "Milky Blue Stone", "You appear in the village center", Artifact.UseActionType.OPEN_LOCATION, true),
                new Artifact(2005, "Forest jewel", 0, "Hand made necklace with an opal", "The cave is now visible", Artifact.UseActionType.OPEN_LOCATION, true),
                new Artifact(2006, "Amulet of Light", 0, "Clear Crystal", "You made it home", Artifact.UseActionType.OPEN_LOCATION, true),

                //SPELLS -  id, name, value, description, use message, health change, lives change, attackpoints change, is available
                new Spell(3001, "Sleepy Ghouls", 0, "Make the ghoulish sleepy for a short time", "Time seems to stand still", -20, 0, 0, true),
                new Spell(3002, "Mountain Invisibilty", 0, "Use to disappear in the mountains", "Light bends around you", -50, 0, 0, true)
            };
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                //HUMANS
                new Human()
                {
                    Id = 1002,
                    Name = "The Mistress",
                    Location = 100,
                    Kind = Character.Genus.Human,
                    Description = "A tall beautiful woman with jet black hair",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "Speak to the Peri in the forest, you must defeat the Hell Hounds for her to be free.  " +
                        "Once you free Marica she may be able to help you with passage through the mountains."
                    },
                    AttackLevel = 5, // 5 by 45 hp 225
                    CurrentWeapon = GameItemById(1003) as Weapon,
                    Information = "Strikingly strong yet demure",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1003) as Weapon, //dagger
                    }
                }, //Mistress
                new Human()
                {
                    Id = 1003,
                    Name = "The Healer",
                    Location = 100,
                    Kind = Character.Genus.Human,
                    Description = "An old man with a long white beard",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "Take this healing stone and use it now.  This is an artifact that will give you life and health.  You can " +
                        "only use it once, use it wisely."
                    },
                    AttackLevel = 1, //base weapon hp 5
                    CurrentWeapon = GameItemById(1000) as Weapon,
                    Information = "The village Healer",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(2001) as Artifact,  //healing stone
                    }
                }, //Healer
                new Human()
                {
                    Id = 1001,
                    Name = "The Governor",
                    Location = 100,
                    Kind = Character.Genus.Human,
                    Description = "A charismatic strong man, with peircing eyes",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "You appear very ill, go see the healer.  The healer has powerful artifacts that can help you.",
                        "Afer you visit the healer, Jake in the Harbor has been giving the dock workers problems, take care of him.",
                        "The Island holds some deep secrets."
                    },
                    AttackLevel = 5, //attack level 5 by rapier 55 hp 275
                    CurrentWeapon = GameItemById(1002) as Weapon,
                    Information = "The Village Mayor",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                       GameItemById(1002) as Weapon //rapier
                    }

                }, //Governor
                new Human()
                {
                    Id = 1004,
                    Name = "Wizard",
                    Location = 201,
                    Kind = Character.Genus.Human,
                    Description = "An ancient being, good or evil?",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "You surprise me, you made it this far.",
                        "Please give this goblet to the Elf King, fear the Strix, they keep watch of the mountains.",
                        "I am trapped here for eternity."
                    },
                    AttackLevel = 20, // 20 by staff 200 hp 4000
                    CurrentWeapon = GameItemById(1007) as Weapon,
                    Information = "Wizard",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(2003) as Artifact, //goblet of doom
                        GameItemById(1007) as Weapon // lightning staff                   
                    }

                }, //Wizard
                new Human()
                {
                    Id = 1005,
                    Name = "Guardian",
                    Location = 202,
                    Kind = Character.Genus.Human,
                    Description = "Highly trained Elf Guard",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "Hault! Another step and you will meet your doom!",
                        "Do not make me repeat myself."
                    },
                    AttackLevel = 200, // total 1000 
                    CurrentWeapon = GameItemById(1000) as Weapon, // base weapon
                    Information = "Elf High Guard",

                }, //Elf Guard
                new Human()
                {
                    Id = 1006,
                    Name = "Urziekal",
                    Location = 202,
                    Kind = Character.Genus.Human,
                    Description = "Ancient High Elf King",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "Bring me the goblet of doom and you will be rewarded",
                        "I am the only elf to fight the Hellion and live."
                    },
                    AttackLevel = 20, // 20 * 250 5000 
                    CurrentWeapon = GameItemById(1005) as Weapon, // war hammer 250 hp
                    Information = "Highly Respected leader",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1005) as Weapon   // war hammer
                    }

                }, //Elf Ancient
                new Human()
                {
                    Id = 1007,
                    Name = "Jake",
                    Location = 104,
                    Kind = Character.Genus.Human,
                    Description = "Drunk agressive fisherman",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "Get out of here stranger!",
                        "I am going to fight you.",
                        "Fight me!",
                        "Think you can beat me?"
                    },
                    AttackLevel = 1, // total 5
                    CurrentWeapon = GameItemById(1000) as Weapon, // base weapon
                    Information = "Passed out by the boat",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1001) as Weapon //club
                    }

                }, //Fisherman
                new Human()
                {
                    Id = 1008,
                    Name = "Marica",
                    Location = 102,
                    Kind = Character.Genus.Human,
                    Description = "A Peri, a beautiful fairy princess",
                    IsAvailable = false,
                    Messages =  new List<string>()
                    {
                        "Thank you for helping me!  Use this jewel, it will transport you to the cave in the mountains " +
                        "once you are there speak to the wizard.  This artifact can only be used once.  You must have a " +
                        "weapon to make it out of the mountains, a club will not suffice."
                    },
                    AttackLevel = 1, // total 5
                    CurrentWeapon = GameItemById(1000) as Weapon, // base weapon
                    Information = "Appears behind a tall pine",               
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(2005) as Artifact //forest jewel
                    }
                }, //Peri
                new Human()
                {
                    Id = 1010,
                    Name = "Tiddy Mun",
                    Location = 203,
                    Kind = Character.Genus.Human,
                    Description = "Legendary bog spirit",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "Kill that horrible Bunyip!",
                        "Use these spells if you dare!  Ha ha ha!"
                    },
                    AttackLevel = 1, // total 5
                    CurrentWeapon = GameItemById(1000) as Weapon, // base weapon
                    Information = "Awful grotesque thing",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(3001) as Spell, //sleepy ghouls
                        GameItemById(3002) as Spell  //mountain invisibility
                    }

                }, //Tiddy Mun
                new Human()
                {
                    Id = 1011,
                    Name = "Ferry Man",
                    Location = 203,
                    Kind = Character.Genus.Human,
                    Description = "Haunted Spirit of the Sea",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "You wish for a boat ride?",
                        "This is a one way trip",
                        "None shall return.",
                        "You need an amulet to cross."
                    },
                    AttackLevel = 1, // total 5
                    CurrentWeapon = GameItemById(1000) as Weapon, // base weapon
                    Information = "A faceless ghost",
                }, //Ferry Man
                new Human()
                {
                    Id = 1009,
                    Name = "Lost Souls",
                    Location = 204,
                    Kind = Character.Genus.Human,
                    Description = "Souls of the damned",
                    IsAvailable = true,
                    Messages =  new List<string>()
                    {
                        "What do you want from us?",
                        "This is purgatory...",
                        "We can get you home...",
                        "Release us with the war hammer of the Gods."
                    },
                    AttackLevel = 150, // total 750
                    CurrentWeapon = GameItemById(1000) as Weapon, // base weapon
                    Information = "A faceless ghost",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(2006) as Artifact, // home stone
                    }
                }, //Lost souls
                
                //BEASTS
                new Beast()
                {
                    Id = 3001,
                    Name = "Rakshasa",
                    Location = 101,
                    Kind = Character.Genus.Beast,
                    Description = "A shapeshifting demon haunting the mountains",
                    IsAvailable = true,
                    AttackLevel = 50, // 200 with fist x 5 = 500
                    CurrentWeapon = GameItemById(1000) as Weapon, //default weapon class
                    Information = "",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(2004) as Artifact  //home stone
                    }

                }, //Rakshasa
                new Beast()
                {
                    Id = 3002,
                    Name = "Strix",
                    Location = 101,
                    Kind = Character.Genus.Beast,
                    Description = "A enormous bird of prey",
                    IsAvailable = true,
                    AttackLevel = 10, // with talons = 3000
                    CurrentWeapon = GameItemById(1004) as Weapon,
                    Information = "Hell from above",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1004) as Weapon  //strix talons
                    }
                }, //Strix
                new Beast()
                {
                    Id = 3003,
                    Name = "Hell Hounds",
                    Location = 102,
                    Kind = Character.Genus.Beast,
                    Description = "Fearless Hounds that will drag you to hell",
                    IsAvailable = true,
                    AttackLevel = 10, // base weapon x 5 50
                    CurrentWeapon = GameItemById(1000) as Weapon,
                    Information = "Pack attack"
                }, //Hell Hounds
                new Beast()
                {
                    Id = 3006,
                    Name = "Kelpie",
                    Location = 103,
                    Kind = Character.Genus.Beast,
                    Description = "A large white powerful horse",
                    IsAvailable = true,
                    AttackLevel = 50000, // can not kill
                    CurrentWeapon = GameItemById(1000) as Weapon,
                    Information = "Swamp spirit"
                }, //KelPie
                new Beast()
                {
                    Id = 3007,
                    Name = "Bunyip",
                    Location = 103,
                    Kind = Character.Genus.Beast,
                    Description = "A deformed swamp creature of pure muscle",
                    IsAvailable = true,
                    AttackLevel = 17, // 17 x 5 = 85
                    CurrentWeapon = GameItemById(1000) as Weapon,
                    Information = "Feeding on the flesh of the dead",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1006) as Weapon  //long sword
                    }
                }, //Bunyip
                new Beast()
                {
                    Id = 3005,
                    Name = "Ghouls",
                    Location = 204,
                    Kind = Character.Genus.Beast,
                    Description = "Humanoid monstrosity",
                    IsAvailable = true,
                    AttackLevel = 100, // 100 * 500 = 5000
                    CurrentWeapon = GameItemById(1008) as Weapon,
                    Information = "Guarding the souls of the lost",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1008) as Weapon  //hell scythe 500 hp
                    }
                }, //Ghouls
                new Beast()
                {
                    Id = 3004,
                    Name = "The Hellion",
                    Location = 105,
                    Kind = Character.Genus.Beast,
                    Description = "Inferno of Chaos",
                    IsAvailable = true,
                    AttackLevel = 20000, // 20000 * 5 = 100000
                    CurrentWeapon = GameItemById(1000) as Weapon, //base
                    Information = "No one lives to tell"
                }, //Hellion

            };
        }
        public static List<Mission> Missions()
        {
            return new List<Mission>()
            {
                new MissionTravel()
                {
                    Id = 1,
                    Name = "Travel",
                    Description = "Explore different areas to discover items and creatures",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredLocations = new List<Location>()
                    {
                        LocationById(202),
                        LocationById(203),
                        LocationById(204)
                    },
                    ExperiencePoints = 1
                },
                new MissionEngage()
                {
                    Id = 2,
                    Name = "Discover Characters",
                    Description = "Follow directions to meet new people",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredNpcs = new List<Npc>()
                    {
                        NpcById(1001),
                        NpcById(1002),
                        NpcById(1003),
                        NpcById(1006),
                        NpcById(1007),
                        NpcById(1008)
                    },
                    ExperiencePoints = 1
                },
                new MissionGather()
                {
                    Id = 3,
                    Name = "Gathering",
                    Description = "Collect items to help defeat your enemies",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredGameItems = new List<GameItem>()
                    {
                        GameItemById(1001),
                        GameItemById(1004),
                        GameItemById(2001),
                        GameItemById(2002),
                        GameItemById(2003)
                    },
                    ExperiencePoints = 1
                }
            };
        }
        public static ButtonVisibility GameStartButtonView()
        {
            return new ButtonVisibility()
            {
                    IsVillageVisible = false,
                    IsMountainVisible = false,
                    IsForestVisible = false,
                    IsSwampVisible = false,
                    IsHarborVisible = false,
                    IsAbyssVisible = false,
                    IsCaveVisible = false,
                    IsElfHoldVisible = false,
                    IsWitchesCampVisible = false, 
                    IsIslandOfLostSoulsVisible = false,
                    IsHomeVisible = false
        };
        }
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        public static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }
        private static Mission MissionById(int id)
        {
            return Missions().FirstOrDefault(m => m.Id == id);
        }
        public static Location LocationById(int id)
        {
            List<Location> locations = new List<Location>();
            foreach (Location location in MasterGameMap().Locations)
            {
                if (location != null) locations.Add(location);
            }
            return locations.FirstOrDefault(i => i.Id == id);
        }
    }

}
