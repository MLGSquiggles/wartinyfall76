using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using wartinyfall76.NPCs.Scorched;


//

namespace wartinyfall76
{

    public class WartinyfallGlobalNPC : GlobalNPC
    {
        //Change the spawn pool
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            //If the custom invasion is up and the invasion has reached the spawn pos
            if (wartinyfall76World.ScorchedInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                //Clear pool so that only the stuff you want spawns
                pool.Clear();

                //key = NPC ID | value = spawn weight
                //pool.add(key, value)

                //For every ID inside the invader array in our CustomInvasion file
                foreach (int i in ScorchedEarth.invader)
                {
                    pool.Add(i, 1f); //Add it to the pool with the same weight of 1
                }
            }
        }

        //Changing the spawn rate
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            //Change spawn stuff if invasion up and invasion at spawn
            if (wartinyfall76World.ScorchedInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                spawnRate = 50; //The higher the number, the less chance it will spawn 100 was default in example
                maxSpawns = 10000; //Max spawns of NPCs depending on NPC value
            }
        }

        //Adding to the AI of an NPC
        public override void PostAI(NPC npc)
        {
            //Changes NPCs so they do not despawn when invasion up and invasion at spawn
            if (wartinyfall76World.ScorchedInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                npc.timeLeft = 1000;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            //When an NPC (from the invasion list) dies, add progress by decreasing size
            if (wartinyfall76World.ScorchedInvasionUp)
            {
                //Gets IDs of invaders from CustomInvasion file
                foreach (int invader in ScorchedEarth.invader)
                {
                    //If npc type equal to invader's ID decrement size to progress invasion
                    if (npc.type == invader)
                    {
                        Main.invasionSize -= 1;
                    }
                }
            }
        }
    }
}



        

        
    

