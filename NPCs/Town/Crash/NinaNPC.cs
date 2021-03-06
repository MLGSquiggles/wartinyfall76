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
using wartinyfall76.NPCs.Town.Fallout;

//town npc Nina cortex. This is both the first NPC and town NPC in this mod that was implemented ingame :)

namespace wartinyfall76.NPCs.Town.Crash
{
    [AutoloadHead]
    public class NinaNPC : ModNPC
    {
        //this function allows us to find if it exists in the world
        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        //load texture for the npc
        public override string Texture
        {
            get { return "wartinyfall76/NPCs/Town/Crash/NinaNPC"; }
        }

        public override string HeadTexture
        {
            get { return "wartinyfall76/NPCs/Town/Crash/NinaNPCHead"; }
        }

        //if we got alt textures (nina doesnt need)
        //public override string[] AltTextures
        //{
        //    get { return new[] { "wartinyfall76/NPCs/NinaNPC_Alt_1" }; }
        //}

        //name is the occupation/ not personal name
        public override bool Autoload(ref string name)
        {
            name = "EvilStudent";
            return Mod.Properties.Autoload;
        }

        //setup default stuff for town NPC
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23; //amount of sprites in the sprite sheet
            NPCID.Sets.AttackFrameCount[NPC.type] = 4; //???
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 1; //research attack types? 1 is shooting 3 is swing
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 0; //higher the number the lower the hat, leave at 0

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7; //town npc style
            NPC.damage = 69;
            NPC.defense = 17;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Nurse;
        }

        //spawn in Nina, replace later
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == Mod.Find<ModItem>("TheStabbyStabber").Type) //for testing use James's stabby stabber
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string TownNPCName()
        {
            return "Nina Cortex";
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
            
            if(!Main.bloodMoon) //if it is not a blood moon have these lines
            {
                int otherNPC = NPC.FindFirstNPC(NPCID.Guide); //checks if the guide is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the guide is alive
                {
                    return "Hey this " + Main.npc[otherNPC].GivenName + " guy is a loser!";
                }
                if (!Main.dayTime && Main.rand.NextBool(2)) //if it is night
                {
                    return "Where's the destruction at! I wanna see " + Main.worldName + " overtaken by evil!"; ;
                }

                NPC preston = FindNPC(ModContent.NPCType<PrestonNPC>());
                if (preston != null && Main.rand.NextBool(8))
                {
                    return "If Preston talks about another settlement needing help i'll make sure THIS settlement needs help!";
                }

                NPC hanzo = FindNPC(ModContent.NPCType<HanzoNPC>());
                if (hanzo != null && Main.rand.NextBool(8))
                {
                    return "I dont get it. Hanzo is not pure enough to be good but not bad enough to be evil.";
                }

                NPC klee = FindNPC(ModContent.NPCType<KleeNPC>());
                if (klee != null && Main.rand.NextBool(8))
                {
                    return "I want to use those special bombs for evil but Klee uses them for fishing. How boring...";
                }

                NPC eudico = FindNPC(ModContent.NPCType<EudicoNPC>());
                if (eudico != null && Main.rand.NextBool(8))
                {
                    return "Eudico looks like a monster N-Gin would fall head over heels for. Too bad she's a good guy!";
                }

                NPC lisa = FindNPC(ModContent.NPCType<LisaNPC>());
                if (lisa != null && Main.rand.NextBool(8))
                {
                    return "Wait are you telling me Lisa is a witch? I thought witches had to have green skin and be evil!";
                }

                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "Breaking things makes me happy.";
                    case 1:
                        return "Where the monsters at! Its getting boring here!";
                    case 2:
                        return "I hope you have been up to evil.";
                    case 3:
                        return "Evil things make me happy!";
                    default:
                        return "This beats doing schoolwork!";
                }
            }
            else //if it is a blood moon have these lines
            {
                int otherNPC = NPC.FindFirstNPC(NPCID.Nurse); //checks if the nurse is alive
                if (otherNPC >= 0 && Main.rand.NextBool(4)) //randomly if the nurse is alive in a blood moon
                {
                    return "I don't feel right. Maybe I should check in with " + Main.npc[otherNPC].GivenName + " to see why " +
                        "I don't feel like myself.";
                }
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return "Fixing things makes me happy.";
                    case 1:
                        return "Too many monsters! Destroy the evil! Why do I feel so happy!";
                    case 2:
                        return "I hope you have been up to heroic things... Hang on something's not right.";
                    case 3:
                        return "Good things make me happy! Isn't it such a pretty night?";
                    default:
                        return "This beats doing schoolwork!";
                }
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
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("AkuAkuItem").Type);
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
            cooldown = 30;
            randExtraCooldown = 25;
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
            projType = ProjectileID.ShadowFlameKnife;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 20f;
            randomOffset = 2f;
        }
    }
}
