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
			Item.damage = 50;
			Item.magic = true;
			//item.mana = 12;
			//item.width = 75;
			//item.height = 32;
			Item.useTime = 5;
			Item.useAnimation = 5;
			//item.useStyle = ItemUseStyleID.HoldingOut;
			//item.CloneDefaults(ItemID.ShadowFlameHexDoll);
			Item.knockBack = 69;
			Item.value = 10000;
			Item.rare = 11;
			Item.width = 32;
			Item.height = 32;
			Item.mana = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item65;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("GuideHexDollShot").Type; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 13f; // the speed of the projectile (measured in pixels per frame)
			//item.useAmmo = AmmoID.Bullet;  // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		
		public override void AddRecipes() //baza recepie 1 sc unicorn horn, 2 guide dolls, 1 sflame doll, 10 ultracite bar
		{
			ModRecipe recipe = new ModRecipe(Mod);
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
