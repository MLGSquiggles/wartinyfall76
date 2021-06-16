using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Items.DOOM.BFG9K
{
	public class BFG9K_Item : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("BFG9K); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Warning, the Slayer has entered the facility!.");
		}

		public override void SetDefaults() 
		{
			item.damage = 500;
			item.ranged = true;
			item.width = 75;
			item.height = 42;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 69;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;][]
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 10f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet;  // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
	}

		public override void AddRecipes() 
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.CobaltBar, 20);
			//recipe.AddTile(TileID.Hellforge);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}
	}
}