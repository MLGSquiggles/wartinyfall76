using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;
using wartinyfall76.Items.Ultracite;
using System.Net;
using System.Runtime.CompilerServices;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using wartinyfall76.NPCs.Scorched;

namespace wartinyfall76
{
    public class wartinyfall76World : ModSystem
    {


        #region GENERATION
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
           int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
           if(shiniesIndex != -1) 
           {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Ultracite Ore Spawn", GenerateUltraciteOre));
           }
        }
       
        private void GenerateUltraciteOre(GenerationProgress progress)
        {
            progress.Message = "spawning Ultracite Ore";
            for(var i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
            {
                int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 500);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 6),
                    ModContent.TileType<Tiles.Ultracite.UltraciteOre_Tile>());


            }
        }
        #endregion

        #region BOSSFLAGS
        public static bool DownedBendyBoss = false;

        #endregion

        #region INVASION

        //Setting up variables for invasion -- ScorchedEarth
        public static bool ScorchedInvasionUp = false;
        public static bool downedScorchedInvasion = false;

        //Initialize all variables to their default values
        public override void OnWorldLoad()
        {
            Main.invasionSize = 0;
            ScorchedInvasionUp = false;
            downedScorchedInvasion = false;
            DownedBendyBoss = false;
        }

        //Save downed data
        public override void SaveWorldData(TagCompound tag)/* Suggestion: Edit tag parameter rather than returning new TagCompound */
        {
            var Downed = new List<string>();
            if (downedScorchedInvasion) Downed.Add("scorchedInvasion");
            if (DownedBendyBoss) Downed.Add("Bendy");

            return new TagCompound 
            {
                {"Downed", Downed}
            };

        }

        //Load downed data
        public override void LoadWorldData(TagCompound tag)
        {
            var Downed = tag.GetList<string>("Downed");
            downedScorchedInvasion = Downed.Contains("scorchedInvasion");
            DownedBendyBoss = Downed.Contains("Bendy");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            {
                BitsByte flags = reader.ReadByte();
                downedScorchedInvasion = flags[0];
                DownedBendyBoss = flags[0];
            }
        }

        //Sync downed data
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedScorchedInvasion;
            flags[0] = DownedBendyBoss;
            writer.Write(flags);
        }

        //Sync downed data
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedScorchedInvasion = flags[0];
            DownedBendyBoss = flags[0];
        }

        //Allow to update invasion while game is running
        public override void PostUpdateWorld()
        {
            if (ScorchedInvasionUp)
            {
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    //Checks progress and reports progress only if invasion at spawn
                    ScorchedEarth.CheckCustomInvasionProgress();
                }
                //Updates the custom invasion while it heads to spawn point and ends it
                ScorchedEarth.UpdateCustomInvasion();
            }
        }
        #endregion

        
    }
}

