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

namespace wartinyfall76.Items.Warframe.Baza
{
    public class BazaBlueprint_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baza Blueprint");
            Tooltip.SetDefault("Used in crafting the Baza \nCan be placed.");
        }

        public override void SetDefaults()
        {
            // hitbox
            Item.width = 50;
            Item.height = 32;
            
            Item.maxStack = 99;
            Item.value = 18000;
            Item.rare = 11;
            Item.consumable = true;
            // Set other item.X values here
            // Usage
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            //create tile
            Item.createTile = ModContent.TileType<Tiles.Blueprints.BazaBlueprintTiles>();


        }
        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}