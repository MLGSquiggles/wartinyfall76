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
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1;
			Item.maxStack = 99;			
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item123;
			Item.useStyle = 1; //1 is swing, 4 is hold up
			Item.consumable = true;
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.rare = 3;
		}

		public override bool? UseItem(Player player)/* Suggestion: Return null instead of false */
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
			ModRecipe recipe = new ModRecipe(Mod);
			recipe.AddIngredient(ItemID.CobaltBar, 20);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}