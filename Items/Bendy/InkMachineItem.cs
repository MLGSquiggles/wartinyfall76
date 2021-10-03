using Microsoft.Xna.Framework;
using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace wartinyfall76.Items.Bendy
{
    public class InkMachineItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ink Machine");
            Tooltip.SetDefault("The Inkiest Of All Machines");
        }

        public override void SetDefaults()
        {
            // hitbox
            item.width = 89;
            item.height = 64;
            
            item.maxStack = 1;
            item.value = 19000;
            item.rare = 11;
            item.consumable = true;
            // Set other item.X values here
            // Usage
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            //create tile
            item.createTile = ModContent.TileType<Tiles.Bendy.InkMachineTile>();


        }
        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}