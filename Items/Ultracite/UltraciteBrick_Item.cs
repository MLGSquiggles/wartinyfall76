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

namespace wartinyfall76.Items.Ultracite
{
    public class UltraciteBrick_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultracite Brick");
            Tooltip.SetDefault("Ultracite Brick. \nThe imbedded power crystals absorb some of the radiation");
        }

        public override void SetDefaults()
        {
            // hitbox
            item.width = 20;
            item.height = 20;
            
            item.maxStack = 999;
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
            item.createTile = ModContent.TileType<Tiles.Ultracite.UltraciteBrick_Tile>();


        }
        public override void AddRecipes() //20 ore, 250 stone blocks
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteOre_Item>(), 20);
            recipe.AddIngredient(ItemID.StoneBlock, 250);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}