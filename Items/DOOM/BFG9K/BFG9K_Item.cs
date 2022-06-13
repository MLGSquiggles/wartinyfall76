using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace wartinyfall76.Items.DOOM.BFG9K
{
	public class BFG9K_Item : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("BFG9K"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Warning, the Slayer has entered the facility!.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 5000;
			Item.ranged = true;
			Item.width = 75;
			Item.height = 32;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 69;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 5f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.Bullet;  // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		/*
		public override void AddRecipes() 
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.CobaltBar, 20);
			//recipe.AddTile(TileID.Hellforge);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		} 
		*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}
	}

}
