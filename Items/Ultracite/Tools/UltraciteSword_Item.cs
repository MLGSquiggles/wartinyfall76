using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace wartinyfall76.Items.Ultracite.Tools
{
    public class UltraciteSword_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultracite Sword"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("OMAE WA MOU SHINDEIRU.../n...NANI!!!!!.");
        }

        public override void SetDefaults()
        {
            // hitbox
            item.width = 50;
            item.height = 50;
            // value
            item.value = 100000;
            item.rare = 11;
            // useage
            item.useTime = 16; // test????
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            //axe properties
            // item.axe = 30;
            // weapon settings
            item.melee = true;
            item.damage = 215;
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
