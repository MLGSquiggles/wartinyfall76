using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Items.StabbyStabber
{
	public class TheStabbyStabber : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Stabby Stabber"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("The Stabbiest stabber to ever stab.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 50;
			Item.melee = true;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 1000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(Mod);
			recipe.AddIngredient(ItemID.CobaltBar, 20);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}