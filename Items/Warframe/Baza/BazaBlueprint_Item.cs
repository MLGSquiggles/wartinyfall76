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
            item.width = 50;
            item.height = 32;
            
            item.maxStack = 99;
            item.value = 18000;
            item.rare = 11;
            item.consumable = true;
            // Set other item.X values here
            // Usage
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            //create tile
            item.createTile = ModContent.TileType<Tiles.Blueprints.BazaBlueprintTiles>();


        }
        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}