using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using wartinyfall76.Tiles.Ultracite;

namespace wartinyfall76.Items.Warframe.Baza
{
	public class Baza_Item : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Baza"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The Baza is a silenced, rapid-fire Tenno submachine gun with a high critical chance.");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.ranged = true;
			item.width = 75;
			item.height = 32;
			item.useTime = (int)3.75;
			item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 69;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 13f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet;  // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		
		public override void AddRecipes() //baza recepie 1 baza bp, 8 bars, 1 frost core, 1
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Warframe.Baza.BazaBlueprint_Item>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1); //forbidden fragment 3783
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		} 
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
	}

}
