using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using wartinyfall76.Tiles.Ultracite;

namespace wartinyfall76.Items.Ultracite.Scorched
{
	public class UltraciteGuideHexDoll : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ultracite Guide Hex Doll"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Well at least it doesn't affect the real guide...");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.magic = true;
			//item.mana = 12;
			//item.width = 75;
			//item.height = 32;
			item.useTime = 5;
			item.useAnimation = 5;
			//item.useStyle = ItemUseStyleID.HoldingOut;
			//item.CloneDefaults(ItemID.ShadowFlameHexDoll);
			item.knockBack = 69;
			item.value = 10000;
			item.rare = 11;
			item.width = 32;
			item.height = 32;
			item.mana = 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = SoundID.Item65;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GuideHexDollShot"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 13f; // the speed of the projectile (measured in pixels per frame)
			//item.useAmmo = AmmoID.Bullet;  // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		
		public override void AddRecipes() //baza recepie 1 sc unicorn horn, 2 guide dolls, 1 sflame doll, 10 ultracite bar
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.Scorched.UltraciteUnicornHorn>(), 1);
			recipe.AddIngredient(ItemID.GuideVoodooDoll, 2);
			recipe.AddIngredient(ItemID.ShadowFlameHexDoll, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Ultracite.UltraciteBar_Item>(), 10);
			recipe.AddTile(ModContent.TileType<Tiles.Ultracite.UltracideManipulatorTiles>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		} 
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
	}

}
