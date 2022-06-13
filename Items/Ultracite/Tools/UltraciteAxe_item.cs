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
            Item.width = 50;
            Item.height = 40;
            // value
            Item.value = 100000;
            Item.rare = 11;
            // useage
            Item.useTime = 14; // test????
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            //axe properties
            Item.axe = 36;
            // weapon settings
            Item.melee = true;
            Item.damage = 130;
            Item.knockBack = 7;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes() // add power crystals
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteBar_Item>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Items.Crash.PowerCrystal>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.Ultracite.UltracideManipulatorTiles>()); // add custom one later
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
