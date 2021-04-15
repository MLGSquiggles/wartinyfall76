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
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using wartinyfall76.Items.Ultracite;
using System.Net;
using System.Runtime.CompilerServices;

namespace wartinyfall76
{
    public class wartinyfall76World : ModWorld
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
    }
}
