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

//town npc Preston Garvey. This is both the first NPC and town NPC in this mod that was implemented ingame :)

namespace wartinyfall76.NPCs.Town.Fallout
{
    [AutoloadHead]
    public class PrestonNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Fallout/PrestonNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Fallout/PrestonNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "MinutemenSeniorOfficer";
            return Mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[NPC.type] = 10; //???
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[NPC.type] = 80;
            NPCID.Sets.AttackAverageChance[NPC.type] = 40;
            NPCID.Sets.HatOffsetY[NPC.type] = -3; //higher the number the lower the hat, leave at 0

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
            AnimationType = NPCID.ArmsDealer;
        }

        //spawn in Preston if the arms dealer is alive
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
            int otherNPC = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (otherNPC >= 0)
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            return "Preston Garvey";
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
                int otherNPC = NPC.FindFirstNPC(NPCID.ArmsDealer); //checks if the guide is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return "I had to get myself a new gun from " + Main.npc[otherNPC].GivenName + ". I don't know where my Laser Musket went.";
                }

            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (nina != null && Main.rand.NextBool(8))
            {
                return "That Nina girl gives me the creeps...";
            }

            NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
            if (hanzo != null && Main.rand.NextBool(8))
            {
                return "Hanzo seems to be a good marksman. He also seems to have something weighting greatly on his mind.";
            }

            NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (klee != null && Main.rand.NextBool(8))
            {
                return "Klee's a great girl, but her hobbies are very dangerous.";
            }

            NPC Eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Eudico != null && Main.rand.NextBool(8))
            {
                return "If I were to work together with Eudico to free Fortuna from the Corpus, our forces would be unstoppable!";
            }

            NPC Lisa = FindNPC(ModContent.NPCType<LisaNPC>());
            if (Lisa != null && Main.rand.NextBool(8))
            {
                return "Lisa's books would have been able to provide lots of entertainment back in the wasteland... There wasnt really much entertainment, just hard work and survival.";
            }

            if (!Main.dayTime && Main.rand.NextBool(2)) //if it is night
                {
                    return "Damm " + Main.worldName + " has monsters too...";
                }

                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "You've got to protect the people at a minute's notice.";
                    case 1:
                        return "At least it's not raining.";
                    case 2:
                        return "I kind of doubt the Brotherhood's intentions are peaceful.";
                    case 3:
                        return "I had to put on a brave face as long as there were still people counting on me. Thats the only reason I kept going.";
                    default:
                        return "There's another settlement that needs our help. I hope you can get to them quickly. We need to show people that the Minutemen are back";
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
            //repeat for each item, up to 40
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ScorchedTransmitter").Type);
            nextSlot++;

            //condtions can also exist
            if (Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BewitchingTable);
                nextSlot++;
            }
        }

        public override void OnKill()
        {
            base.OnKill();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
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
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1; //?
            item = 434; //434 should be the clockwork assault rifle 96 is musket
            closeness = 1; //?
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
