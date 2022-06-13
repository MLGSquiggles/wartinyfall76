//using IL.Terraria;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Buffs.Pets
{
	public class GreenStaffBuff : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chlorophyte Partisan"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Description.SetDefault("A sentient Chlorophyte Partisan is following you...");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
			
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 180000;
			player.GetModPlayer<wartinyfall76Player>().GreenStaffPet = true;
			//if we dont already have this as a pet
			bool petProjectileNotSpawned = player.ownedProjectileCounts[Mod.Find<ModProjectile>("GreenStaffProjectile").Type] <= 0;
			if(petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width * 0.5), player.position.Y +(float)(player.height * 0.5), 0f, 0f, Mod.Find<ModProjectile>("GreenStaffProjectile").Type, 0, 0f, player.whoAmI, 0f,0f);
			}
		}


	}
}