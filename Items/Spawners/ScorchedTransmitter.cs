using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using wartinyfall76.NPCs.Scorched;

namespace wartinyfall76.Items.Spawners
{
	public class ScorchedTransmitter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Scorched Transmitter"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Summons the Scorched Earth Event.");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.scale = 1;
			item.maxStack = 99;			
			item.useTime = 30;
			item.useAnimation = 30;
			item.UseSound = SoundID.Item123;
			item.useStyle = 1; //1 is swing, 4 is hold up
			item.consumable = true;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 3;
		}

		public override bool UseItem(Player player)
		{
			if (!wartinyfall76World.ScorchedInvasionUp)
			{
				Main.NewText("The Scorched respond to your radio call........", 175, 75, 255, false);
				ScorchedEarth.StartCustomInvasion();
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 20);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}