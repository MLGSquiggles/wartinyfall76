using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Items.Pets
{
	public class AkuAkuItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aku Aku"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Summons Aku Aku to follow you \n'It is I, Aku Aku! My duty is to protect you.'");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.TikiTotem);
			item.shoot = mod.ProjectileType("AkuAkuProjectile"); //clone the existing tiki totem item
			item.buffType = mod.BuffType("AkuAkuBuff");
		}

		public override void UseStyle(Player player)
		{
			if(player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		//public override void AddRecipes() 
		//{
		//	ModRecipe recipe = new ModRecipe(mod);
		//	recipe.AddIngredient(ItemID.CobaltBar, 20);
		//	recipe.AddTile(TileID.Hellforge);
		//	recipe.SetResult(this);
		//	recipe.AddRecipe();
		//}
	}
}