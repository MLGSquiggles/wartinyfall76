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

//town npc Preston Garvey. This is both the first NPC and town NPC in this mod that was implemented ingame :)

namespace wartinyfall76.NPCs.Town.GTA
{
    [AutoloadHead]
    public class TrevorNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/GTA/TrevorNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/GTA/TrevorNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "CrazyDude";
            return mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 26; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[npc.type] = 10; //???
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[npc.type] = 80;
            NPCID.Sets.AttackAverageChance[npc.type] = 40;
            NPCID.Sets.HatOffsetY[npc.type] = 0; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; //town npc style
            npc.damage = 40;
            npc.defense = 17;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1; 
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
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
            return "Trevor Philips";
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
                int otherNPC = NPC.FindFirstNPC(NPCID.Guide); //checks if the guide is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return "Isn't " + Main.npc[otherNPC].GivenName + " just a great example to us all? Living proof that shit can talk! ";
                }

            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (nina != null && Main.rand.NextBool(8))
            {
                return "Nina's beautiful. Just like me";
            }

            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Settlement this, settlement that! Preston should settle the hell down!";
            }

            NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
            if (hanzo != null && Main.rand.NextBool(8))
            {
                return "I've met pond slime with more personality than Hanzo!";
            }

            NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
            if (klee != null && Main.rand.NextBool(8))
            {
                return "If Klee throws one of those bombs near me im making a personal injury claim!";
            }

            NPC Eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (Eudico != null && Main.rand.NextBool(8))
            {
                return "Oh, God, give me the strength to knock out Eudico's stupid robotic toaster head!";
            }

            NPC Lisa = FindNPC(ModContent.NPCType<LisaNPC>());
            if (Lisa != null && Main.rand.NextBool(8))
            {
                return "Lisa is such a looker... Who knew silicone and desperation could be so damn alluring?";
            }

            if (!Main.dayTime && Main.rand.NextBool(2)) //if it is night
                {
                    return "Shouldn't you be killing monsters or something?";
                }

                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "since I was a little kid I dreamt big, y'know? I've always wanted to be an international drug dealer and... weapons trader, alright?";
                    case 1:
                        return "I'm cranked out on speed most of the time, but I am productivity personified.";
                    case 2:
                        return "Me, I'm Not Rational.";
                    case 3:
                        return "Hey there, cupcake.";
                    default:
                        return "It's T-revor time!";
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
            shop.item[nextSlot].SetDefaults(mod.ItemType("GhostCaptainPainting")); //change to SOT rep
            nextSlot++;

            shop.item[nextSlot].SetDefaults(mod.ItemType("AshtrayMazePainting")); //change to Ahti
            nextSlot++;

            shop.item[nextSlot].SetDefaults(mod.ItemType("TrevorStatue"));
            nextSlot++;

            //condtions can also exist
            if (Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BewitchingTable);
                nextSlot++;
            }
        }

        public override void NPCLoot()
        {
            base.NPCLoot();
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
            projType = ProjectileID.RocketI;
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            scale = 1; //?
            item = ItemID.GrenadeLauncher; //434 should be the clockwork assault rifle 96 is musket
            closeness = 1; //?
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 0.5f;
            randomOffset = 4f;
        }
    }
}
