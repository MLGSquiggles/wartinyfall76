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
            Item.width = 89;
            Item.height = 64;
            
            Item.maxStack = 1;
            Item.value = 19000;
            Item.rare = 11;
            Item.consumable = true;
            // Set other item.X values here
            // Usage
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            //create tile
            Item.createTile = ModContent.TileType<Tiles.Bendy.InkMachineTile>();


        }
        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}