using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace wartinyfall76.Items.Ultracite.Tools
{
    public class UltraciteAxe_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultracite Axe"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("Chops down trees with MEGA radiation energy.");
        }

        public override void SetDefaults()
        {
            // hitbox
            item.width = 50;
            item.height = 40;
            // value
            item.value = 100000;
            item.rare = 11;
            // useage
            item.useTime = 14; // test????
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            //axe properties
            item.axe = 36;
            // weapon settings
            item.melee = true;
            item.damage = 130;
            item.knockBack = 7;
        }

        public override void AddRecipes() // add power crystals
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteBar_Item>(), 20);
            recipe.AddTile(TileID.LunarCraftingStation); // add custom one later
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
