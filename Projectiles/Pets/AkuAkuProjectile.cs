using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Projectiles.Pets
{
	public class AkuAkuProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			Main.projFrames[projectile.type] = 8; //8 frames in sheet
			Main.projPet[projectile.type] = true; //marking this as a pet
		}

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.TikiSpirit);
			aiType = ProjectileID.TikiSpirit;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.tiki = false; //tiki spirit i think?
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			wartinyfall76Player modPlayer = player.GetModPlayer<wartinyfall76Player>();

			if(player.dead)
			{
				//if player is dead, deactivate
				modPlayer.AkuAkuPet = false;
			}
			if(modPlayer.AkuAkuPet)
			{
				//if projectile is alive, its existence is set to 2 seconds, no longer gets set if disabled
				projectile.timeLeft = 2;
			}
		}
	}
}