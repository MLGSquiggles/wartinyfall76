using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace wartinyfall76.Items.Sims
{
    public class GolovyGuitar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golovy Guitar"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("Rock on like the LEGENDARY Khrust Golovy!");
        }

        public override void SetDefaults()
        {
            // hitbox
            item.width = 56;
            item.height = 46;
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
            item.UseSound = SoundID.Item47;
        }

        //public override void AddRecipes() // add power crystals
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteBar_Item>(), 16);
        //    recipe.AddIngredient(ModContent.ItemType<Items.Crash.PowerCrystal>(), 4);
        //    recipe.AddTile(ModContent.TileType<Tiles.Ultracite.UltracideManipulatorTiles>()); // add custom one later
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}
