using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


//Scorched derpling. Spawns during Scorched Earth Event

namespace wartinyfall76.NPCs.Scorched
{
    //[AutoloadHead]
    public class ScorchedDukeFIshronNPC : ModNPC
    {
        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Scorched/ScorchedDukeFishronNPC"; }
        }

        //setup defaults
        public override void SetStaticDefaults()
        {
            //name when you hover over it
            DisplayName.SetDefault("Scorched Duke Fishron");

            Main.npcFrameCount[npc.type] = 8; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Scorched Duke Fishron";
            return mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Scorched Duke Fishron";
        }
        public override void SetDefaults()
        {

            npc.width = 150;
            npc.height = 100;
            npc.aiStyle = -1; //Custom AI
            npc.damage = 300;
            npc.defense = 20;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit22;
            npc.DeathSound = SoundID.NPCDeath23; //crimson death sound
            npc.knockBackResist = 0f;
            npc.value = 20f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.netAlways = true;
			npc.npcSlots = 4;

            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            

            //use these if copying an existing thing from terraria
            //aiType = NPCID.Derpling;
            animationType = NPCID.DukeFishron;

            //get NPC to banner -- uses standard zombie
            //banner = Item.NPCtoBanner(NPCID.Derpling);
            //then link it back
            //bannerItem = Item.BannerToItem(banner);
        }

        //spawn in the overworld as a test, eventually spawn in during event
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //if (wartinyfall76World.ScorchedInvasionUp)
            //{
            //    return 0.5f;
            //}
            //else
            //{
            //    return 0;
            //}
            return 0;
        }

        public override void AI()
        {
			//base game duke fishron ai wtf is this mess... AAAAAAAAAAAAAAAAAAAAAA

			int num6 = 80;
			int num7 = 4;
			float num8 = 0.3f;
			float scaleFactor2 = 5f;
			int num9 = 90;
			int num10 = 180;
			int num11 = 180;
			int num12 = 30;
			int num13 = 120;
			int num14 = 4;
			float scaleFactor3 = 6f;
			float scaleFactor4 = 20f;
			float num15 = (float)Math.PI * 2f / (float)(num13 / 2);
			int num16 = 75;
			Vector2 center = base.npc.Center;
			Player player = Main.player[npc.target];
			if (npc.target < 0 || npc.target == 255 || player.dead || !player.active || Vector2.Distance(player.Center, center) > 5600f)
			{
				npc.TargetClosest();
				player = Main.player[npc.target];
				npc.netUpdate = true;
			}
			if (player.dead || Vector2.Distance(player.Center, center) > 5600f)
			{
				npc.velocity.Y -= 0.4f;
				
			}

			if (npc.localAI[0] == 0f)
			{
				npc.localAI[0] = 1f;
				npc.alpha = 255;
				npc.rotation = 0f;
				if (Main.netMode != 1)
				{
					npc.ai[0] = -1f;
					npc.netUpdate = true;
				}
			}
			float num17 = (float)Math.Atan2(player.Center.Y - center.Y, player.Center.X - center.X);
			if (npc.spriteDirection == 1)
			{
				num17 += (float)Math.PI;
			}
			if (num17 < 0f)
			{
				num17 += (float)Math.PI * 2f;
			}
			if (num17 > (float)Math.PI * 2f)
			{
				num17 -= (float)Math.PI * 2f;
			}
			if (npc.ai[0] == -1f)
			{
				num17 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num17 = 0f;
			}
			if (npc.ai[0] == 4f)
			{
				num17 = 0f;
			}
			if (npc.ai[0] == 8f)
			{
				num17 = 0f;
			}
			float num18 = 0.04f;
			if (npc.ai[0] == 1f || npc.ai[0] == 6f)
			{
				num18 = 0f;
			}
			if (npc.ai[0] == 7f)
			{
				num18 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num18 = 0.01f;
			}
			if (npc.ai[0] == 4f)
			{
				num18 = 0.01f;
			}
			if (npc.ai[0] == 8f)
			{
				num18 = 0.01f;
			}
			if (npc.rotation < num17)
			{
				if ((double)(num17 - npc.rotation) > Math.PI)
				{
					npc.rotation -= num18;
				}
				else
				{
					npc.rotation += num18;
				}
			}
			if (npc.rotation > num17)
			{
				if ((double)(npc.rotation - num17) > Math.PI)
				{
					npc.rotation += num18;
				}
				else
				{
					npc.rotation -= num18;
				}
			}
			if (npc.rotation > num17 - num18 && npc.rotation < num17 + num18)
			{
				npc.rotation = num17;
			}
			if (npc.rotation < 0f)
			{
				npc.rotation += (float)Math.PI * 2f;
			}
			if (npc.rotation > (float)Math.PI * 2f)
			{
				npc.rotation -= (float)Math.PI * 2f;
			}
			if (npc.rotation > num17 - num18 && npc.rotation < num17 + num18)
			{
				npc.rotation = num17;
			}
			if (npc.ai[0] != -1f && npc.ai[0] < 9f)
			{
				if (Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					npc.alpha += 15;
				}
				else
				{
					npc.alpha -= 15;
				}
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				if (npc.alpha > 150)
				{
					npc.alpha = 150;
				}
			}
			if (npc.ai[0] == -1f)
			{
				npc.velocity *= 0.98f;
				int num19 = Math.Sign(player.Center.X - center.X);
				if (num19 != 0)
				{
					npc.direction = num19;
					npc.spriteDirection = -npc.direction;
				}
				if (npc.ai[2] > 20f)
				{
					npc.velocity.Y = -2f;
					npc.alpha -= 5;
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.alpha += 15;
					}
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					if (npc.alpha > 150)
					{
						npc.alpha = 150;
					}
				}
				if (npc.ai[2] == (float)(num9 - 30))
				{
					int num20 = 36;
					for (int i = 0; i < num20; i++)
					{
						Vector2 value = (Vector2.Normalize(npc.velocity) * new Vector2((float)npc.width / 2f, npc.height) * 0.75f * 0.5f).RotatedBy((float)(i - (num20 / 2 - 1)) * ((float)Math.PI * 2f) / (float)num20) + base.npc.Center;
						Vector2 value2 = value - base.npc.Center;
						int num21 = Dust.NewDust(value + value2, 0, 0, 172, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num21].noGravity = true;
						Main.dust[num21].noLight = true;
						Main.dust[num21].velocity = Vector2.Normalize(value2) * 3f;
					}
					//SoundEngine.PlaySound(29, (int)center.X, (int)center.Y, 20);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num16)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
		}

        public override void HitEffect(int hitDirection, double damage)
        {
            //create dust on being hit
            for (int i = 0; i < 10; i++)
            {
                int dustType = DustID.JungleSpore;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X * Main.rand.Next(-50, 50) * 0.01f;
                dust.velocity.Y = dust.velocity.Y * Main.rand.Next(-50, 50) * 0.01f;
                dust.scale *= 1 + Main.rand.Next(-30, 30) * 0.01f;
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("UltraciteOre_Item"));
            }

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("UltraciteTsunami"));
            }

        }






    }
}
