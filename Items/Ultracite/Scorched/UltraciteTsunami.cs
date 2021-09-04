using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using wartinyfall76.Tiles.Ultracite;

namespace wartinyfall76.Items.Ultracite.Scorched
{
	public class UltraciteTsunami : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ultracite Tsunami"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Duke Fishron's mighty bow, irradiated by the scorched plague!");
		}

		public override void SetDefaults() 
		{
			item.damage = 169;
			item.ranged = true;
			//item.width = 75;
			//item.height = 32;
			//item.useTime = (int)3.75;
			//item.useAnimation = 60;
			item.CloneDefaults(ItemID.Tsunami);

			//item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 69;
			item.value = 100000;
			item.rare = 11;
			//item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			//item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 50f; // the speed of the projectile (measured in pixels per frame)
			//item.useAmmo = AmmoID.Bullet;  // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		
		//drops by scorched duke fishron
		//public override void AddRecipes() //baza recepie 1 baza bp, 8 bars, 1 frost core, 1
		//{
		//	ModRecipe recipe = new ModRecipe(mod);
		//	recipe.AddIngredient(ModContent.ItemType<Items.Warframe.Baza.BazaBlueprint_Item>(), 1);
		//	recipe.AddIngredient(ItemID.HallowedBar, 8);
		//	recipe.AddIngredient(ItemID.FrostCore, 1);
		//	recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1); //forbidden fragment 3783
		//	recipe.AddTile(TileID.Anvils);
		//	recipe.SetResult(this);
		//	recipe.AddRecipe();
		//} 
		
		
	}

}
