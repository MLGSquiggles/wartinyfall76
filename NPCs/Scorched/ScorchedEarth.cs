using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using wartinyfall76;

namespace wartinyfall76.NPCs.Scorched
{
    
    class ScorchedEarth
    {
        
        //Initializing an Array that can be used in any file
        public static int[] invader = {            
            ModLoader.GetMod("wartinyfall76").NPCType("Scorched Zombie"), //idk but this was being weird
             ModLoader.GetMod("wartinyfall76").NPCType("Scorched Voodoo Demon"),
             ModLoader.GetMod("wartinyfall76").NPCType("Scorched Derpling")
        };

        //Setup for an Invasion
        public static void StartCustomInvasion()
        {
            //Main.NewText("Debug StartCustomInvasionCalled", 175, 75, 255, false);
            //Set to no invasion if one is present
            if (Main.invasionType != 0 && Main.invasionSize == 0)
            {
                Main.invasionType = 0;
                //Main.NewText("Debug invasion Type set to 0", 175, 75, 255, false);
            }

            //Once it is set to no invasion setup the invasion
            if (Main.invasionType == 0)
            {
                //Main.NewText("Start Checking for player", 175, 75, 255, false);
                //Checks amount of players for scaling
                int numPlayers = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active)
                    {
                        numPlayers++;
                        //Main.NewText("Debug Found Player", 175, 75, 255, false);
                    }
                }
                if (numPlayers > 0)
                {
                    //Main.NewText("Start assigning values", 175, 75, 255, false);
                    //Invasion setup
                    Main.invasionType = -1; //Not going to be using an invasion that is positive since those are vanilla invasions
                    wartinyfall76World.ScorchedInvasionUp = true;
                    Main.invasionSize = 150 * numPlayers;
                    Main.invasionSizeStart = Main.invasionSize;
                    Main.invasionProgress = 0;
                    Main.invasionProgressIcon = 0 + 3;
                    Main.invasionProgressWave = 0;
                    Main.invasionProgressMax = Main.invasionSizeStart;
                    //Main.invasionWarn = 3600; //This doesn't really matter, as this does not work, I like to keep it here anyways
                    //if (Main.rand.Next(2) == 0)
                    //{
                        //Main.invasionX = 0.0; //Starts invasion immediately rather than wait for it to spawn
                        //return;
                    //}

                    Main.invasionX = (double)Main.maxTilesX; //Set the initial starting location of the invasion to max tiles
                    //Main.NewText("Debug end of assigning values", 175, 75, 255, false);
                    return;
                }
            }
        }

        //Text for messages and syncing
        public static void CustomInvasionWarning()
        {
            String text = "";
            if (Main.invasionX == (double)Main.spawnTileX)
            {
                text = "Scorched creatures have arrived!";
            }
            if (Main.invasionSize <= 0)
            {
                text = "Scorched Earth has been defeated.";
            }
            if (Main.netMode == 0)
            {
                Main.NewText(text, 175, 75, 255, false);
                return;
            }
            if (Main.netMode == 2)
            {
                //Sync with net
                NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0);
            }
        }

        //Updating the invasion
        public static void UpdateCustomInvasion()
        {
            //If the custom invasion is up
            if (wartinyfall76World.ScorchedInvasionUp)
            {
                //End invasion if size less or equal to 0
                if (Main.invasionSize <= 0) //at the start on a singleplayer world should be 100
                {
                    wartinyfall76World.ScorchedInvasionUp = false;
                    CustomInvasionWarning();
                    Main.invasionType = 0;
                    Main.invasionDelay = 0;
                }

                //Do not do the rest if invasion already at spawn
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    return;
                }

                //Update when the invasion gets to Spawn
                float moveRate = (float)Main.dayRate;

                //If the invasion is greater than the spawn position
                if (Main.invasionX > (double)Main.spawnTileX)
                {
                    //Decrement invasion x as to "move them"
                    Main.invasionX -= (double)moveRate;

                    //If less than the spawn pos, set invasion pos to spawn pos and warn players that invaders are at spawn
                    if (Main.invasionX <= (double)Main.spawnTileX)
                    {
                        Main.invasionX = (double)Main.spawnTileX;
                        CustomInvasionWarning();
                    }
                    else
                    {
                        Main.invasionWarn--;
                    }
                }
                else
                {
                    //Same thing as the if statement above, just it is from the other side
                    if (Main.invasionX < (double)Main.spawnTileX)
                    {
                        Main.invasionX += (double)moveRate;
                        if (Main.invasionX >= (double)Main.spawnTileX)
                        {
                            Main.invasionX = (double)Main.spawnTileX;
                            CustomInvasionWarning();
                        }
                        else
                        {
                            Main.invasionWarn--;
                        }
                    }
                }
            }
        }

        //Checks the players' progress in invasion
        public static void CheckCustomInvasionProgress()
        {
            //Not really sure what this is
            if (Main.invasionProgressMode != 2)
            {
                Main.invasionProgressNearInvasion = false;
                return;
            }
            //Checks if NPCs are in the spawn area to set the flag, which I do not know what it does
            bool flag = false;
            Player player = Main.player[Main.myPlayer];
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            int num = 5000;
            int icon = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active)
                {
                    icon = 0;
                    int type = Main.npc[i].type;
                    for (int n = 0; n < invader.Length; n++)
                    {
                        if (type == invader[n])
                        {
                            Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
                            if (rectangle.Intersects(value))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            Main.invasionProgressNearInvasion = flag;
            int progressMax3 = 1;

            //If the custom invasion is up, set the max progress as the initial invasion size
            if (wartinyfall76World.ScorchedInvasionUp)
            {
                progressMax3 = Main.invasionSizeStart;
            }

            //If the custom invasion is up and the enemies are at the spawn pos
            if (wartinyfall76World.ScorchedInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                //Shows the UI for the invasion
                Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
            }

            //Syncing start of invasion
            foreach (Player p in Main.player)
            {
                NetMessage.SendData(78, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
            }
        }
    }


}

