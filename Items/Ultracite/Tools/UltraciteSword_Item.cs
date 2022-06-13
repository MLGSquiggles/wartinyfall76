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
            Item.width = 50;
            Item.height = 50;
            // value
            Item.value = 100000;
            Item.rare = 11;
            // useage
            Item.useTime = 16; // test????
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            //axe properties
            // item.axe = 30;
            // weapon settings
            Item.melee = true;
            Item.damage = 215;
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
