using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Projectiles.Ultracite
{
	public class GuideHexDollShot : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			Main.projFrames[projectile.type] = 3; //8 frames in sheet
			//Main.projPet[projectile.type] = true; //marking this as a pet
		}

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.Skull);
			aiType = ProjectileID.Skull;
			
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(BuffID.Cursed, 20);
			target.AddBuff(BuffID.ShadowFlame, 20);
			target.AddBuff(BuffID.Venom, 20);
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(BuffID.Cursed, 20);
			target.AddBuff(BuffID.ShadowFlame, 20);
			target.AddBuff(BuffID.Venom, 20);
		}

		//public override bool PreAI()
		//{
		//	Player player = Main.player[projectile.owner];
		//	player.tiki = false; //tiki spirit i think?
		//	return true;
		//}

		//public override void AI()
		//{
		//	Player player = Main.player[projectile.owner];
		//	wartinyfall76Player modPlayer = player.GetModPlayer<wartinyfall76Player>();

		//	if(player.dead)
		//	{
		//		//if player is dead, deactivate
		//		modPlayer.AkuAkuPet = false;
		//	}
		//	if(modPlayer.AkuAkuPet)
		//	{
		//		//if projectile is alive, its existence is set to 2 seconds, no longer gets set if disabled
		//		projectile.timeLeft = 2;
		//	}
		//}
	}
}