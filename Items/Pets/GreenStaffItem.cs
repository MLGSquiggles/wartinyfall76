using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Items.Pets
{
	public class GreenStaffItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sentient Chlorophyte Partisan"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Summons Sentient Chlorophyte Partisan to follow you \n'One of the Glitched Anomaly's artifacts'");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.BoneKey);
			item.shoot = mod.ProjectileType("GreenStaffProjectile"); //clone the existing tiki totem item
			item.buffType = mod.BuffType("GreenStaffBuff");
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