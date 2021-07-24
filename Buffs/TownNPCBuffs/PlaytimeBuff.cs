//using IL.Terraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace wartinyfall76.Buffs.TownNPCBuffs
{
	public class PlaytimeBuff : ModBuff
	{
		bool spawnedExplosive = false;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Klee's Playtime!");
			Description.SetDefault("Grants extra defense and the ability for extra explosives to be launched!");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing

		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 4;
			player.statLife += 20;

			if (player.controlUseItem && !spawnedExplosive)
			{
				spawnedExplosive = true;
				Vector2 vector;
				vector.X = player.velocity.X;
				vector.Y = -5.0f - player.velocity.Y; //terraria's y is inverted???
				Projectile.NewProjectile(player.position, vector, ProjectileID.ExplosiveBunny, 35, 0, Main.myPlayer);
				//Main.projectile[shoot].friendly = true;

			}

			if (player.releaseUseItem || player.delayUseItem)
			{
				spawnedExplosive = false;
			}
		}


	}
}