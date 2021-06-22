using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace wartinyfall76.Items.Ultracite.Tools
{
    public class UltracitePickaxe_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultracite Pickaxe"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("Mine the earth's core with radiation.");
        }

        public override void SetDefaults()
        {
            // hitbox
            item.width = 34;
            item.height = 34;
            // value
            item.value = 100000;
            item.rare = 11;
            // useage
            item.useTime = 6; // test????
            item.useAnimation = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            //axe properties
            item.pick = 36;
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
