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
            Item.width = 20;
            Item.height = 20;
            
            Item.maxStack = 999;
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
            Item.createTile = ModContent.TileType<Tiles.Ultracite.UltraciteBrick_Tile>();


        }
        public override void AddRecipes() //20 ore, 250 stone blocks
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteOre_Item>(), 20);
            recipe.AddIngredient(ItemID.StoneBlock, 250);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}