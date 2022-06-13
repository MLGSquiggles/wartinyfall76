using Microsoft.Xna.Framework;
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
			Item.CloneDefaults(ItemID.BoneKey);
			Item.shoot = Mod.Find<ModProjectile>("GreenStaffProjectile").Type; //clone the existing tiki totem item
			Item.buffType = Mod.Find<ModBuff>("GreenStaffBuff").Type;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if(player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
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