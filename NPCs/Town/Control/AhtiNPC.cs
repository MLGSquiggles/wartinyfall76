using IL.Terraria.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using wartinyfall76.NPCs.Town.Warframe;
using wartinyfall76.NPCs.Town.Overwatch;
using wartinyfall76.NPCs.Town.Genshin;
using wartinyfall76.NPCs.Town.Crash;
using wartinyfall76.NPCs.Town.Fallout;
using wartinyfall76.NPCs.Town.GTA;
using wartinyfall76.NPCs.Town.Sims;

//town npc Preston Garvey. This is both the first NPC and town NPC in this mod that was implemented ingame :)

namespace wartinyfall76.NPCs.Town.Control
{
    [AutoloadHead]
    public class AhtiNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Control/AhtiNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Control/AhtiNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "TemporalJanitor";
            return Mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 24; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[NPC.type] = 10; //???
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[NPC.type] = 80;
            NPCID.Sets.AttackAverageChance[NPC.type] = 40;
            NPCID.Sets.HatOffsetY[NPC.type] = 0; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7; //town npc style
            NPC.damage = 40;
            NPC.defense = 17;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        //spawn in Trevor if world is in hardmode and player has drugs (implement hancock from fallout)
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            //for (int i = 0; i < 255; i++)
            //{
            //    Player player = Main.player[i];
            //    if (!player.active)
            //    {
            //        continue;
            //    }

            //    foreach (Item item in player.inventory)
            //    {
            //        if (item.type == mod.ItemType("TheStabbyStabber")) //for testing use James's stabby stabber
            //        {
            //            return true;
            //        }
            //    }
            //}
            
            if (Main.hardMode)
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            return "Ahti";
            /*
             switch(WorldGen.genRand.Next(4))
             {case 0 :
             return "name 0";
             case 1:
             return name 1;
             case 2: 
             return name 2;
             }
             */
        }

        public override string GetChat()
        {
            
            //if(!Main.bloodMoon) //if it is not a blood moon have these lines
            //{
                int otherNPC = NPC.FindFirstNPC(NPCID.Mechanic); //checks if the guide is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return  Main.npc[otherNPC].GivenName + " always has the job in one's glove.";
                }

            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (nina != null && Main.rand.NextBool(8))
            {
                return "Those augments Nina has are the rye in one's wrist.";
            }

            NPC trevor = FindNPC(ModContent.NPCType<TrevorNPC>());
            if (trevor != null && Main.rand.NextBool(8))
            {
                return "Trevor always goes about his day like a bear which has been shot in the ass.";
            }

            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Preston's Minutemen will be coming in a year, in the birch bark month! Jahaa, jaa-a!";
            }

            NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
            if (hanzo != null && Main.rand.NextBool(8))
            {
                return "Hanzo's sheats gonna rattle...";
            }

            NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (klee != null && Main.rand.NextBool(8))
            {
                return "Explosives are not to be thrown at something waterfowl! Klee shouldn't even have them!";
            }

            NPC Eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Eudico != null && Main.rand.NextBool(8))
            {
                return "I'd hate to live under Corpus rule like Eudico. The body should not come loose like grandma's tooth!";
            }

            NPC Lisa = FindNPC(ModContent.NPCType<LisaNPC>());
            if (Lisa != null && Main.rand.NextBool(8))
            {
                return "Lisa seems to make the other ladies into a person with black socks.";
            }

            NPC Khrust = FindNPC(ModContent.NPCType<KhrustGolovyNPC>());
            if (Khrust != null && Main.rand.NextBool(8))
            {
                return "Khrust Golovy is like a pot of sour milk that always pisses honey.";
            }

            if (!Main.dayTime && Main.rand.NextBool(2)) //if it is night
                {
                    return "Are you thinking about the crows in the sky?";
                }

                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "Jahaa, jaa-a!";
                    case 1:
                        return "I can tell you are not a yesterday's grouse's son";
                    case 2:
                        return "Did you have piss in your sock?";
                    case 3:
                        return "Jumalauta, Helvetti, Perkele, Saatana!";
                    default:
                        return "Jahaa, jaa-a! Uh-huh!";
                }
            
            
            
            
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            //button2 = "Debuff";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                //is it a shop
                shop = true;
            }
            else
            {
                Main.npcChatText = "Muahahahaha!";

            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("AshtrayMazePainting").Type); //change to Ahti
            nextSlot++;


        }

        public override void OnKill()
        {
            base.OnKill();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 80;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 40;
            randExtraCooldown = 35;
        }

        //public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        //{
        //    itemWidth = 5;
        //    itemHeight = 5;
        //}

        public override void TownNPCAttackShoot(ref bool inBetweenShots)
        {
            inBetweenShots = true;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.WaterBolt;
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            //scale = 1; //?
            //item = ItemID.GrenadeLauncher; //434 should be the clockwork assault rifle 96 is musket
            //closeness = 1; //?
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 0.5f;
            randomOffset = 4f;
        }
    }
}
