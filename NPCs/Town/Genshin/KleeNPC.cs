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
using wartinyfall76.NPCs.Town.Crash;
using wartinyfall76.NPCs.Town.Fallout;
using wartinyfall76.NPCs.Town.Genshin;
using System.Net;


//town npc Klee

namespace wartinyfall76.NPCs.Town.Genshin
{
    [AutoloadHead]
    public class KleeNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Genshin/KleeNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Genshin/KleeNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "SparkKnight";
            return mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 23; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[npc.type] = 4; //???
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[npc.type] = 80;
            NPCID.Sets.AttackAverageChance[npc.type] = 40;
            NPCID.Sets.HatOffsetY[npc.type] = 3; //higher the number the lower the hat, leave at 0

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
            animationType = NPCID.Angler;
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
            
            if (NPC.downedBoss2) //if eater of worlds/ brain of cthulhu is defeated
            {
                return true;
            }
                
            return false;
        }

        public override string TownNPCName()
        {
            return "Klee";
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
                int otherNPC = NPC.FindFirstNPC(NPCID.Demolitionist); //checks if the demolitionist is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return Main.npc[otherNPC].GivenName + " has agreed to go fish blasting with me! Our bombs will get sooooo much fish!";
                }

            NPC nina = FindNPC(ModContent.NPCType<NinaNPC>());
            if (nina != null && Main.rand.NextBool(8))
            {
                return "Nina totally got spooked when I went fish blasting tehee!";
            }

            NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
            if (preston != null && Main.rand.NextBool(8))
            {
                return "Preston said the minutemen have to protect people at a minute's notice. Thats not a lot of time so he has to be very fast!";
            }

            NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
            if (hanzo != null && Main.rand.NextBool(8))
            {
                return "Hanzo got super annoyed when I went fish blasting tehee!";
            }

            NPC eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
            if (eudico != null && Main.rand.NextBool(8))
            {
                return "Eudico said I would make a great ventkid. Do you know what a ventkid is?";
            }

            NPC lisa = FindNPC(ModContent.NPCType<LisaNPC>());
            if (lisa != null && Main.rand.NextBool(8))
            {
                return "Lisa is the best! She always sneaks me some treats when I visit her!";
            }

            otherNPC = NPC.FindFirstNPC(NPCID.Guide);
            if (!Main.dayTime && otherNPC >= 0 && Main.rand.NextBool(2)) //if it is night and the guide is alive
                {
                    return " Can you please tell " + Main.npc[otherNPC].GivenName + "that Klee is not a baby and is definitely allowed out to play at night? Please take me out to play together!";
                }

            if(Main.raining && Main.rand.NextBool(8))
            {
                return "Mwauhahaha, lucky all my new bombs are waterproof!";
            }

                switch (Main.rand.Next(5))
                {
                    case 0:
                        return "Spark Knight Klee of the Knights of Favonius, reporting for duty!";
                    case 1:
                        return "Klee was a brave girl today! I found a really weird-looking lizard! Want me to show it to you?";
                    case 2:
                        return "Dear Anemo God, please make Klee's bombs blow in the right direction and only blow up bad guys. The end.";
                    case 3:
                        return "Can I come play with you today? Pleeeease? I wanna go on an adventure!";
                     case 4:
                         return "Hello, are you here for playtime with Klee?";
                     case 5:
                    return "Do you wanna come fish blasting with me? I'll get grounded for a whole day, but it's way worth it coz the fish taste sooo goood!";
                default:
                    return "Klee can help!";
            }




        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Playtime";
            //button2 = "Debuff";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                //check if we already have the buff
                if(Main.LocalPlayer.HasBuff(mod.BuffType("PlaytimeBuff")))
                {
                    Main.npcChatText = "Lets play again soon, im busy";

                    return;
                }

                //is it a shop
                Main.npcChatText = "Klee can help!";

                
                
                //get the player

                //make klee give a buff... to be added
                Main.LocalPlayer.AddBuff(mod.BuffType("PlaytimeBuff"), 12000); //time is in seconds?


            }
            else
            {
                //Main.npcChatText = "Muahahahaha!";

            }
        }

       /* public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //repeat for each item, up to 40
            shop.item[nextSlot].SetDefaults(mod.ItemType("ScorchedTransmitter"));
            nextSlot++;

            //condtions can also exist
            if (Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BewitchingTable);
                nextSlot++;
            }
        }*/

        public override void NPCLoot()
        {
            base.NPCLoot();
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
            projType = ProjectileID.BouncyGrenade;
            attackDelay = 1;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            //scale = 1; //?
            //item = 434; //434 should be the clockwork assault rifle 96 is musket
            //closeness = 1; //?
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
