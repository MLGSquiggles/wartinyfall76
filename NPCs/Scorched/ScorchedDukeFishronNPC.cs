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
		private int aiState; //state the ai is in
		private float aiStateIterator; 
		private float AiChanger = 400; //how long between ai changes - 

		private int aiIncrementOne;
		private int aiIncrementTwo;
		private int aiIncrementThree;

		

		//update aistates based on code
		//private void UpdateAiState
		//{
		//	if(aiState == 1)
		//	{

		//	}
		//}


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

            Main.npcFrameCount[NPC.type] = 8; //amount of sprites in the sprite sheet
        }

        public override bool Autoload(ref string name)
        {
            name = "Scorched Duke Fishron";
            return Mod.Properties.Autoload;
        }

        //for some reason this is needed to display the name when you hover over it?????
        public override string TownNPCName()
        {
            return "Scorched Duke Fishron";
        }
        public override void SetDefaults()
        {

            NPC.width = 150;
            NPC.height = 100;
            NPC.aiStyle = 5; //Custom AI //-1
            NPC.damage = 300;
            NPC.defense = 20;
            NPC.lifeMax = 50000;
            NPC.HitSound = SoundID.NPCHit22;
            NPC.DeathSound = SoundID.NPCDeath23; //crimson death sound
            NPC.knockBackResist = 0f;
            NPC.value = 20f;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.netAlways = true;
			NPC.npcSlots = 4;

            NPC.buffImmune[BuffID.Confused] = true;
            NPC.buffImmune[BuffID.ShadowFlame] = true;
            

            //use these if copying an existing thing from terraria
            AIType = NPCID.MeteorHead;
            AnimationType = NPCID.DukeFishron;

			//get NPC to banner -- uses standard zombie
			//banner = Item.NPCtoBanner(NPCID.Derpling);
			//then link it back
			//bannerItem = Item.BannerToItem(banner);
			aiState = 1;

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
			if (Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
			{
				NPC.alpha += 15;
			}
			else
			{
				NPC.alpha -= 15;
			}
			if (NPC.alpha < 0)
			{
				NPC.alpha = 0;
			}
			if (NPC.alpha > 150)
			{
				NPC.alpha = 150;
			}
		}

				/*public override void AI()
				{
					//base game duke fishron ai wtf is this mess... AAAAAAAAAAAAAAAAAAAAAA
					//uhhhhhh this is nightmare stuff, a messy mess mess mess MESS!

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
					npc.netAlways = true;

					double time = Main.time;

					//int intTime = (int)time;
					//Get the decimal points of time.
					//double deltaTime = time - intTime;
					//multiply them by 60. Minutes, probably
					//deltaTime = (int)(deltaTime * 60.0);

					aiStateIterator++;

					if (aiStateIterator <= AiChanger)
					{
						aiState++;

						if (aiState <= 10)
						{
							aiState = 1;
						}
					}


					//get player target
					if (npc.target < 0 || npc.target == 255 || player.dead || !player.active || Vector2.Distance(player.Center, center) > 5600f)
					{
						npc.TargetClosest();
						player = Main.player[npc.target];
						npc.netUpdate = true;
					}
					//handles despawning
					if (player.dead || Vector2.Distance(player.Center, center) > 5600f)
					{
						npc.velocity.Y -= 0.4f;

					}

					if (aiState == 0)
					{
						aiState = 1;
						npc.alpha = 255;
						npc.rotation = 0f;
						if (Main.netMode != 1)
						{
							npc.ai[0] = -1f;
							npc.netUpdate = true;
						}
					}
					//Sprite rotation code
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
					//ai state 1... retreating...
					if (aiState == 0)
					{
					//npc.velocity *= 0.98f;
					aiIncrementThree++;
						int num19 = Math.Sign(player.Center.X - center.X);
						if (num19 != 0)
						{
							npc.direction = num19;
							npc.spriteDirection = -npc.direction;
						}
						//if (aiIncrementThree > 20f)
						//{
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
						//}
						if (aiIncrementThree >= (float)(num9 - 30))
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
						aiIncrementThree += 1;
						if (aiIncrementThree >= (float)num16)
						{
							aiIncrementOne = 0;
							aiIncrementTwo = 0;
							aiIncrementThree = 0;
							npc.netUpdate = true;
						}
					}
					if (aiState == 2)//aiIncrementTwo == 0f && !player.dead)
					{
						if (aiIncrementTwo <= 0f)
						{
							aiIncrementTwo = 300 * Math.Sign((center - player.Center).X);
						}
						Vector2 vector = Vector2.Normalize(player.Center + new Vector2(aiIncrementTwo, -200f) - center - npc.velocity) /* * scalefactor?;
			/*	if (npc.velocity.X < vector.X)
				{
					npc.velocity.X += 1.5f;
					if (npc.velocity.X < 0f && vector.X > 0f)
					{
						npc.velocity.X += 1.5f;
					}
				}
				else if (npc.velocity.X > vector.X)
				{
					npc.velocity.X -= 1.5f;
					if (npc.velocity.X > 0f && vector.X < 0f)
					{
						npc.velocity.X -= 1.5f;
					}
				}
				if (npc.velocity.Y < vector.Y)
				{
					npc.velocity.Y += 1.5f;
					if (npc.velocity.Y < 0f && vector.Y > 0f)
					{
						npc.velocity.Y += 1.5f;
					}
				}
				else if (npc.velocity.Y > vector.Y)
				{
					npc.velocity.Y -= 1.5f;
					if (npc.velocity.Y > 0f && vector.Y < 0f)
					{
						npc.velocity.Y -= 1.5f;
					}
				}
				int num19 = Math.Sign(player.Center.X - center.X);
				int direction = num19;
				int num22 = Math.Sign(player.Center.X - center.X);
				if (num22 != 0)
				{
					if (aiIncrementThree == 0f && num22 != direction)
					{
						npc.rotation += (float)Math.PI;
					}
					direction = num22;
					if (npc.spriteDirection != -direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -direction;
				}
				aiIncrementThree += 1;
				float num2 = 4;
				num2 *= 1 + (1 - npc.scale);
				if (!(aiIncrementThree >= (float)num2))
				{
					return;
				}
				int num23 = 0;
				switch ((int)aiIncrementThree)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
						num23 = 1;
						break;
					case 10:
						aiIncrementThree = 1;
						num23 = 2;
						break;
					case 11:
						aiIncrementThree = 0;
						num23 = 3;
						break;
				}
				//if (flag)
				//{
				//num23 = 4;
				//}
				float num5 = 30f;
				switch (num23)
				{
					case 1:
						aiIncrementOne = 1;
						aiIncrementTwo = 0;
						aiIncrementThree= 0;
						npc.velocity = Vector2.Normalize(player.Center - center) * num5;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num22 != 0)
						{
							direction = num22;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -direction;
						}
						break;
					case 2:
						aiIncrementOne = 2;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
					case 3:
						aiIncrementOne = 3;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
					case 4:
						aiIncrementOne = 4;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
				}
				//netUpdate = true;
			}
			if (aiState == 3)
			{
				int num24 = 7;
				for (int j = 0; j < num24; j++)
				{
					Vector2 value3 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(j - (num24 / 2 - 1)) * Math.PI / (double)(float)num24) + center;
					Vector2 value4 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num25 = Dust.NewDust(value3 + value4, 0, 0, 172, value4.X * 2f, value4.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num25].noGravity = true;
					Main.dust[num25].noLight = true;
					Main.dust[num25].velocity /= 4f;
					Main.dust[num25].velocity -= npc.velocity;
				}
				aiIncrementTwo += 1;
				float num4 = 30f;
				if (aiIncrementTwo >= (float)num4)
				{
					aiIncrementOne = 0;
					aiIncrementTwo = 0;
					aiIncrementThree += 2;
					//netUpdate = true;
				}
			}
			else if (aiState == 3)
			{
				if (aiIncrementTwo == 0f)
				{
					aiIncrementOne = 300 * Math.Sign((center - player.Center).X);
				}
				Vector2 vector2 = Vector2.Normalize(player.Center + new Vector2(aiIncrementOne, -200f) - center - npc.velocity) * scaleFactor2;
				if (npc.velocity.X < vector2.X)
				{
					npc.velocity.X += num8;
					if (npc.velocity.X < 0f && vector2.X > 0f)
					{
						npc.velocity.X += num8;
					}
				}
				else if (npc.velocity.X > vector2.X)
				{
					npc.velocity.X -= num8;
					if (npc.velocity.X > 0f && vector2.X < 0f)
					{
						npc.velocity.X -= num8;
					}
				}
				if (npc.velocity.Y < vector2.Y)
				{
					npc.velocity.Y += num8;
					if (npc.velocity.Y < 0f && vector2.Y > 0f)
					{
						npc.velocity.Y += num8;
					}
				}
				else if (npc.velocity.Y > vector2.Y)
				{
					npc.velocity.Y -= num8;
					if (npc.velocity.Y > 0f && vector2.Y < 0f)
					{
						npc.velocity.Y -= num8;
					}
				}
				
			
				int num26 = Math.Sign(player.Center.X - center.X);
				if (num26 != 0)
				{
					npc.direction = num26;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				aiIncrementTwo += 1;
				if (aiIncrementTwo >= (float)num6)
				{
					aiIncrementOne = 0;
					aiIncrementTwo = 0;
					aiIncrementThree = 0;
					//netUpdate = true;
				}
			}
			else if (aiState == 4)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (aiIncrementOne == (float)(num9 - 30))
				{
					//SoundEngine.PlaySound(29, (int)center.X, (int)center.Y, 9);
				}
				if (Main.netMode != 1 && aiIncrementOne == (float)(num9 - 30)) //if in multiplayer?
				{
					Vector2 vector4 = npc.rotation.ToRotationVector2() * (Vector2.UnitX * npc.direction) * (npc.width + 20) / 2f + center;
					//Projectile.NewProjectile(GetProjectileSpawnSource(), vector4.X, vector4.Y, npc.direction * 2, 8f, 385, 0, 0f, Main.myPlayer);
					//Projectile.NewProjectile(GetProjectileSpawnSource(), vector4.X, vector4.Y, -npc.direction * 2, 8f, 385, 0, 0f, Main.myPlayer);
				}
				aiIncrementTwo += 1;
				if (aiIncrementTwo >= (float)num9)
				{
					aiIncrementOne = 0;
					aiIncrementTwo = 0;
					aiIncrementThree = 0;
					//netUpdate = true;
				}
			}
			else if (aiState == 5)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (aiIncrementOne == (float)(num10 - 60))
				{
					//SoundEngine.PlaySound(29, (int)center.X, (int)center.Y, 20);
				}
				aiIncrementTwo += 1;
				if (aiIncrementTwo >= (float)num10)
				{
					aiIncrementOne = 5;
					aiIncrementTwo = 0;
					aiIncrementThree = 0;
					//netUpdate = true;
				}
			}
			else if (aiState == 5 && !player.dead)
			{
				float num3 = 500;
				if (aiIncrementOne == 0f)
				{
					aiIncrementOne = 300 * Math.Sign((center - player.Center).X);
				}
				Vector2 vector5 = Vector2.Normalize(player.Center + new Vector2(aiIncrementOne, -200f) - center - npc.velocity) /* npc.scaleFactor;
				/*if (npc.velocity.X < vector5.X)
				{
					
					npc.velocity.X += num3;
					if (npc.velocity.X < 0f && vector5.X > 0f)
					{
						npc.velocity.X += num3;
					}
				}
				else if (npc.velocity.X > vector5.X)
				{
					npc.velocity.X -= num3;
					if (npc.velocity.X > 0f && vector5.X < 0f)
					{
						npc.velocity.X -= num3;
					}
				}
				if (npc.velocity.Y < vector5.Y)
				{
					npc.velocity.Y += num3;
					if (npc.velocity.Y < 0f && vector5.Y > 0f)
					{
						npc.velocity.Y += num3;
					}
				}
				else if (npc.velocity.Y > vector5.Y)
				{
					npc.velocity.Y -= num3;
					if (npc.velocity.Y > 0f && vector5.Y < 0f)
					{
						npc.velocity.Y -= num3;
					}
				}
				int num27 = Math.Sign(player.Center.X - center.X);
				if (num27 != 0)
				{
					if (aiIncrementTwo == 0f && num27 != npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.direction = num27;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				aiIncrementTwo += 1;
				float num2 = 3f;
				if (aiIncrementTwo <= (float)num2)
				{
					return;
				}
				int num28 = 0;
				switch ((int)aiIncrementThree)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						num28 = 1;
						break;
					case 6:
						aiIncrementThree = 1;
						num28 = 2;
						break;
					case 7:
						aiIncrementThree = 0;
						num28 = 3;
						break;
				}
				//if (flag2)
				//{
				//	num28 = 4;
				//}
				switch (num28)
				{
					case 1:
						aiIncrementOne = 6;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						npc.velocity = Vector2.Normalize(player.Center - center) * 20;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num27 != 0)
						{
							npc.direction = num27;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						break;
					case 2:
						npc.velocity = Vector2.Normalize(player.Center - center) * scaleFactor4;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num27 != 0)
						{
							npc.direction = num27;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						aiIncrementOne = 7;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
					case 3:
						aiIncrementOne = 8;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
					case 4:
						aiIncrementOne = 9;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
				}
				//netUpdate = true;
			}
			else if (aiState == 6)
			{
				int num29 = 7;
				for (int k = 0; k < num29; k++)
				{
					Vector2 value5 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(k - (num29 / 2 - 1)) * Math.PI / (double)(float)num29) + center;
					Vector2 value6 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num30 = Dust.NewDust(value5 + value6, 0, 0, 172, value6.X * 2f, value6.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num30].noGravity = true;
					Main.dust[num30].noLight = true;
					Main.dust[num30].velocity /= 4f;
					Main.dust[num30].velocity -= npc.velocity;
				}
				aiIncrementOne += 1;
				if (aiIncrementOne >= 90)
				{
					aiIncrementOne = 5;
					aiIncrementTwo = 0;					
					aiIncrementThree += 2;
					//netUpdate = true;
				}
			}
			else if (aiState == 7f)
			{
				//if (aiIncrementTwo == 0f)
				//{
				//SoundEngine.PlaySound(29, (int)center.X, (int)center.Y, 20);
				//}
				//if (aiIncrementTwo % (float)num14 == 0f)
				//{
				//SoundEngine.PlaySound(4, (int)base.Center.X, (int)base.Center.Y, 19);
				//if (Main.netMode != 1)
				//{
				//Vector2 vector6 = Vector2.Normalize(velocity) * (width + 20) / 2f + center;
				//int num31 = NewNPC((int)vector6.X, (int)vector6.Y + 45, 371);
				//Main.npc[num31].target = target;
				//Main.npc[num31].velocity = Vector2.Normalize(velocity).RotatedBy((float)Math.PI / 2f * (float)direction) * scaleFactor3;
				//Main.npc[num31].netUpdate = true;
				//Main.npc[num31].ai[3] = (float)Main.rand.Next(80, 121) / 100f;
				//}
				//}
				npc.velocity = npc.velocity.RotatedBy((0f - num15) * (float)npc.direction);
				npc.rotation -= num15 * (float)npc.direction;
				aiIncrementTwo += 1;
				if (aiIncrementTwo >= (float)num13)
				{
					aiIncrementOne = 5;
					aiIncrementTwo = 0;
					aiIncrementThree = 0;
					//netUpdate = true;
				}
			}
			else if (aiState == 8f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (aiIncrementThree == (float)(num9 - 30))
				{
					//SoundEngine.PlaySound(29, (int)center.X, (int)center.Y, 20);
				}
				if (Main.netMode != 1 && aiIncrementThree == (float)(num9 - 30))
				{
					//Projectile.NewProjectile(GetProjectileSpawnSource(), center.X, center.Y, 0f, 0f, 385, 0, 0f, Main.myPlayer, 1f, target + 1);
				}
				aiIncrementThree += 1;
				if (aiIncrementThree >= (float)num9)
				{
					aiIncrementOne = 5;
					aiIncrementTwo = 0;
					aiIncrementThree = 0;
					//netUpdate = true;
				}
			}
			else if (aiState == 9)
			{
				if (aiIncrementThree < (float)(num11 - 90))
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
				else if (npc.alpha < 255)
				{
					npc.alpha += 4;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (aiIncrementTwo == (float)(num11 - 60))
				{
					//SoundEngine.PlaySound(29, (int)center.X, (int)center.Y, 20);
				}
				aiIncrementThree += 1;
				if (aiIncrementThree >= (float)num11)
				{
					aiIncrementOne = 10;
					aiIncrementTwo = 0;
					aiIncrementThree = 0;
					//netUpdate = true;
				}
			}
			else if (aiState == 10f && !player.dead)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = false;
				if (npc.alpha < 255)
				{
					npc.alpha += 25;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				if (aiIncrementTwo == 0f)
				{
					aiIncrementTwo = 360 * Math.Sign((center - player.Center).X);
				}
				Vector2 desiredVelocity = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) /* scaleFactor;
			/*	npc.SimpleFlyMovement(desiredVelocity, 500f);
				int num32 = Math.Sign(player.Center.X - center.X);
				if (num32 != 0)
				{
					if (aiIncrementThree == 0f && num32 != npc.direction)
					{
						npc.rotation += (float)Math.PI;
						for (int l = 0; l < npc.oldPos.Length; l++)
						{
							npc.oldPos[l] = Vector2.Zero;
						}
					}
					npc.direction = num32;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				aiIncrementThree += 1;
				if (aiIncrementThree <= 3)
				{
					return;
				}
				int num33 = 0;
				switch ((int)aiIncrementThree)
				{
					case 0:
					case 2:
					case 3:
					case 5:
					case 6:
					case 7:
						num33 = 1;
						break;
					case 1:
					case 4:
					case 8:
						num33 = 2;
						break;
				}
				switch (num33)
				{
					case 1:
						aiIncrementOne = 11;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						npc.velocity = Vector2.Normalize(player.Center - center) * 20;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num32 != 0)
						{
							npc.direction = num32;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						break;
					case 2:
						aiIncrementOne = 12;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
					case 3:
						aiIncrementOne = 13;
						aiIncrementTwo = 0;
						aiIncrementThree = 0;
						break;
				}
				//netUpdate = true;
			}
			else if (aiState == 11)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = true;
				npc.alpha -= 25;
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				int num34 = 7;
				for (int m = 0; m < num34; m++)
				{
					Vector2 value7 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(m - (num34 / 2 - 1)) * Math.PI / (double)(float)num34) + center;
					Vector2 value8 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num35 = Dust.NewDust(value7 + value8, 0, 0, 172, value8.X * 2f, value8.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num35].noGravity = true;
					Main.dust[num35].noLight = true;
					Main.dust[num35].velocity /= 4f;
					Main.dust[num35].velocity -= npc.velocity;
				}
				aiIncrementTwo += 1;
				if (aiIncrementTwo >= 90)
				{
					aiIncrementOne = 10;
					aiIncrementTwo = 0;
					aiIncrementThree = 1;
					
					//netUpdate = true;
				}
			}
			
		}

		*/
        public override void HitEffect(int hitDirection, double damage)
        {
            //create dust on being hit
            for (int i = 0; i < 10; i++)
            {
                int dustType = DustID.JungleSpore;
                int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X * Main.rand.Next(-50, 50) * 0.01f;
                dust.velocity.Y = dust.velocity.Y * Main.rand.Next(-50, 50) * 0.01f;
                dust.scale *= 1 + Main.rand.Next(-30, 30) * 0.01f;
            }
        }

        public override void OnKill()
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(NPC.position, Mod.Find<ModItem>("UltraciteOre_Item").Type);
            }

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(NPC.position, Mod.Find<ModItem>("UltraciteTsunami").Type);
            }

        }






    }
}
