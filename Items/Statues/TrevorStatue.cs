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

namespace wartinyfall76.Items.Statues
{
    public class TrevorStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trevor Statue");
            Tooltip.SetDefault("'It's T-revor time!'");
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
            Item.createTile = ModContent.TileType<Tiles.Statues.TrevorStatueTiles>();


        }
        public override void AddRecipes() //1 ancient manipulator, 25 power crystals, 20 ultracite ore
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.LunarCraftingStation, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Crash.PowerCrystal>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteOre_Item>(), 25);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}